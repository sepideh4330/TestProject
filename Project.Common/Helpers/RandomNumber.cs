using System;

namespace Project.Common.Helpers
{
    public static class RandomNumber
    {
        private static readonly Random Getrandom = new Random();
        private static readonly object SyncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (SyncLock)
            { // synchronize
                return Getrandom.Next(min, max);
            }
        }
        public static int GetRandomNumber(int max)
        {
            lock (SyncLock)
            { // synchronize
                return Getrandom.Next(max);
            }
        }
        public static int GetRandomNumberLength(int length)
        {
            if (length == 3)
            {
                return GetRandomNumber(100, 999); 
            }
            if (length == 4)
            {
                return GetRandomNumber(1000, 9999);
            }
            if (length == 5)
            {
                return GetRandomNumber(10000, 99999);
            }
            if (length == 6)
            {
                return GetRandomNumber(100000, 999999);
            }
            throw new Exception("Invalid RandomNumberLength");
        }
    }
}
