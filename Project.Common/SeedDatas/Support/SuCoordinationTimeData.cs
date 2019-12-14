using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.Support.Models;

namespace Project.Common.SeedDatas.Support
{
    public class SuCoordinationTimeData
    {
        private static readonly Lazy<IEnumerable<SuCoordinationTimeDataModel>> SystemSuCoordinationTimesLazy =
            new Lazy<IEnumerable<SuCoordinationTimeDataModel>>
                (GetSuCoordinationTimes, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<SuCoordinationTimeDataModel> GetSuCoordinationTimes()
        {
            return new List<SuCoordinationTimeDataModel>
            {
                new SuCoordinationTimeDataModel(9,11,100,100),
                new SuCoordinationTimeDataModel(11,13,100,100),
                new SuCoordinationTimeDataModel(13,15,100,100),
                new SuCoordinationTimeDataModel(15,17,100,100),
                new SuCoordinationTimeDataModel(17,19,100,100),
                new SuCoordinationTimeDataModel(19,21,100,100),
                new SuCoordinationTimeDataModel(21,23,100,100),

                new SuCoordinationTimeDataModel(9,11,100,200),
                new SuCoordinationTimeDataModel(11,13,100,200),
                new SuCoordinationTimeDataModel(13,15,100,200),
                new SuCoordinationTimeDataModel(15,17,100,200),
                new SuCoordinationTimeDataModel(17,19,100,200),
                new SuCoordinationTimeDataModel(19,21,100,200),
                new SuCoordinationTimeDataModel(21,23,100,200),
            };
        }

        public static IEnumerable<SuCoordinationTimeDataModel> GetAll => SystemSuCoordinationTimesLazy.Value;
    }
}
