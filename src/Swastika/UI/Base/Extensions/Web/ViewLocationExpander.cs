using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.UI.Base.Extensions.Web {

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander" />
    public class ViewLocationExpander : IViewLocationExpander {

        /// <summary>
        /// The constant string ext key
        /// </summary>
        private const string CONST_STR_EXT_KEY = "extension";

        /// <summary>
        /// The constant string ext prefix
        /// </summary>
        private const string CONST_STR_EXT_PREFIX = "swastika.extension";

        /// <summary>
        /// Invoked by a <see cref="T:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine" /> to determine potential locations for a view.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext" /> for the current view location
        /// expansion operation.</param>
        /// <param name="viewLocations">The sequence of view locations to expand.</param>
        /// <returns>
        /// A list of expanded view locations.
        /// </returns>
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations) {
            if (context.Values.ContainsKey(CONST_STR_EXT_KEY)) {
                var extension = context.Values[CONST_STR_EXT_KEY];
                if (!string.IsNullOrWhiteSpace(extension) && extension.ToLower().Contains(CONST_STR_EXT_PREFIX)) {
                    var moduleViewLocations = new string[]
                    {
                        ExtensionManager.RelativePath.Replace("\\","/") + extension + "/Views/{1}/{0}.cshtml",
                        ExtensionManager.RelativePath.Replace("\\","/") + extension + "/Views/Shared/{0}.cshtml"
                    };

                    viewLocations = moduleViewLocations.Concat(viewLocations);
                }
            }
            return viewLocations;
        }

        /// <summary>
        /// Invoked by a <see cref="T:Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine" /> to determine the values that would be consumed by this instance
        /// of <see cref="T:Microsoft.AspNetCore.Mvc.Razor.IViewLocationExpander" />. The calculated values are used to determine if the view location
        /// has changed since the last time it was located.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Razor.ViewLocationExpanderContext" /> for the current view location
        /// expansion operation.</param>
        public void PopulateValues(ViewLocationExpanderContext context) {
            var controller = context.ActionContext.ActionDescriptor.DisplayName;

            int startPos = controller.LastIndexOf("(") + 1;
            int length = controller.IndexOf(")") - startPos;
            string extensionName = controller.Substring(startPos, length);

            context.Values[CONST_STR_EXT_KEY] = extensionName;
        }
    }
}