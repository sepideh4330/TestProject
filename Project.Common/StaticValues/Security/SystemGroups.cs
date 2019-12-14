using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Project.Common.StaticValues.Security.Models;

namespace Project.Common.StaticValues.Security
{
    public class SystemGroups
    {
        private static readonly List<string> RolesList = new List<string>();
        private static readonly List<string> ShopOrderRobotRolesList = new List<string>();

        private static readonly Lazy<IEnumerable<SystemGroupItem>> SystemGroupsLazy = new Lazy
            <IEnumerable<SystemGroupItem>>(
                GetSystemGroups, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<SystemGroupItem> GetSystemGroups()
        {
            var admin = 1200;
            var general = 1100;

            RolesList.AddRange(SystemRoles.GetAll.Select(d => d.Name));
            ShopOrderRobotRolesList.Add(SystemRoles.ShopOrderRobot);

            return new List<SystemGroupItem>
            {
                new SystemGroupItem(SuperAdministrator,"مدیر کل سایت","این سطح دسترسی به تمامی بخش های مدیریت کاربران سایت دسترسی دارد",RolesList,admin),
                new SystemGroupItem(ShopOrderRobot,"ربات سفارش فروشگاه","این سطح دسترسی سفارش فروشگاه دسترسی دارد",ShopOrderRobotRolesList,general),
            };
        }

        public static IEnumerable<SystemGroupItem> GetAll => SystemGroupsLazy.Value;

        public const string SuperAdministrator = "SuperAdministrator";
        public const string ShopOrderRobot = "ShopOrderRobot";
    }
}
