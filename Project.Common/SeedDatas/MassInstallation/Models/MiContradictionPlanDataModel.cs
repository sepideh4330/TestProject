namespace Project.Common.SeedDatas.MassInstallation.Models
{
    public class MiContradictionPlanDataModel
    {
        public string Is { get; set; }

        public int As { get; set; }

        public MiContradictionPlanDataModel(string miContradictionPlanIs, int miContradictionPlanAs)
        {
            Is = miContradictionPlanIs;
            As = miContradictionPlanAs;
        }
    }
}
