using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Project.Common.Utilities.StringModelBinderProvider
{
    public class CustomStringModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.IsComplexType)
            {
                return null;
            }

            var fallbackBinder = new SimpleTypeModelBinder(context.Metadata.ModelType);
            if (context.Metadata.ModelType == typeof(string))
            {
                return new CustomStringModelBinder(fallbackBinder);
            }
            return fallbackBinder;
        }
    }
}
