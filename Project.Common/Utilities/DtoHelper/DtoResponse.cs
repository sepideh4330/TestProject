namespace Project.Common.Utilities.DtoHelper
{
    public abstract class DtoResponse
    {
        public int ResultCode { get; set; }

        public string Message { get; set; }
    }
}
