using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.WarehouseAndLogistic.Models;

namespace Project.Common.SeedDatas.WarehouseAndLogistic
{
    public class WlCoordinationTimeData
    {
        private static readonly Lazy<IEnumerable<WlCoordinationTimeDataModel>> SystemMiCoordinationTimesLazy =
            new Lazy<IEnumerable<WlCoordinationTimeDataModel>>
                (GetMiCoordinationTimes, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<WlCoordinationTimeDataModel> GetMiCoordinationTimes()
        {
            return new List<WlCoordinationTimeDataModel>
            {
                new WlCoordinationTimeDataModel(9,13,100),
                new WlCoordinationTimeDataModel(13,17,100),
            };
        }

        public static IEnumerable<WlCoordinationTimeDataModel> GetAll => SystemMiCoordinationTimesLazy.Value;
    }
}
