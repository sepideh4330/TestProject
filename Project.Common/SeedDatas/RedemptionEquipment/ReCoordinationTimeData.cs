using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.RedemptionEquipment.Models;

namespace Project.Common.SeedDatas.RedemptionEquipment
{
    public class ReCoordinationTimeData
    {
        private static readonly Lazy<IEnumerable<ReCoordinationTimeDataModel>> SystemReCoordinationTimesLazy = 
            new Lazy<IEnumerable<ReCoordinationTimeDataModel>>
                (GetReCoordinationTimes, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<ReCoordinationTimeDataModel> GetReCoordinationTimes()
        {
            return new List<ReCoordinationTimeDataModel>
            {
                new ReCoordinationTimeDataModel(9,11,100),
                new ReCoordinationTimeDataModel(11,13,100),
                new ReCoordinationTimeDataModel(13,15,100),
                new ReCoordinationTimeDataModel(15,17,100),
                new ReCoordinationTimeDataModel(17,19,100),
                new ReCoordinationTimeDataModel(19,21,100),
                new ReCoordinationTimeDataModel(21,23,100)
            };
        }

        public static IEnumerable<ReCoordinationTimeDataModel> GetAll => SystemReCoordinationTimesLazy.Value;
    }
}