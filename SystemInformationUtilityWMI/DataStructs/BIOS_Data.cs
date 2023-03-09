using System;
using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct BIOS_Data
    {
        public short[] BiosCharacteristics;
        public string Caption;
        public string Manufacturer;
        public DateTime ReleaseDate;
        public string Status;
        public string Version;

        private const string _unknownText = "Unknown";

        public BIOS_Data(ManagementObjectSearcher searcher)
        {
            foreach (var item in searcher.Get())
            {
                BiosCharacteristics = (short[])item["BiosCharacteristics"];
                Caption = item["Caption"]?.ToString() ?? _unknownText;
                Manufacturer = item["Manufacturer"]?.ToString() ?? _unknownText;
                if (item["ReleaseDate"] is not null)
                    ReleaseDate = DateTime.ParseExact(item["ReleaseDate"].ToString().Remove(14), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                Status = item["Status"]?.ToString() ?? _unknownText;
                Version = item["Version"]?.ToString() ?? _unknownText;
            }
        }
    }
}
