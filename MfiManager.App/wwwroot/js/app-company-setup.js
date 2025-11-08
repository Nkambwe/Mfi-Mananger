$(function () {
    $(document).ready(function () {
        var $form = $('#installationform');
        var $steps = $('.form-step');
        var $stepNavs = $('.step-nav .step');
        var $prevBtn = $('.btn-prev');
        var $nextBtn = $('.btn-next');
        var $submitBtn = $('.btn-submit');
        var currentStep = 0;

        // Initialize
        showStep(currentStep);
        initializeLanguagesSelect2();
        initializeProviderSelect2();
        setupRealTimeValidation();

        // Step navigation
        $nextBtn.on('click', function () {
            if (validateStep(currentStep)) {
                currentStep++;
                showStep(currentStep);
            }
        });

        $prevBtn.on('click', function () {
            currentStep--;
            showStep(currentStep);
        });

        // Password toggle
        $('.password-toggle').on('click', function () {
            var $input = $(this).parent().find('input');
            var $icon = $(this).find('i');
            var type = $input.attr('type') === 'password' ? 'text' : 'password';
            $input.attr('type', type);
            $icon.toggleClass('mdi-eye mdi-eye-off');
        });

        // Language change reload
        $('#System_Language').on('change', function () {
            var lang = $(this).val();
            if (lang && lang !== 'None') {
                window.location.href = '/mfi/app-localize/language/' + lang;
            }
        });

        // Form submission
        $form.on('submit', function (e) {
            e.preventDefault();

            if (validateAllSteps()) {
                Swal.fire({
                    title: window.Localization.ConfirmTitle,
                    text: window.Localization.ConfirmMessage,
                    showCancelButton: true,
                    confirmButtonText: window.Localization.BtnOk,
                    cancelButtonText: window.Localization.BtnCancel
                }).then((result) => {
                    if (result.isConfirmed) {
                        submitFormWithAjax();
                    }
                });
            } else {
                Swal.fire({
                    title: window.Localization.InvalidTitle,
                    text: window.Localization.InvalidMessage,
                    confirmButtonColor: "#f41369",
                    confirmButtonText: window.Localization.BtnOk,
                });
            }
        });

        // ========== Select2 Initialization ==========

        function initializeLanguagesSelect2() {
            $(".language-select").select2({
                width: '100%',
                theme: 'default',
                dropdownCssClass: 'custom-select2-dropdown'
            });
        }

        function initializeProviderSelect2() {
            // Provider configuration data
            const providerConfig = {
                'SqlServer': {
                    minimumVersion: '2012',
                    versionCheckTime: '00:30:00'
                },
                'PostgreSQL': {
                    minimumVersion: '12',
                    versionCheckTime: '00:30:00'
                },
                'Oracle': {
                    minimumVersion: '21',
                    versionCheckTime: '00:30:00'
                }
            };

            // Initialize Select2
            $(".dbprovider-select").select2({
                width: '100%',
                theme: 'default',
                dropdownCssClass: 'custom-select2-dropdown'
            });

            // Handle provider selection change
            $(".dbprovider-select").on('select2:select', function (e) {
                const selectedProvider = e.params.data.id;
        
                if (selectedProvider && selectedProvider !== 'None' && providerConfig[selectedProvider]) {
                    // Set the minimum version
                    $('#DatabaseProviderMinimumVersion').val(providerConfig[selectedProvider].minimumVersion);
            
                    // Set the version check time
                    $('#DatabaseProviderVersionCheckTime').val(providerConfig[selectedProvider].versionCheckTime);
                } else {
                    // Clear fields if None is selected
                    $('#DatabaseProviderMinimumVersion').val('');
                    $('#DatabaseProviderVersionCheckTime').val('');
                }
            });

            // Set initial values if a provider is already selected (for page reload scenarios)
            const currentProvider = $('.dbprovider-select').val();
            if (currentProvider && currentProvider !== 'None' && providerConfig[currentProvider]) {
                $('#DatabaseProviderMinimumVersion').val(providerConfig[currentProvider].minimumVersion);
                $('#DatabaseProviderVersionCheckTime').val(providerConfig[currentProvider].versionCheckTime);
            }
        }

        // ========== Step Navigation ==========

        function showStep(stepIndex) {
            $steps.removeClass('active').eq(stepIndex).addClass('active');
            $stepNavs.removeClass('active completed').each(function (index) {
                if (index < stepIndex) $(this).addClass('completed');
                else if (index === stepIndex) $(this).addClass('active');
            });

            $prevBtn.prop('disabled', stepIndex === 0);
            $nextBtn.toggle(stepIndex !== $steps.length - 1);
            $submitBtn.toggle(stepIndex === $steps.length - 1);
        }

        // ========== Validation ==========

        function validateStep(stepIndex) {
            var isValid = true;
            var $fields = $steps.eq(stepIndex).find('[required]');
            $fields.each(function () {
                if (!validateField($(this))) isValid = false;
            });

            if (!isValid) {
                $('#validation-summary').removeClass('d-none');
                $('html, body').animate({
                    scrollTop: $steps.eq(currentStep).offset().top - 100
                }, 500);
            } else {
                $('#validation-summary').addClass('d-none');
            }

            return isValid;
        }

        function validateAllSteps() {
            for (var i = 0; i < $steps.length; i++) {
                if (!validateStep(i)) {
                    currentStep = i;
                    showStep(currentStep);
                    return false;
                }
            }
            return true;
        }

        function validateField($field) {
            var fieldId = $field.attr('id');
            var fieldName = $field.attr('name');
            var value = ($field.val() || '').trim();
            var $validationSpan = $(`[data-valmsg-for='${fieldName}']`);
            var isValid = true;
            var errorMessage = '';

            $field.removeClass('is-invalid is-valid');

            if ($field.attr('required') && !value) {
                isValid = false;
                errorMessage = window.Localization.Required;;
            } else if (value) {
                switch (fieldId) {
                    case 'Company_Name':
                        if (!validateAlphabetic(value)) {
                            isValid = false;
                            errorMessage = window.Localization.CompanyNameError;
                        }
                        break;

                    case 'Company_Alias':
                        if (!validateAlphanumeric(value)) {
                            isValid = false;
                            errorMessage = window.Localization.CompanyAliasError;
                        }
                        break;

                    case 'Registration_Number':
                        if (!validateAlphanumeric(value)) {
                            isValid = false;
                            errorMessage =  window.Localization.CompanyRegNoError;
                        }
                        break;

                    case 'Owner_FirstName':
                    case 'Owner_MidlleName':
                    case 'Owner_LastName':
                        if (!validateAlphabetic(value)) {
                            isValid = false;
                            errorMessage =  window.Localization.OwnerNameError;
                        }
                        break;

                    case 'Owner_Email':
                        if (!validateEmail(value)) {
                            isValid = false;
                            errorMessage =  window.Localization.OwnerEmailError;
                        }
                        break;

                    case 'Owner_Phone':
                        if (!validateNumeric(value)) {
                            isValid = false;
                            errorMessage = window.Localization.OwnerPhoneError;
                        }
                        break;

                    case 'User_UserName':
                        if (!validateAlphanumeric(value)) {
                            isValid = false;
                            errorMessage = window.Localization.OwnerUserNameError;
                        }
                        break;

                    case 'SystemPassword':
                        if (!validatePassword(value)) {
                            isValid = false;
                            errorMessage = window.Localization.PasswordError;
                        }
                        break;

                    case 'User_ConfirmPassword':
                        var password = $('#SystemPassword').val();
                        if (value !== password) {
                            isValid = false;
                            errorMessage = window.Localization.PasswordMatchError;
                        }
                        break;

                    case 'database_provider':
                        if (value === 'None') {
                            isValid = false;
                            errorMessage = window.Localization.DatabaseProviderError;
                        }
                        break;
                }
            }

            if (isValid) {
                $field.addClass('is-valid');
                $validationSpan.removeClass('show-error').text('');
            } else {
                $field.addClass('is-invalid');
                $validationSpan.addClass('show-error').text(errorMessage);
            }

            return isValid;
        }

        // ========== AJAX Submit ==========

        function submitFormWithAjax() {
            Swal.fire({
                title:  window.Localization.ProcessingTitle,
                text: window.Localization.ProcessingMessage,
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });

            $.ajax({
                url: '/mfi/app-install',
                type: 'POST',
                data: $form.serialize(),
                dataType: 'json',
                headers: {
                    'X-Requested-With': 'XMLHttpRequest',
                    'X-CSRF-TOKEN': getAntiForgeryToken()
                },
                success: function (response) {
                    const isSuccess = !response.sasError && response.data && response.data.status === true;

                    if (isSuccess) {
                        Swal.fire({
                            title: window.Localization.SuccessTitle,
                            text: response.data.message || window.Localization.SuccessMessage,
                            confirmButtonText: window.Localization.SuccessContinue,
                        }).then(() => {
                            window.location.href = response.redirectUrl || '/Application/Login';
                        });
                    } else {
                        Swal.fire({
                            title: window.Localization.FailedTitle,
                            text: response.data?.message ||  window.Localization.FailedMessage,
                            confirmButtonText: "OK"
                        });
                    }
                },
                error: function (xhr) {
                     Swal.close();

                    let errorMessage = window.Localization.ErrorMessage;
                    try {
                        let response = JSON.parse(xhr.responseText);
                        if (response.message) errorMessage = response.message;
                    } catch (e) { }
                    Swal.fire({
                        title:  window.Localization.ErrorTitle,
                        text:  errorMessage,
                        confirmButtonText: "OK"
                    });
                    console.error('Ajax error:', xhr.responseText);
                }
            });
        }

        // ========== Helpers ==========

        function handleServerValidationErrors(errors) {
            $('.field-validation-error').removeClass('show-error');
            $('.form-control').removeClass('is-invalid');

            if (errors) {
                $.each(errors, function (fieldName, errorMessages) {
                    var $field = $(`[name='${fieldName}']`);
                    var $validationSpan = $(`[data-valmsg-for='${fieldName}']`);

                    if ($field.length) $field.addClass('is-invalid');
                    if ($validationSpan.length && errorMessages.length > 0)
                        $validationSpan.addClass('show-error').text(errorMessages[0]);
                });
            }

            $('#validation-summary').removeClass('d-none');
        }

        function validateAlphabetic(value) { return /^[a-zA-Z\s]+$/.test(value); }
        function validateAlphanumeric(value) { return /^[a-zA-Z0-9]+$/.test(value); }
        function validateNumeric(value) { return /^\d+$/.test(value); }
        function validateEmail(value) { return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value); }
        function validatePassword(value) {
            return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/.test(value);
        }

        function getAntiForgeryToken() {
            return $('meta[name="csrf-token"]').attr('content');
        }

        function setupRealTimeValidation() {
            $form.find('input[required], select[required]').on('input change', function () {
                validateField($(this));
            });
        }
    });
});
