using System;
using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct OS_Data
    {
        public string BootDevice;
        public string BuildNumber;
        public string Caption;
        public string CodeSet;
        public string CSName;
        public DateTime InstallDate;
        public DateTime LastBootUpTime;
        public string Manufacturer;
        public string OSArchitecture;
        public bool PortableOperatingSystem;
        public bool Primary;
        public string RegisteredUser;
        public string SerialNumber;
        public string Status;
        public string SystemDirectory;
        public string SystemDrive;
        public string Version;
        public string WindowsDirectory;

        private string _unknownText = "Unknown";

        public OS_Data(ManagementObjectSearcher searcher)
        {
            foreach (var item in searcher.Get())
            {
                BootDevice = item["BootDevice"]?.ToString() ?? _unknownText;
                BuildNumber = item["BuildNumber"]?.ToString() ?? _unknownText;
                Caption = item["Caption"]?.ToString() ?? _unknownText;
                CodeSet = item["CodeSet"]?.ToString() ?? _unknownText;
                CSName = item["CSName"]?.ToString() ?? _unknownText;

                if (item["InstallDate"] is not null)
                {
                    InstallDate = DateTime.ParseExact(item["InstallDate"].ToString().Remove(14), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                }

                if (item["LastBootUpTime"] is not null)
                {
                    LastBootUpTime = DateTime.ParseExact(item["LastBootUpTime"].ToString().Remove(14), "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                }

                Manufacturer = item["Manufacturer"]?.ToString() ?? _unknownText;
                OSArchitecture = item["OSArchitecture"]?.ToString() ?? _unknownText;
                PortableOperatingSystem = bool.Parse(item["PortableOperatingSystem"]?.ToString() ?? "false");
                Primary = bool.Parse(item["Primary"]?.ToString() ?? _unknownText);
                RegisteredUser = item["RegisteredUser"]?.ToString() ?? _unknownText;
                SerialNumber = item["SerialNumber"]?.ToString() ?? _unknownText;
                Status = item["Status"]?.ToString() ?? _unknownText;
                SystemDirectory = item["SystemDirectory"]?.ToString() ?? _unknownText;
                SystemDrive = item["SystemDrive"]?.ToString() ?? _unknownText;
                Version = item["Version"]?.ToString() ?? _unknownText;
                WindowsDirectory = item["WindowsDirectory"]?.ToString() ?? _unknownText;
            }
        }
    }
}
