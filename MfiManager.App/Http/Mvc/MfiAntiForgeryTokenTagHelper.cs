using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MfiManager.App.Http.Mvc {

    /// <summary>
    /// MFI TagHelper class that provides a more declarative way to include ant-forgery token in views
    /// </summary>
    /// <remarks>
    /// <mfi-antiforgery-token></mfi-antiforgery-token> -- Simple usage as Hidden input
    /// <mfi-antiforgery-token as-meta="true"></mfi-antiforgery-token>  -- use as meta tag in page header
    /// <mfi-antiforgery-token auto-detect="true"></mfi-antiforgery-token> -- checks ViewBag, 
    /// add  ViewBag.UseAjax = true; to endpoint This will make auto-detect render as meta
    /// </remarks>
    [HtmlTargetElement("mfi-antiforgery-token")]
    public class MfiAntiForgeryTokenTagHelper(IAntiforgery antiforgery, IActionContextAccessor actionContextAccessor) : TagHelper {
    private readonly IAntiforgery _antiforgery = antiforgery;
        private readonly IActionContextAccessor _actionContextAccessor = actionContextAccessor;

        /// <summary>
        /// Render as meta tag for AJAX (default: false = hidden input)
        /// </summary>
        [HtmlAttributeName("as-meta")]
        public bool AsMeta { get; set; } = false;

        /// <summary>
        /// Auto-detect based on ViewBag.UseAjax
        /// </summary>
        [HtmlAttributeName("auto-detect")]
        public bool AutoDetect { get; set; } = false;

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            var httpContext = _actionContextAccessor.ActionContext?.HttpContext;
            if (httpContext == null) {
                output.SuppressOutput();
                return;
            }

            var tokenSet = _antiforgery.GetAndStoreTokens(httpContext);

            //..determine if we should render as meta in page header
            bool renderAsMeta = AsMeta;
        
            if (AutoDetect) {
                var viewContext = _actionContextAccessor.ActionContext as ViewContext;
                if (viewContext?.ViewBag.UseAjax == true) {
                    renderAsMeta = true;
                }
            }

            if (renderAsMeta) {
                output.TagName = "meta";
                output.Attributes.SetAttribute("name", "csrf-token");
                output.Attributes.SetAttribute("content", tokenSet.RequestToken);
            } else {
                output.TagName = "input";
                output.Attributes.SetAttribute("type", "hidden");
                output.Attributes.SetAttribute("name", "__RequestVerificationToken");
                output.Attributes.SetAttribute("value", tokenSet.RequestToken);
            }
        }
    }
}
