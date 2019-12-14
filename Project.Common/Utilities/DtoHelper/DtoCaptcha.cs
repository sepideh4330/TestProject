using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Common.Utilities.DtoHelper
{
    public abstract class DtoCaptcha : IValidatableObject
    {
        public string Captcha { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validate = new List<ValidationResult>();
            return validate;
            //using (var webClient = new WebClient())
            //{
            //    var validateStringUrl =
            //        $"https://www.google.com/recaptcha/api/siteverify?secret=6LcJraYUAAAAAPr6ty-benw4NLxeqoB0q2e79zd1&response={Captcha}";
            //    try
            //    {
            //        var recaptchaResult = webClient.DownloadString(validateStringUrl);
            //        if (recaptchaResult.ToLower().Contains("false"))
            //        {
            //            validate.Add(new ValidationResult(
            //                "کد امنیتی معتبر نمی باشد",
            //                new[] { nameof(Captcha) }));
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        validate.Add(new ValidationResult(
            //            "کد امنیتی معتبر نمی باشد",
            //            new[] { nameof(Captcha) }));
            //    }

            //}
            //return validate;
        }
    }
}