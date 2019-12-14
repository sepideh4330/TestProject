using System;
using System.Collections.Generic;
using System.Threading;
using Project.Common.SeedDatas.MassInstallation.Models;

namespace Project.Common.SeedDatas.MassInstallation
{
    public class MiContradictionPlanData
    {
        private static readonly Lazy<IEnumerable<MiContradictionPlanDataModel>> SystemMiContradictionPlansLazy =
            new Lazy<IEnumerable<MiContradictionPlanDataModel>>
                (GetMiContradictionPlans, LazyThreadSafetyMode.ExecutionAndPublication);

        private static IEnumerable<MiContradictionPlanDataModel> GetMiContradictionPlans()
        {
            return new List<MiContradictionPlanDataModel>
            {
                new MiContradictionPlanDataModel("بسته کامل - امانی",100),
                new MiContradictionPlanDataModel("بسته کامل - 360",100),
                new MiContradictionPlanDataModel("بسته کامل امانی",100),
                new MiContradictionPlanDataModel("بسته کامل امانی سرویس 360",100),
                new MiContradictionPlanDataModel("مهاجرت سیم کارت - امانی",300),
                new MiContradictionPlanDataModel("مهاجرت سیم کارت نقدی",300),
                new MiContradictionPlanDataModel("مهاجرت سیم کارت",300),
                new MiContradictionPlanDataModel("مهاجرت مودم و سیم کارت - امانی",200),
                new MiContradictionPlanDataModel("مهاجرت مودم و سیم کارت امانی",200),
                new MiContradictionPlanDataModel("مهاجرت مودم و سیم کارت",200),
            };
        }

        public static IEnumerable<MiContradictionPlanDataModel> GetAll => SystemMiContradictionPlansLazy.Value;
    }
}
