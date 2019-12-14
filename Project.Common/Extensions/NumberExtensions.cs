namespace Project.Common.Extensions
{
    public static class NumberExtensions
    {
        public static string ToRial(this long value)
        {
            return (value == 0 ? "0" : value.ToString("#,#")) + " ریال";
        }

        public static string SplitThreeTimes(this long value)
        {
            return value == 0 ? "0" : value.ToString("#,#");
        }
    }
}