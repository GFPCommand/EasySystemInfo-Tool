using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct CPU_Data
    {
        public int AddressWidth;
        public string Caption;
        public int CpuStatus;
        public int CurrentClockSpeed;
        public float CurrentVoltage;
        public string DeviceID;
        public int ExtClock;
        public int L2CacheSize;
        public int L2CacheSpeed;
        public int L3CacheSize;
        public int L3CacheSpeed;
        public string Manufacturer;
        public int MaxClockSpeed;
        public string Name;
        public int NumberOfCores;
        public int ThreadCount;
        public string SocketDesignation;
        public bool VirtualizationFirmwareEnabled;
        public bool VMMonitorModeExtensions;

        private const string _unknownText = "Unknown";

        public CPU_Data(ManagementObjectSearcher searcher) 
        {
            foreach (var item in searcher.Get())
            {
                AddressWidth = int.Parse(item["AddressWidth"]?.ToString() ?? "0");
                Caption = item["AddressWidth"]?.ToString() ?? _unknownText;
                CpuStatus = int.Parse(item["CpuStatus"]?.ToString() ?? "0");
                CurrentClockSpeed = int.Parse(item["CurrentClockSpeed"]?.ToString() ?? "0");
                CurrentVoltage = float.Parse(item["CurrentVoltage"]?.ToString() ?? "0") / 10;
                DeviceID = item["DeviceID"]?.ToString() ?? _unknownText;
                ExtClock = int.Parse(item["ExtClock"]?.ToString() ?? "0");
                L2CacheSize = int.Parse(item["L2CacheSize"]?.ToString() ?? "0");
                L2CacheSpeed = int.Parse(item["L2CacheSpeed"]?.ToString() ?? "0");
                L3CacheSize = int.Parse(item["L3CacheSize"]?.ToString() ?? "0");
                L3CacheSpeed = int.Parse(item["L3CacheSpeed"]?.ToString() ?? "0");
                Manufacturer = item["Manufacturer"]?.ToString() ?? _unknownText;
                MaxClockSpeed = int.Parse(item["MaxClockSpeed"]?.ToString() ?? "0");
                Name = item["Name"]?.ToString() ?? string.Empty;
                NumberOfCores = int.Parse(item["NumberOfCores"]?.ToString() ?? "0");
                ThreadCount = int.Parse(item["ThreadCount"]?.ToString() ?? "0");
                SocketDesignation = item["SocketDesignation"]?.ToString() ?? _unknownText;
                VirtualizationFirmwareEnabled = bool.Parse(item["VirtualizationFirmwareEnabled"]?.ToString() ?? "false");
                VMMonitorModeExtensions = bool.Parse(item["VMMonitorModeExtensions"]?.ToString() ?? "false");
            }
        }
    }
}
