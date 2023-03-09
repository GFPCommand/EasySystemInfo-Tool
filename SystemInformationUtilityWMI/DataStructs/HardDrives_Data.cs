using System.Collections.Generic;
using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct HardDrives_Data
    {
        public List<string> Caption = new();
        public List<string> Description = new();
        public List<string> FileSystem = new();
        public List<long> FreeSpace = new();
        public List<string> Manufacturer = new();
        public List<string> Model = new();
        public List<string> Name = new();
        public List<long> Size = new();
        public List<string> VolumeName = new();
        public List<string> VolumeSerialNumber = new();

        private const string _unknownText = "Unknown";

        public HardDrives_Data(ManagementObjectSearcher hdSearcher, ManagementObjectSearcher ddSearcher)
        {
            foreach (var item in hdSearcher.Get())
            {
                Caption.Add(item["Caption"]?.ToString() ?? _unknownText);
                Description.Add(item["Description"]?.ToString() ?? _unknownText);
                FileSystem.Add(item["FileSystem"]?.ToString() ?? _unknownText);
                FreeSpace.Add(long.Parse(item["FreeSpace"]?.ToString() ?? "0"));
                Size.Add(long.Parse(item["Size"]?.ToString() ?? "0"));
                VolumeName.Add(item["VolumeName"]?.ToString() ?? _unknownText);
                VolumeSerialNumber.Add(item["VolumeSerialNumber"]?.ToString() ?? _unknownText);
            }

            foreach (var item in ddSearcher.Get()) // TODO: wrong comparison with another info before it
            {
                Manufacturer.Add(item["Manufacturer"]?.ToString() ?? "Unknown");
                Model.Add(item["Model"]?.ToString() ?? _unknownText);
                Name.Add(item["Name"]?.ToString() ?? _unknownText);
            }
        }
    }
}
