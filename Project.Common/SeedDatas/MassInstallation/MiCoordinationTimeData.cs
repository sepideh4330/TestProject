using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.MassInstallation.Models;

namespace Project.Common.SeedDatas.MassInstallation
{
    public class MiCoordinationTimeData
    {
        private static readonly Lazy<IEnumerable<MiCoordinationTimeDataModel>> SystemMiCoordinationTimesLazy = 
            new Lazy<IEnumerable<MiCoordinationTimeDataModel>>
                (GetMiCoordinationTimes, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<MiCoordinationTimeDataModel> GetMiCoordinationTimes()
        {
            return new List<MiCoordinationTimeDataModel>
            {
                new MiCoordinationTimeDataModel(9,11,100),
                new MiCoordinationTimeDataModel(11,13,100),
                new MiCoordinationTimeDataModel(13,15,100),
                new MiCoordinationTimeDataModel(15,17,100),
                new MiCoordinationTimeDataModel(17,19,100),
                new MiCoordinationTimeDataModel(19,21,100),
                new MiCoordinationTimeDataModel(21,23,100)
            };
        }

        public static IEnumerable<MiCoordinationTimeDataModel> GetAll => SystemMiCoordinationTimesLazy.Value;
    }
}
