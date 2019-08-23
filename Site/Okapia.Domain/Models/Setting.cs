namespace Okapia.Domain.Models
{
    public class Setting
    {
        public int SettingId { get; set; }
        public string SettingKey { get; set; }
        public string SettingValue { get; set; }

        public Setting()
        {
        }

        public Setting(string key, string value)
        {
            SettingKey = key;
            SettingValue = value;
        }
    }
}