using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.StaticValues.Security.Models;

namespace Project.Common.StaticValues.Security
{
    public class SystemUsers
    {
        private static readonly Lazy<IEnumerable<SystemUserItem>> SystemUsersLazy = new Lazy<IEnumerable<SystemUserItem>>(
            GetSystemUsers, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<SystemUserItem> GetSystemUsers()
        {
            return new List<SystemUserItem>
            {
                new SystemUserItem("09123360024", "dornevis", "آرمان", "دورودی", 200, "a.doroudi@dornevis.com", SystemGroups.SuperAdministrator),
                new SystemUserItem("09373624410", "dornevis", "زهرا", "نورمحمدی", 100, "z.noormohamadi@dornevis.com", SystemGroups.SuperAdministrator),
                new SystemUserItem("robot.shop", "dornevis", "ربات", "سفارش فروشگاه", 200, "robot.shop@dornevis.com", SystemGroups.SuperAdministrator),
                new SystemUserItem("robot", "dornevis", "Robot", "", 200, "robot@dornevis.com", SystemGroups.SuperAdministrator),
                //new SystemUserItem("09367604330", "dornevis", "سپیده", "خدادادی", 100, "s.Khodadadi@dornevis.com", SystemGroups.SuperAdministrator),
            };
        }

        public static IEnumerable<SystemUserItem> GetAll => SystemUsersLazy.Value;

    }
}
