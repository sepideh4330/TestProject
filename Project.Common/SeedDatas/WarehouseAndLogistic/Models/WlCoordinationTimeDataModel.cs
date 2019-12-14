namespace Project.Common.SeedDatas.WarehouseAndLogistic.Models
{
    public class WlCoordinationTimeDataModel
    {
        public int StartTime { get; set; }

        public int EndTime { get; set; }

        public int WlCoordinationTimeStatus { get; set; }

        public WlCoordinationTimeDataModel(int startTime, int endTime, int wlCoordinationTimeStatus)
        {
            StartTime = startTime;
            EndTime = endTime;
            WlCoordinationTimeStatus = wlCoordinationTimeStatus;
        }
    }
}
