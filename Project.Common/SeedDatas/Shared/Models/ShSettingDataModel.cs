namespace Project.Common.SeedDatas.Shared.Models
{
    public class ShSettingDataModel
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public int ShSettingType { get; set; }

        public int ShSettingCategory { get; set; }

        public int ShSettingGroup { get; set; }

        public ShSettingDataModel(string key, string value, string description, int shSettingType,int shSettingCategory,int shSettingGroup)
        {
            Key = key;
            Value = value;
            Description = description;
            ShSettingType = shSettingType;
            ShSettingCategory = shSettingCategory;
            ShSettingGroup = shSettingGroup;
        }
    }
}
