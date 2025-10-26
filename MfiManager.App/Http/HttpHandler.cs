using System.Text;
using System.Text.Json;
using MfiManager.App.Http.Responses;

namespace MfiManager.App.Http {

    public class HttpHandler<T> : IHttpHandler<T> {
        protected readonly HttpClient MfiHttpClient;
        public ILogger<T> Logger {get;set;}
        protected readonly JsonSerializerOptions JsonOptions;
        private readonly string LOG_ID = $"RESQUEST{DateTime.Now:yyyyMMddHHmmssfff}";
        public HttpHandler(IHttpClientFactory httpClientFactory) {
            JsonOptions = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = false
            };

            //..create client   
            MfiHttpClient = httpClientFactory.CreateClient("MiddlewareClient");
        }

        public async Task<MfiHttpResponse<TResponse>> GetAsync<TResponse>(string endpoint) where TResponse : class {

            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                     try {
                        Logger.LogInformation("MFI GET Request to: {Endpoint}", endpoint);
                
                        //..formulate URL
                        var fullUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                        Logger.LogInformation("MIDDLEWARE URL: {FullUrl}", fullUrl);

                        //..send request
                        var response = await MfiHttpClient.GetAsync(endpoint);
                        if(response == null) { 
                            var error = new MfiHttpErrorResponse(
                                502,
                                "Bad Gateway or possible timeout",
                                "The middleware service did not respond or service timeout occurred"
                            );
                            Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        }

                        //..we received a response
                        Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                        if (!response.IsSuccessStatusCode) {
                            Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                            var error = new MfiHttpErrorResponse(
                                (int)response.StatusCode,
                                "Could not complete request. An Error occurred",
                                $"HTTP Status Code: {response.StatusCode}"
                            );
            
                            Logger.LogInformation($"SERVICE ERROR: {JsonSerializer.Serialize(error)}");
                            return new MfiHttpResponse<TResponse>(error);
                        }
        
                        //..read and deserialize response
                        var responseData = await response.Content.ReadAsStringAsync();
                        Logger.LogInformation("MFI GET Response received from: {Endpoint}", endpoint);
                        Logger.LogInformation("MFI Midleware data : {ResponseData}",responseData);

                        try {

                            Logger.LogInformation("Starting deserialization...");
                            var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, JsonOptions);
    
                            if (result == null) {
                                Logger.LogInformation("Deserialization returned null");
                                var error = new MfiHttpErrorResponse(
                                    500,
                                    "System Data Error",
                                    "Deserialization returned null"
                                );
                                Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                                return new MfiHttpResponse<TResponse>(error);
                            }
    
                            Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, JsonOptions));
                            return result;
                        } catch (JsonException jex) {
                            Logger.LogInformation("Deserialization Failed: {Message}", jex.Message);
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                $"Failed to deserialize response. An error has occurred"
                            );
                            Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        } catch (Exception ex) { 
                            Logger.LogError("Unexpected deserialization error: {Message}", ex.Message);
                            Logger.LogWarning("Exception Type: {Name}", ex.GetType().Name);
                            Logger.LogCritical("StackTrace: {StackTrace}", ex.StackTrace);
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                $"Unexpected deserialization error: {ex.Message}"
                            );
                            Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        }
                    } catch (HttpRequestException httpEx) {
                        Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                        Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                        var error = new MfiHttpErrorResponse(
                            502,
                            "Network error occurred",
                            httpEx.Message
                        );
                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
        
                    } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                        Logger.LogError("Request timeout: {Message}", timeoutEx.InnerException.Message);
                        Logger.LogCritical("{StackTrace}", timeoutEx.StackTrace);
                        var error = new MfiHttpErrorResponse(
                            406,
                            "Request timeout",
                            "The request took too long to complete"
                        );
                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
        
                    } catch (JsonException jsonEx) {
                        Logger.LogError("JSON Deserialization Error: {Message}", jsonEx.Message);
                        Logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
                        var error = new MfiHttpErrorResponse(
                            500,
                            "Ooops! Sorry, something went wrong",
                            "Data format error. Could not format data"
                        );
                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
        
                    } catch (Exception ex)  {
                        Logger.LogError("Unexpected Error: {Message}", ex.Message);    
                        Logger.LogCritical("{StackTrace}", ex.StackTrace);
                        var error = new MfiHttpErrorResponse(
                            500,
                            "An unexpected error occurred",
                            "Cannot proceed! An error occurred, please try again later"
                        );
                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

            }
           
        }

        public async Task<MfiHttpResponse<TResponse>> PatchAsync<TRequest, TResponse>(string endpoint, TRequest data) where TResponse : class{
             using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                try {
                        Logger.LogInformation("MFI PATCH Request to: {Endpoint}", endpoint);
                        Logger.LogInformation("REQUEST MAP: {Data}", JsonSerializer.Serialize(data));
                        var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        //..requestUrl URL
                        var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                        Logger.LogInformation("REQUEST URL: {RequestUrl}", requestUrl);

                        //..send request
                        var response = await MfiHttpClient.PatchAsync(endpoint, content);
                        if(response == null) { 
                            var error = new MfiHttpErrorResponse(
                                502,
                                "Bad Gateway or possible timeout",
                                "The middleware service did not respond or service timeout occurred"
                            );
                            Logger.LogError("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        }

                        Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                        if (!response.IsSuccessStatusCode) {
                            Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                            var error = new MfiHttpErrorResponse(
                                (int)response.StatusCode,
                                "Could not complete registration. An Error occurred",
                                $"HTTP Status Code: {response.StatusCode}"
                            );
                            Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        }
        
                        //..read and deserialize response
                        var responseData = await response.Content.ReadAsStringAsync();
                        Logger.LogInformation("MFI PATCH Response received from: {Endpoint}", endpoint);
                        try {
                            var options = new JsonSerializerOptions { 
                                PropertyNameCaseInsensitive = true,
                                WriteIndented = true
                            };
    
                            Logger.LogInformation("Starting deserialization...");
                            var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, options);
                            if (result == null) {
                                Logger.LogInformation("Deserialization returned null");
                                var error = new MfiHttpErrorResponse(
                                    500,
                                    "System Data Error",
                                    "Deserialization returned null"
                                );
                                Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(error, options));
                                return new MfiHttpResponse<TResponse>(error);
                            }
    
                            Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, options));
                            return result;
                        } catch (JsonException jex) {
                            Logger.LogError("Deserialization Failed: {Message}", jex.Message);
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                $"Failed to deserialize response. An error has occurred"
                            );
                            Logger.LogInformation("SERVICE RESULT: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        } catch (Exception ex) { 
                            Logger.LogInformation("Unexpected deserialization error: {Message}", ex.Message);
                            Logger.LogError("Exception Type: {Name}", ex.GetType().Name);
                            Logger.LogCritical("{StackTrace}", ex.StackTrace);
    
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                $"Unexpected deserialization error: {ex.Message}"
                            );
                            Logger.LogInformation("SERVICE RESULT: {Error}", JsonSerializer.Serialize(error));
                            return new MfiHttpResponse<TResponse>(error);
                        }
           
                    } catch (Exception ex) {
                        Logger.LogError("MFI PATCH Error for endpoint {Endpoint}: {ex.Message}", endpoint, ex.Message);
                        Logger.LogCritical("{StackTrace}", ex.StackTrace);
                        throw;
                    }

             }

        }

        public async Task PatchAsync<TRequest>(string endpoint, TRequest data) {
             using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                    try {
                        Logger.LogInformation("MFI PATCH Request (no response) to: {Endpoint}", endpoint);
                        Logger.LogInformation("REQUEST MAP: {Data}", JsonSerializer.Serialize(data));

                        var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                        var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                        Logger.LogInformation("REQUEST URL: {RequestUrl}", requestUrl);

                        var response = await MfiHttpClient.PatchAsync(endpoint, content);
                        if (response == null) {
                            var error = new MfiHttpErrorResponse(502,
                                "Bad Gateway or possible timeout",
                                "The middleware service did not respond or service timeout occurred"
                            );
                            Logger.LogError("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                            throw new HttpRequestException(error.ToString());
                        }

                        Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                        if (!response.IsSuccessStatusCode) {
                            Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                            var error = new MfiHttpErrorResponse(
                                (int)response.StatusCode,
                                "Could not complete PATCH request. An error occurred",
                                $"HTTP Status Code: {response.StatusCode}"
                            );

                            Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                            throw new HttpRequestException(error.ToString());
                        }

                        Logger.LogInformation("MFI PATCH Request completed for: {Endpoint}", endpoint);
                    } catch (HttpRequestException httpEx) {
                        Logger.LogInformation("HTTP Request Exception: {Message}", httpEx.Message);
                        Logger.LogError("{StackTrace}", httpEx.StackTrace);
                        throw;
                    } catch (Exception ex) {
                        Logger.LogError("Unhandled Exception during PATCH to {Endpoint}: {Message}", endpoint, ex.Message);
                        Logger.LogInformation("{StackTrace}", ex.StackTrace);
                        throw;
                    }

             }

        }

        public async Task<MfiHttpResponse<TResponse>> PostAsync<TRequest, TResponse>(string endpoint, TRequest data) where TResponse : class {
             using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                 try {
                    Logger.LogInformation("MFI POST Request to: {Endpoint}", endpoint);
                    Logger.LogInformation("REQUEST MAP: {Data}", JsonSerializer.Serialize(data));
                    var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            
                    var fullUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("MIDDLEWARE URL: {FullUrl}", fullUrl);

                    var response = await MfiHttpClient.PostAsync(endpoint, content);
                    if(response == null) { 
                        var error = new MfiHttpErrorResponse(502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );
            
                        Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete registration. An Error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );
            
                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }
        
                    //..read and deserialize response
                    var responseData = await response.Content.ReadAsStringAsync();
                    Logger.LogInformation("MFI POST Response received from: {Endpoint}", endpoint);
                    Logger.LogInformation("Response Data: {ResponseData}", responseData);
                    try {
                        var options = new JsonSerializerOptions { 
                            PropertyNameCaseInsensitive = true,
                            WriteIndented = true
                        };
    
                        Logger.LogInformation("Starting deserialization...");
                        var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, options);
    
                        if (result == null) {
                            Logger.LogInformation("Deserialization returned null");
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                "Deserialization returned null"
                            );
                            Logger.LogError("{Result}", JsonSerializer.Serialize(result, options));
                            return new MfiHttpResponse<TResponse>(error);
                        }
    
                        Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, options));
                        return result;
                    } catch (JsonException jex) {
                        Logger.LogError("Deserialization Failed: {Message}", jex.Message);
                        var error = new MfiHttpErrorResponse(
                            500,
                            "System Data Error",
                            $"Failed to deserialize response. An error has occurred"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    } catch (Exception ex) { 
                        Logger.LogError("Unexpected deserialization error: {Message}", ex.Message);
                        Logger.LogWarning("Exception Type: {Name}", ex.GetType().Name);
                        Logger.LogCritical("{StackTrace}", ex.StackTrace);

                        var error = new MfiHttpErrorResponse(
                            500,
                            "System Data Error",
                            $"Unexpected deserialization error: {ex.Message}"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    }
                 } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                    var error = new MfiHttpErrorResponse(
                        502,
                        "Network error occurred",
                        httpEx.Message
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                 } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                    Logger.LogError("Request timeout: {Message}", timeoutEx.InnerException.Message);
                    Logger.LogCritical("{StackTrace}", timeoutEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        406,
                        "Request timeout",
                        "The request took too long to complete"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                 } catch (JsonException jsonEx) {
                    Logger.LogError("JSON Deserialization Error: {Message}", jsonEx.Message);
                    Logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        500,
                        "Ooops! Sorry, something went wrong",
                        "Data format error. Could not format data"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                 } catch (Exception ex)  {
                    Logger.LogError("Unexpected Error: {Message}", ex.Message);    
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        500,
                        "An unexpected error occurred",
                        "Cannot proceed! An error occurred, please try again later"
                    );
                    return new MfiHttpResponse<TResponse>(error);
                }

             }
        }

        public async Task PostAsync<TRequest>(string endpoint, TRequest data) {
            
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                try {
                    Logger.LogInformation("MFI POST Request (no response) to: {Endpoint}", endpoint);
                    Logger.LogInformation("REQUEST MAP: {Data}", JsonSerializer.Serialize(data));
                    var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("REQUEST URL: {RequestUrl}", requestUrl);

                    var response = await MfiHttpClient.PostAsync(endpoint, content);
                    if (response == null) {
                        var error = new MfiHttpErrorResponse(
                            502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );
                        Logger.LogError("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }
                
                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogError("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete PATCH request. An error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }
            
                    Logger.LogInformation("MFI POST Request completed for: {Endpoint}", endpoint);
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Exception: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                    throw;
                } catch (Exception ex) {
                    Logger.LogError("Unhandled Exception during PATCH to {endpoint}: {Message}", endpoint, ex.Message);
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
                    throw;
                }

            }
        }

        public async Task<MfiHttpResponse<TResponse>> PutAsync<TRequest, TResponse>(string endpoint, TRequest data) where TResponse : class {
            
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                try {
                    Logger.LogInformation("MFI PUT Request to: {Endpoint}", endpoint);
                
                    //..formulate URL
                    var fullUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("MIDDLEWARE URL: {FullUrl}", fullUrl);

                    var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            
                    var response = await MfiHttpClient.PutAsync(endpoint, content);
                    if(response == null) { 
                        var error = new MfiHttpErrorResponse(502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );

                        Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

                    //..we received a response
                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogWarning("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete request. An Error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

                    //..read and deserialize response
                    var responseData = await response.Content.ReadAsStringAsync();
                    Logger.LogInformation("MFI PUT Response received from: {Endpoint}", endpoint);
                    Logger.LogInformation("MFI Midleware data : {ResponseData}", responseData);
            
                    try {

                        Logger.LogInformation("Starting deserialization...");
                        var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, JsonOptions);
    
                        if (result == null) {
                            Logger.LogInformation("Deserialization returned null");
                            var error = new MfiHttpErrorResponse(
                                500,
                                "System Data Error",
                                "Deserialization returned null"
                            );
                            return new MfiHttpResponse<TResponse>(error);
                        }
    
                        Logger.LogError("Deserialization successful. HasError: {HasError}", result.HasError);
                        Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, JsonOptions));
                        return result;
                    } catch (JsonException jex) {
                        Logger.LogError("Deserialization Failed: {Message}", jex.Message);
                        var error = new MfiHttpErrorResponse(
                            500,
                            "System Data Error",
                            $"Failed to deserialize response. An error has occurred"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    } catch (Exception ex) { 
                        Logger.LogInformation("Unexpected deserialization error: {Message}", ex.Message);
                        Logger.LogError("Exception Type: {Name}", ex.GetType().Name);
                        Logger.LogCritical("{StackTrace}", ex.StackTrace);
    
                        var error = new MfiHttpErrorResponse(
                            500,
                            "System Data Error",
                            $"Unexpected deserialization error: {ex.Message}"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    }
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        502,
                        "Network error occurred",
                        httpEx.Message
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                    Logger.LogError("Request timeout: {Message}", timeoutEx.InnerException?.Message);
                    Logger.LogCritical("{StackTrace}", timeoutEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        406,
                        "Request timeout",
                        "The request took too long to complete"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (JsonException jsonEx) {
                    Logger.LogError("JSON Deserialization Error: {Message}", jsonEx.Message);
                    Logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        500,
                        "Ooops! Sorry, something went wrong",
                        "Data format error. Could not format data"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (Exception ex)  {
                    Logger.LogError("Unexpected Error: {Message}", ex.Message);    
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        500,
                        "An unexpected error occurred",
                        "Cannot proceed! An error occurred, please try again later"
                    );
                    return new MfiHttpResponse<TResponse>(error);
                }
            }

        }
         
        public async Task PutAsync<TRequest>(string endpoint, TRequest data) {              
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {

                try {
                    Logger.LogInformation("MFI PUT Request (no response) to: {Endpoint}", endpoint);
                    Logger.LogInformation("REQUEST MAP: {Data}", JsonSerializer.Serialize(data));
            
                    var jsonContent = JsonSerializer.Serialize(data, JsonOptions);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            
                    var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogError("REQUEST URL: {RequestUrl}", requestUrl);
                    var response = await MfiHttpClient.PutAsync(endpoint, content);
                    if (response == null) {
                        var error = new MfiHttpErrorResponse(
                            502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );
                        Logger.LogError("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }

                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete PATCH request. An error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogInformation("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }
            
                    Logger.LogInformation("MFI PUT Request completed for: {Endpoint}", endpoint);
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Exception: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                    throw;
                } catch (Exception ex) {
                    Logger.LogError("Unhandled Exception during PATCH to {endpoint}: {Message}", endpoint, ex.Message);
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
                    throw;
                }
            }
        }
        
        public async Task<MfiHttpResponse<TResponse>> DeleteAsync<TResponse>(string endpoint) where TResponse : class {
             using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {

                try {
                    Logger.LogInformation("DELETE Request to: {Endpoint}", endpoint);
                
                    //..formulate URL
                    var fullUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("MIDDLEWARE URL: {FullUrl}", fullUrl);

                    //..send delete request
                    var response = await MfiHttpClient.DeleteAsync(endpoint);
                    if(response == null) { 
                        var error = new MfiHttpErrorResponse( 502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );

                        Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

                    //..we received a response
                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);

                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete request. An Error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogInformation("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }
        
                    //..read and deserialize response
                    var responseData = await response.Content.ReadAsStringAsync();
                    Logger.LogInformation("DELETE Response received from: {Endpoint}", endpoint);
                    Logger.LogInformation("MFI Midleware data : {Data}", responseData);
                    try {

                        Logger.LogInformation("Starting deserialization...");
                        var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, JsonOptions);
    
                        if (result == null) {
                            Logger.LogInformation("Deserialization returned null");
                            var error = new MfiHttpErrorResponse( 500,
                                "System Data Error",
                                "Deserialization returned null"
                            );
                            return new MfiHttpResponse<TResponse>(error);
                        }
    
                        Logger.LogInformation("Deserialization successful. HasError: {HasError}", result.HasError);
                        Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, JsonOptions));
                        return result;
                    } catch (JsonException jex) {
                        Logger.LogError("Deserialization Failed: {Message}", jex.Message);
                        var error = new MfiHttpErrorResponse(500,
                            "System Data Error",
                            $"Failed to deserialize response. An error has occurred"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    } catch (Exception ex) { 
                        Logger.LogInformation("Unexpected deserialization error: {Message}", ex.Message);
                        Logger.LogError("Exception Type: {Name}", ex.GetType().Name);
                        Logger.LogCritical("StackTrace: {StackTrace}", ex.StackTrace);
    
                        var error = new MfiHttpErrorResponse(
                            500,
                            "System Data Error",
                            $"Unexpected deserialization error: {ex.Message}"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    }
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                    var error = new MfiHttpErrorResponse(
                        502,
                        "Network error occurred",
                        httpEx.Message
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                    Logger.LogError("Request timeout");
                    Logger.LogError("{StackTrace}", timeoutEx.StackTrace);
                    var error = new MfiHttpErrorResponse(406,
                        "Request timeout",
                        "The request took too long to complete"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (JsonException jsonEx) {
                    Logger.LogError("JSON Deserialization Error: {Message}", jsonEx.Message);
                    Logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
                    var error = new MfiHttpErrorResponse(500,
                        "Ooops! Sorry, something went wrong",
                        "Data format error. Could not format data"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (Exception ex)  {
                    Logger.LogError("Unexpected Error: {Message}", ex.Message);    
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
                    var error = new MfiHttpErrorResponse( 500,
                        "An unexpected error occurred",
                        "Cannot proceed! An error occurred, please try again later"
                    );
                    return new MfiHttpResponse<TResponse>(error);
                }
            }
        }

        public async Task DeleteAllAsync(string endpoint) {
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {
                try {
                    Logger.LogInformation("MFI DELETE Request (no response) to: {Endpoint}", endpoint);
            
                    var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("REQUEST URL: {RequestUrl}", requestUrl);

                    var response = await MfiHttpClient.DeleteAsync(endpoint);
                    if (response == null) {
                        var error = new MfiHttpErrorResponse(
                            502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );
                        Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }

                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogInformation("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);
                        var error = new MfiHttpErrorResponse(
                            (int)response.StatusCode,
                            "Could not complete PATCH request. An error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogError("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }
            
                    Logger.LogInformation("MFI DELETE Request completed for: {Endpoint}", endpoint);
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Exception: {Massage}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
                    throw;
                } catch (Exception ex) {
                    Logger.LogError("Unhandled Exception during DELETEALL to {Endpoint}: {Message}", endpoint, ex.Message);
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
                    throw;
                }
            }
        }

        public async Task<MfiHttpResponse<TResponse>> SendAsync<TResponse>(HttpMethod method, string endpoint, object requestBody = null) where TResponse: class {
            
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {

                try  {
                    Logger.LogInformation("{Method} Request to: {Endpoint}", method.Method, endpoint);
            
                    //..formulate URL
                    var fullUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("MIDDLEWARE URL: {FullUrl}", fullUrl);

                    //..send request
                    var request = new HttpRequestMessage(method, endpoint);
                    if (requestBody != null) {
                        var jsonContent = JsonSerializer.Serialize(requestBody, JsonOptions);
                        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        Logger.LogInformation("REQUEST MAP: {RequestBody}", JsonSerializer.Serialize(requestBody));
                    }
            
                     //..send request
                    var response = await MfiHttpClient.SendAsync(request);
                    if(response == null) { 
                        var error = new MfiHttpErrorResponse(
                            502,
                            "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );

                        Logger.LogInformation("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }

                    //..we received a response
                    Logger.LogInformation("Response Status: {StatusCode}",response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogInformation("Middleware call failed with status: {Status}", (int)response.StatusCode);

                        var error = new MfiHttpErrorResponse((int)response.StatusCode,
                            "Could not complete request. An Error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogInformation("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        return new MfiHttpResponse<TResponse>(error);
                    }
        
                    //..read and deserialize response
                    var responseData = await response.Content.ReadAsStringAsync();
                    Logger.LogInformation("{Method} Response received from: {Endpoint}", method.Method, endpoint);
                    Logger.LogInformation("MFI Midleware data : {Data}", responseData);
            
                    try {

                        Logger.LogInformation("Starting deserialization...");
                        var result = JsonSerializer.Deserialize<MfiHttpResponse<TResponse>>(responseData, JsonOptions);
    
                        if (result == null) {
                            Logger.LogInformation("Deserialization returned null");
                            var error = new MfiHttpErrorResponse( 504,
                                "Failed Dependency",
                                "Deserialization returned null"
                            );
                            return new MfiHttpResponse<TResponse>(error);
                        }
    
                        Logger.LogInformation("Deserialization successful. HasError: {HasError}", result.HasError);
                        Logger.LogInformation("SERVICE RESULT: {Result}", JsonSerializer.Serialize(result, JsonOptions));
                        return result;
                    } catch (JsonException jex) {
                        Logger.LogError("Deserialization Failed: {Message}", jex.Message);
                        var error = new MfiHttpErrorResponse(417,
                            "System Data Error",
                            $"Failed to deserialize response. An error has occurred"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    } catch (Exception ex) { 
                        Logger.LogInformation("Unexpected deserialization error: {Message}", ex.Message);
                        Logger.LogError("Exception Type: {Name}", ex.GetType().Name);
                        Logger.LogCritical("{StackTrace}", ex.StackTrace);
    
                        var error = new MfiHttpErrorResponse(
                            424, "Failed Depedency",
                            $"Unexpected deserialization error: {ex.Message}"
                        );
                        return new MfiHttpResponse<TResponse>(error);
                    }
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Error: {Message}", httpEx.Message);
                    Logger.LogCritical("{StackTrace}", httpEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(
                        504,
                        "Network error occurred",
                        httpEx.Message
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (TaskCanceledException timeoutEx) when (timeoutEx.InnerException is TimeoutException) {
                    Logger.LogError("Request timeout: {Message}", timeoutEx.InnerException.Message);  
                    Logger.LogCritical("{StackTrace}", timeoutEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(406,
                        "Request timeout", "The request took too long to complete"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (JsonException jsonEx) {
                    Logger.LogError("Json Error: {Message}", jsonEx.Message);  
                    Logger.LogCritical("{StackTrace}", jsonEx.StackTrace);
        
                    var error = new MfiHttpErrorResponse(417,
                        "Expectation Failed", "Data format error. Could not format data"
                    );
                    return new MfiHttpResponse<TResponse>(error);
        
                } catch (Exception ex)  {
                    Logger.LogError("Unexpected Error: {Message}", ex.Message);    
                    Logger.LogCritical("{StackTrace}", ex.StackTrace);
        
                    var error = new MfiHttpErrorResponse(500,
                        "An unexpected error occurred",
                        "Cannot proceed! An error occurred, please try again later"
                    );
                    return new MfiHttpResponse<TResponse>(error);
                }
            }

        }

        public async Task SendAsync(HttpMethod method, string endpoint, object requestBody = null) {
            using (Logger.BeginScope(new { Channel = "HTTP-HANDLER", Id = LOG_ID })) {

                try  {
                    Logger.LogInformation("{Method} Request (no response) to: {Endpoint}", method.Method, endpoint);
                
                    var request = new HttpRequestMessage(method, endpoint);
                    if (requestBody != null) {
                        var jsonContent = JsonSerializer.Serialize(requestBody, JsonOptions);
                        request.Content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                        Logger.LogInformation("REQUEST MAP: {RequestBody}", JsonSerializer.Serialize(requestBody));
                    }

                    var requestUrl = $"{MfiHttpClient.BaseAddress?.ToString().TrimEnd('/')}/{endpoint.TrimStart('/')}";
                    Logger.LogInformation("REQUEST URL: {RequestUrl}", requestUrl);
            
                    var response = await MfiHttpClient.SendAsync(request);
                    if (response == null) {
                        var error = new MfiHttpErrorResponse(502, "Bad Gateway or possible timeout",
                            "The middleware service did not respond or service timeout occurred"
                        );
                        Logger.LogError("BAD GATEWAY: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }

                    Logger.LogInformation("Response Status: {StatusCode}", response.StatusCode);
                    if (!response.IsSuccessStatusCode) {
                        Logger.LogError("Middleware call failed with status: {StatusCode}", (int)response.StatusCode);

                        var error = new MfiHttpErrorResponse((int)response.StatusCode,
                            "Could not complete PATCH request. An error occurred",
                            $"HTTP Status Code: {response.StatusCode}"
                        );

                        Logger.LogCritical("SERVICE ERROR: {Error}", JsonSerializer.Serialize(error));
                        throw new HttpRequestException(error.ToString());
                    }
            
                    Logger.LogInformation("{Method} Request completed for: {endpoint}", method.Method, endpoint);
                } catch (HttpRequestException httpEx) {
                    Logger.LogError("HTTP Request Exception: {Message}", httpEx.Message);
                    Logger.LogCritical( "{StackTrace}",httpEx.StackTrace);
                    throw;
                } catch (Exception ex)  {
                    Logger.LogError("HTTP Request Exception: {Message}", ex.Message);
                    Logger.LogCritical( "{StackTrace}",ex.StackTrace);
                    throw;
                }
            }
            
        }
        
    }
}
