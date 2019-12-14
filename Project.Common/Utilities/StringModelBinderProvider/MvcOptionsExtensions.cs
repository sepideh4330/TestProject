using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Project.Common.Utilities.StringModelBinderProvider
{
    public static class MvcOptionsExtensions
    {
        public static MvcOptions UseCustomStringModelBinder(this MvcOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            var simpleTypeModelBinder = options.ModelBinderProviders.FirstOrDefault(x => x.GetType() == typeof(SimpleTypeModelBinderProvider));
            if (simpleTypeModelBinder == null)
            {
                return options;
            }

            var simpleTypeModelBinderIndex = options.ModelBinderProviders.IndexOf(simpleTypeModelBinder);
            options.ModelBinderProviders.Insert(simpleTypeModelBinderIndex, new CustomStringModelBinderProvider());
            return options;
        }
    }
}
