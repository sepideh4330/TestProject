using System.Collections.Generic;

namespace Project.Common.Utilities.DtoHelper
{
    public static class DtoResponseExtensions
    {
        public static T ReturnWithCode<T>(this T response, int code, Dictionary<int, string> messages) where T : DtoResponse
        {
            response.ResultCode = code;
            messages.TryGetValue(code, out var message);
            response.Message = message;
            return response;
        }
        public static T ReturnWithCode<T>(this T response, int code, string parameter, Dictionary<int, string> messages) where T : DtoResponse
        {
            response.ResultCode = (int)code;
            messages.TryGetValue(code, out var message);
            response.Message = string.Format(message, parameter);
            return response;
        }
        public static T ReturnMaRobotError<T>(this T response, int errorCode) where T : DtoResponse
        {
            response.ResultCode = -1;
            response.Message = "خطای ربات فعال سازی با کد " + errorCode;
            return response;
        }
        public static T ReturnWithCode<T>(this T response, int code, string parameter1, string parameter2, Dictionary<int, string> messages) where T : DtoResponse
        {
            response.ResultCode = (int)code;
            messages.TryGetValue(code, out var message);
            response.Message = string.Format(message, parameter1, parameter2);
            return response;
        }
        public static void SetResultCode<T>(this T response, int code, Dictionary<int, string> messages) where T : DtoResponse
        {
            response.ResultCode = code;
            messages.TryGetValue(code, out var message);
            response.Message = message;
        }
    }
}
