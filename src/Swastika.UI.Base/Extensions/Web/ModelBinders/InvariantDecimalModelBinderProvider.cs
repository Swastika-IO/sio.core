using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace Swastika.UI.Base.Extensions.Web.ModelBinders {

    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider" />
    public class InvariantDecimalModelBinderProvider : IModelBinderProvider {

        /// <summary>
        /// Creates a <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" /> based on <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.</param>
        /// <returns>
        /// An <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" />.
        /// </returns>
        /// <exception cref="System.ArgumentNullException">context</exception>
        public IModelBinder GetBinder(ModelBinderProviderContext context) {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (!context.Metadata.IsComplexType && (context.Metadata.ModelType == typeof(decimal) || context.Metadata.ModelType == typeof(decimal?))) {
                return new InvariantDecimalModelBinder(context.Metadata.ModelType);
            }

            return null;
        }
    }
}