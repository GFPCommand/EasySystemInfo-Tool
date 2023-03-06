using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct BIOS_Data
    {
        public short[] BiosCharacteristics;
        public string Caption;
        public string Manufacturer;
        public string ReleaseDate;
        public string Status;
        public string Version;

        private string _unknownText = "Unknown";

        public BIOS_Data(ManagementObjectSearcher searcher)
        {
            foreach (var item in searcher.Get())
            {
                BiosCharacteristics = (short[])item["BiosCharacteristics"];
                Caption = item["Caption"]?.ToString() ?? _unknownText;
                Manufacturer = item["Manufacturer"]?.ToString() ?? _unknownText;
                ReleaseDate = item["ReleaseDate"]?.ToString() ?? _unknownText;
                Status = item["Status"]?.ToString() ?? _unknownText;
                Version = item["Version"]?.ToString() ?? _unknownText;
            }
        }
    }
}
