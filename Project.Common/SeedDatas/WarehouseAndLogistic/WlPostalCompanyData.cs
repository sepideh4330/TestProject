using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.WarehouseAndLogistic.Models;

namespace Project.Common.SeedDatas.WarehouseAndLogistic
{
    public class WlPostalCompanyData
    {
        private static readonly Lazy<IEnumerable<WlPostalCompanyDataModel>> SystemMiCoordinationTimesLazy =
            new Lazy<IEnumerable<WlPostalCompanyDataModel>>
                (GetMiCoordinationTimes, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<WlPostalCompanyDataModel> GetMiCoordinationTimes()
        {
            return new List<WlPostalCompanyDataModel>
            {
                new WlPostalCompanyDataModel("شرکت پست تی پی جی","02154782000","09121542154",100),
                new WlPostalCompanyDataModel("شرکت پست ج.م.ا.ا","02188431140","09124141212",100),
                new WlPostalCompanyDataModel("شرکت پست تیپاکس","0218457","09126425121",100),
            };
        }

        public static IEnumerable<WlPostalCompanyDataModel> GetAll => SystemMiCoordinationTimesLazy.Value;
    }
}
