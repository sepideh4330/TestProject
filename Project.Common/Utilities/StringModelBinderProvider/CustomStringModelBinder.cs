using System;
using System.Threading.Tasks;
using DNTPersianUtils.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Project.Common.Utilities.StringModelBinderProvider
{
    public class CustomStringModelBinder : IModelBinder
    {
        private readonly IModelBinder _fallbackBinder;
        public CustomStringModelBinder(IModelBinder fallbackBinder)
        {
            _fallbackBinder = fallbackBinder ?? throw new ArgumentNullException(nameof(fallbackBinder));
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != ValueProviderResult.None)
            {
                bindingContext.ModelState.SetModelValue(bindingContext.ModelName, valueProviderResult);

                var valueAsString = valueProviderResult.FirstValue;
                if (string.IsNullOrWhiteSpace(valueAsString))
                {
                    return _fallbackBinder.BindModelAsync(bindingContext);
                }

                var model = valueAsString.ApplyCorrectYeKe();
                bindingContext.Result = ModelBindingResult.Success(model);
                return Task.CompletedTask;
            }

            return _fallbackBinder.BindModelAsync(bindingContext);
        }
    }
}