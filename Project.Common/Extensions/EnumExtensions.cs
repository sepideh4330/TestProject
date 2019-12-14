using System;

namespace Project.Common.Extensions
{
    public static class EnumExtensions
    {
        public static int Value(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}