using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct GPU_Data
    {
        public string AdapterCompatibility;
        public long AdapterRAM;
        public string Caption;
        public int CurrentBitsPerPixel;
        public int CurrentHorizontalResolution;
        public long CurrentNumberOfColors;
        public int CurrentRefreshRate;
        public int CurrentVerticalResolution;
        public string DeviceID;
        public string DriverDate;
        public string DriverVersion;
        public int MinRefreshRate;
        public int MaxRefreshRate;
        public bool IsMonochrome;
        public string Status;
        public int VideoArchitecture;
        public int VideoMemoryType;
        public string VideoProcessor;

        private string _unknownText = "Unknown";

        public GPU_Data(ManagementObjectSearcher searcher) 
        {
            foreach (var item in searcher.Get())
            {
                AdapterCompatibility = item["AdapterCompatibility"]?.ToString() ?? _unknownText;
                AdapterRAM = long.Parse(item["AdapterRAM"]?.ToString() ?? "0");
                Caption = item["Caption"]?.ToString() ?? _unknownText;
                CurrentBitsPerPixel = int.Parse(item["CurrentBitsPerPixel"]?.ToString() ?? "0");
                CurrentHorizontalResolution = int.Parse(item["CurrentHorizontalResolution"]?.ToString() ?? "0");
                CurrentNumberOfColors = long.Parse(item["CurrentNumberOfColors"]?.ToString() ?? "0");
                CurrentRefreshRate = int.Parse(item["CurrentRefreshRate"]?.ToString() ?? "0");
                CurrentVerticalResolution = int.Parse(item["CurrentVerticalResolution"]?.ToString() ?? "0");
                DeviceID = item["DeviceID"]?.ToString() ?? _unknownText;
                DriverDate = item["DriverDate"]?.ToString() ?? _unknownText;
                DriverVersion = item["DriverVersion"]?.ToString() ?? _unknownText;
                MinRefreshRate = int.Parse(item["MinRefreshRate"]?.ToString() ?? "0");
                MaxRefreshRate = int.Parse(item["MaxRefreshRate"]?.ToString() ?? "0");
                IsMonochrome = bool.Parse(item["Monochrome"]?.ToString() ?? "0");
                Status = item["Status"]?.ToString() ?? _unknownText;
                VideoArchitecture = int.Parse(item["VideoArchitecture"]?.ToString() ?? "0");
                VideoMemoryType = int.Parse(item["VideoMemoryType"]?.ToString() ?? "0");
                VideoProcessor = item["VideoProcessor"]?.ToString() ?? _unknownText;
            }
        }
    }
}
