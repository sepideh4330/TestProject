namespace Project.Common.SeedDatas.RedemptionEquipment.Models
{
    public class ReCoordinationTimeDataModel
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int ReCoordinationTimeStatus { get; set; }

        public ReCoordinationTimeDataModel(int startTime, int endTime, int reCoordinationTimeStatus)
        {
            StartTime = startTime;
            EndTime = endTime;
            ReCoordinationTimeStatus = reCoordinationTimeStatus;
        }
    }
}
