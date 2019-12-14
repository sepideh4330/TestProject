namespace Project.Common.SeedDatas.Support.Models
{
    public class SuCoordinationTimeDataModel
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int SuCoordinationTimeStatus { get; set; }

        public int SuCoordinationInstallationType { get; set; }

        public SuCoordinationTimeDataModel(int startTime, int endTime, int suCoordinationTimeStatus,int suCoordinationInstallationType)
        {
            StartTime = startTime;
            EndTime = endTime;
            SuCoordinationTimeStatus = suCoordinationTimeStatus;
            SuCoordinationInstallationType = suCoordinationInstallationType;
        }
    }
}
