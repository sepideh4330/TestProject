using System;

namespace Project.Common.Extensions
{
    public static class GuidExtensions
    {
        public static bool IsEmpty(this Guid guid)
        {
            return default(Guid) == guid;
        }
        public static string GetCleanGuidValue(this Guid guid)
        {
            return guid.ToString("N");
        }
    }
}
