namespace Project.Common.SeedDatas.MassInstallation.Models
{
    public class MiCoordinationTimeDataModel
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int MiCoordinationTimeStatus { get; set; }

        public MiCoordinationTimeDataModel(int startTime, int endTime, int miCoordinationTimeStatus)
        {
            StartTime = startTime;
            EndTime = endTime;
            MiCoordinationTimeStatus = miCoordinationTimeStatus;
        }
    }
}
