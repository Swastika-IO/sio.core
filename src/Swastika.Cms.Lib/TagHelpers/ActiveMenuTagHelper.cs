// Licensed to the Swastika I/O Foundation under one or more agreements.
// The Swastika I/O Foundation licenses this file to you under the GNU General Public License v3.0 license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Swastika.Web.Start.TagHelpers
{
    [HtmlTargetElement(Attributes = "is-active-menu")]
    public class ActiveMenuTagHelper : TagHelper
    {
        /// <summary>The name of the controller.</summary>
        /// <remarks>Must be <c>null</c> if <see cref="P:Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper.Route" /> is non-<c>null</c>.</remarks>
        [HtmlAttributeName("asp-controllers")]
        public string Controllers { get; set; }

        [HtmlAttributeName("asp-action")]
        public string Actions { get; set; }

        [HtmlAttributeName("asp-route-pagenames")]
        public string PageNames { get; set; }

        [HtmlAttributeName("asp-route-id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.AspNetCore.Mvc.Rendering.ViewContext" /> for the current request.
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public IDictionary<string, string> RouteValues { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (ShouldBeActive())
            {
                MakeActive(output);
            }

            output.Attributes.RemoveAll("is-active-menu");
        }

        private bool ShouldBeActive()
        {
            bool rtn = false;
            string currentController = ViewContext.RouteData.Values["Controller"].ToString();

            string currentAction = ViewContext.RouteData.Values["Action"].ToString();
            string id = ViewContext.RouteData.Values["Id"] != null ? ViewContext.RouteData.Values["Id"].ToString() : string.Empty;
            string currentPagename = ViewContext.RouteData.Values["pageName"] != null ? ViewContext.RouteData.Values["pageName"].ToString() : string.Empty;

            List<string> activeControllers = string.IsNullOrEmpty(Controllers) ? new List<string>() : Controllers.ToLower().Split(',').ToList();
            List<string> activeActions = string.IsNullOrEmpty(Actions) ? new List<string>() : Actions.ToLower().Split(',').ToList();
            List<string> activePageNames = string.IsNullOrEmpty(PageNames) ? new List<string>() : PageNames.ToLower().Split(',').ToList();
            if (!string.IsNullOrWhiteSpace(Controllers))
            {
                rtn = (string.IsNullOrEmpty(Actions) && string.IsNullOrEmpty(PageNames) && activeControllers.Contains(currentController.ToLower()))
                    || (
                    activeControllers.Contains(currentController.ToLower()) // Current Controller
                    && activeActions.Contains(currentAction.ToLower()) // Current Action
                    && (string.IsNullOrEmpty(Id) || id == Id) // Current Details
                    && (string.IsNullOrEmpty(PageNames) || activePageNames.Contains(currentPagename.ToLower()))
                    );
            }

            //if (!string.IsNullOrWhiteSpace(Controllers))
            //{
            //    foreach (string controller in Controllers.Split(','))
            //    {
            //        if (currentController.ToLower() == controller.ToLower())
            //        {
            //            rtn = true;
            //            break;
            //        }
            //    }

            //}

            return rtn;
        }

        private void MakeActive(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "active");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active") < 0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null
                    ? "active"
                    : classAttr.Value + " active");
            }
        }
    }
}
