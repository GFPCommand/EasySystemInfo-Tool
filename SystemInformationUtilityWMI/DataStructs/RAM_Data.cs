using System.Collections.Generic;
using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct RAM_Data
    {
        public short Attributes;

        public List<long> Capacity = new();
        public List<int> Speed = new();
        public List<float> ConfiguredVoltage = new();
        public List<int> DataWidth = new();
        public List<int> FormFactor = new();
        public List<string> PartNumber = new();
        public List<string> Manufacturer = new();

        private const string _unknownText = "Unknown";

        public RAM_Data(ManagementObjectSearcher searcher)
        {
            foreach (var item in searcher.Get())
            {
                Attributes = short.Parse(item["Attributes"]?.ToString() ?? "0");

                Capacity.Add(long.Parse(item["Capacity"]?.ToString() ?? "0"));
                Speed.Add(int.Parse(item["Speed"]?.ToString() ?? "0"));
                ConfiguredVoltage.Add(float.Parse(item["ConfiguredVoltage"]?.ToString() ?? "0"));
                DataWidth.Add(int.Parse(item["DataWidth"]?.ToString() ?? "0"));
                FormFactor.Add(int.Parse(item["FormFactor"]?.ToString() ?? "0"));
                PartNumber.Add(item["PartNumber"]?.ToString() ?? _unknownText);
                Manufacturer.Add(item["Manufacturer"]?.ToString() ?? _unknownText);
            }
        }
    }
}
