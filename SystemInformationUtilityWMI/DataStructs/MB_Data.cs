using System.Management;

namespace SystemInformationUtilityWMI.DataStructs
{
    struct MB_Data
    {
        public string DeviceID;
        public string Manufacturer;
        public int MaxCapacity;
        public int MemoryDevices;
        public string PrimaryBusType;
        public string Product;
        public string SecondaryBusType;
        public string Status;

        private string _unknownText = "Unknown";

        public MB_Data(ManagementObjectSearcher searcherMotherboard, ManagementObjectSearcher searcherBaseBoard, ManagementObjectSearcher searcherMemory)
        {
            foreach (var item in searcherMotherboard.Get())
            {
                DeviceID = item["DeviceID"]?.ToString() ?? _unknownText;
                PrimaryBusType = item["PrimaryBusType"]?.ToString() ?? _unknownText;
                SecondaryBusType = item["SecondaryBusType"]?.ToString() ?? _unknownText;
                Status = item["Status"]?.ToString() ?? _unknownText;
            }

            foreach (var item in searcherBaseBoard.Get())
            {
                Manufacturer = item["Manufacturer"]?.ToString() ?? _unknownText;
                Product = item["Product"]?.ToString() ?? _unknownText;
            }

            foreach (var item in searcherMemory.Get())
            {
                MaxCapacity = int.Parse(item["MaxCapacity"]?.ToString() ?? "0");
                MemoryDevices = int.Parse(item["MemoryDevices"]?.ToString() ?? "0");
            }
        }
    }
}
