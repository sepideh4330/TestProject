namespace Project.Common.SeedDatas.WarehouseAndLogistic.Models
{
    public class WlPostalCompanyDataModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        public int WlPostalCompanyStatus { get; set; }

        public WlPostalCompanyDataModel(string name, string phoneNumber, string mobileNumber,int wlPostalCompanyStatus)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            MobileNumber = mobileNumber;
            WlPostalCompanyStatus = wlPostalCompanyStatus;
        }
    }
}
