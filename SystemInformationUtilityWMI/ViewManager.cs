using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace SystemInformationUtilityWMI
{
    class ViewManager
    {
        private readonly Image _logoImage;
        private readonly ListBox _listBoxInfo;

        public ViewManager(Image img, ListBox listBox)
        {
            _logoImage = img;
            _listBoxInfo = listBox;
        }

        public void SetLogoImages(string elementName)
        {
            string manufacturer;
            string product;

            switch (elementName)
            {
                case "CPU":
                    manufacturer = SystemData.cpu.Name;

                    if (manufacturer.Contains("AMD"))
                    {
                        if (manufacturer.Contains("Ryzen"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_Ryzen.png", UriKind.Relative));
                        else if (manufacturer.Contains("Athlon"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_Athlon.png", UriKind.Relative));
                        else if (manufacturer.Contains("FX"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_FX.png", UriKind.Relative));
                        else if (manufacturer.Contains("Threadripper"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_Threadripper.png", UriKind.Relative));
                        else if (manufacturer.Contains("A"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_A-Series.png", UriKind.Relative));
                    }
                    else if (manufacturer.Contains("Intel"))
                    {
                        if (manufacturer.Contains("Atom"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Intel/Intel_Atom.png", UriKind.Relative));
                        else if (manufacturer.Contains("Celeron"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Intel/Intel_Celeron.png", UriKind.Relative));
                        else if (manufacturer.Contains("Core"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Intel/Intel_Core.png", UriKind.Relative));
                        else if (manufacturer.Contains("Pentium"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Intel/Intel_Pentium.png", UriKind.Relative));
                    } else 
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/processor.png", UriKind.Relative));
                    break;
                case "MB":
                    manufacturer = SystemData.mb.Manufacturer;
                    product = SystemData.mb.Product;

                    if (manufacturer.Contains("ASUS"))
                    {
                        if (product.Contains("Pro") || product.Contains("PRIME"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/ASUS/ASUS.png", UriKind.Relative));
                        else if (product.Contains("TUF") || product.Contains("SABERTOOTH"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/ASUS/ASUS_TUF.png", UriKind.Relative));
                        else if (product.Contains("ROG"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/ASUS/ASUS_ROG.png", UriKind.Relative));
                    }
                    else if (manufacturer.Contains("Gigabyte"))
                    {
                        if (product.Contains("D"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", UriKind.Relative));
                        else if (product.Contains("VISION"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", UriKind.Relative)); // TODO: find or create(?) logo
                        else if (product.Contains("AORUS"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Gigabyte/Gigabyte_AORUS.png", UriKind.Relative));
                        else if (product.Contains("Gaming"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", UriKind.Relative)); // TODO: find or create(?) logo
                        // TODO: add AERO version
                    }
                    else if (manufacturer.Contains("MSI"))
                    {
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/MSI/MSI.png", UriKind.Relative));
                    } else
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/motherboard.png", UriKind.Relative));
                    break;
                case "RAM":
                    manufacturer = SystemData.ram.Manufacturer[0];

                    if (manufacturer.Contains("Apacer"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Apacer.png", UriKind.Relative));
                    else if (manufacturer.Contains("Corsair"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Corsair.png", UriKind.Relative));
                    else if (manufacturer.Contains("Crucial"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Crucial.png", UriKind.Relative));
                    else if (manufacturer.Contains("GSkill")) // find out manufacturer code/name in WMI
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/GSKILL.png", UriKind.Relative));
                    else if (manufacturer.Contains("Kingston FURY")) // find out manufacturer code/name in WMI
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Kingston_FURY.png", UriKind.Relative));
                    else if (manufacturer.Contains("Kingston"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Kingston.png", UriKind.Relative));
                    else if (manufacturer.Contains("Patriot"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Patriot.png", UriKind.Relative));
                    else if (manufacturer.Contains("Samsung"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/Samsung.png", UriKind.Relative));
                    else if (manufacturer.Contains("XPG"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/XPG.png", UriKind.Relative));
                    else if (manufacturer.Contains("Unknown"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/ram.png", UriKind.Relative));

                    break;
                case "BIOS": // TODO: make condition when none of these manufacturers are suitable
                    manufacturer = SystemData.bios.Manufacturer;

                    if (manufacturer.Contains("American Megatrends Inc."))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/BIOS/AMI_logo.png", UriKind.Relative));
                    else if (manufacturer.Contains("Award"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/BIOS/Award_logo.png", UriKind.Relative));
                    else if (manufacturer.Contains("Phoenix"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/BIOS/Phoenix_logo.png", UriKind.Relative));
                    else
                        _logoImage.Source = _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/BIOS.png", UriKind.Relative));
                    break;
                case "GPU":
                    manufacturer = SystemData.gpu.VideoProcessor;

                    if (manufacturer.Contains("AMD Radeon"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_Radeon.png", UriKind.Relative));
                    else if (manufacturer.Contains("Vega"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/AMD_Radeon_Vega.png", UriKind.Relative));
                    else if (manufacturer.Contains("ATI Radeon"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/AMD/ATI_Radeon.png", UriKind.Relative));
                    else if (manufacturer.Contains("NVIDIA GeForce GTX"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/NVIDIA/NVIDIA_GTX.png", UriKind.Relative));
                    else if (manufacturer.Contains("NVIDIA GeForce RTX"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/NVIDIA/NVIDIA_RTX.png", UriKind.Relative));
                    else
                        _logoImage.Source = _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/graphic-card.png", UriKind.Relative));
                    break;
                case "HDs": // if hard drives more than 1 -> add images

                    for (int i = 0; i < SystemData.hd.Model.Count; i++)
                    {
                        product = SystemData.hd.Model[i];

                        if (product.Contains("ST"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/HardDrives/Seagate_logo.png", UriKind.Relative));
                        else if (product.Contains("WD") && !product.Contains("HDWD"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/HardDrives/WesternDigital_logo.png", UriKind.Relative));
                        else if (product.Contains("HDWD") || product.Contains("HDWT") || product.Contains("DT"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/HardDrives/Toshiba_logo.png", UriKind.Relative));
                        else if (product.Contains("XPG"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/RAM/XPG.png", UriKind.Relative));
                        else if (product.Contains("QUMO"))
                            _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/HardDrives/QUMO_logo.png", UriKind.Relative));
                        else
                            _logoImage.Source = _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/hdd.png", UriKind.Relative));
                    }

                    break;
                case "OS":
                    manufacturer = SystemData.os.Caption;

                    if (manufacturer.Contains("Windows 7"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Microsoft/Windows_7.png", UriKind.Relative));
                    else if (manufacturer.Contains("Windows 8"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Microsoft/Windows_8.png", UriKind.Relative));
                    else if (manufacturer.Contains("Windows 10"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Microsoft/Windows_10.png", UriKind.Relative));
                    else if (manufacturer.Contains("Windows 11"))
                        _logoImage.Source = new BitmapImage(new Uri("/Resources/Vendors/Microsoft/Windows_11.png", UriKind.Relative));
                    else
                        _logoImage.Source = _logoImage.Source = new BitmapImage(new Uri("/Resources/MenuIcons/operating-system.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
        }

        public void SetPropertiesAndValues(string elementName)
        {
            string str, biosData = "";

            switch (elementName)
            {
                case "CPU":
                    _listBoxInfo.Items.Clear();

                    str = SystemData.cpu.CpuStatus == 1 ? "Working" : "Disabled";

                    _listBoxInfo.Items.Add($"Address width: {SystemData.cpu.AddressWidth} bit");
                    _listBoxInfo.Items.Add($"Caption: x{SystemData.cpu.Caption}");
                    _listBoxInfo.Items.Add($"CPU status: {str}");
                    _listBoxInfo.Items.Add($"Current clock speed: {SystemData.cpu.CurrentClockSpeed} MHz");
                    _listBoxInfo.Items.Add($"Core voltage: {SystemData.cpu.CurrentVoltage} V");
                    _listBoxInfo.Items.Add($"DeviceID: {SystemData.cpu.DeviceID}");
                    _listBoxInfo.Items.Add($"Bus speed: {SystemData.cpu.ExtClock} MHz");
                    _listBoxInfo.Items.Add($"L2 Cache size: {SystemData.cpu.L2CacheSize} kB");
                    _listBoxInfo.Items.Add($"L2 Cache speed: {SystemData.cpu.L2CacheSpeed} MHz");
                    _listBoxInfo.Items.Add($"L3 Cache size: {SystemData.cpu.L3CacheSize} kB");
                    _listBoxInfo.Items.Add($"L3 Cache speed: {SystemData.cpu.L3CacheSpeed} MHz");
                    _listBoxInfo.Items.Add($"Manufacturer: {SystemData.cpu.Manufacturer}");
                    _listBoxInfo.Items.Add($"Max clock speed: {SystemData.cpu.MaxClockSpeed} MHz");
                    _listBoxInfo.Items.Add($"CPU: {SystemData.cpu.Name}");
                    _listBoxInfo.Items.Add($"Cores: {SystemData.cpu.NumberOfCores}");
                    _listBoxInfo.Items.Add($"Threads: {SystemData.cpu.ThreadCount}");
                    _listBoxInfo.Items.Add($"Socket: {SystemData.cpu.SocketDesignation}");
                    _listBoxInfo.Items.Add($"VT enabled: {SystemData.cpu.VirtualizationFirmwareEnabled}");
                    _listBoxInfo.Items.Add($"VM extensions: {SystemData.cpu.VMMonitorModeExtensions}");
                    break;
                case "MB":
                    _listBoxInfo.Items.Clear();

                    _listBoxInfo.Items.Add($"DeviceID: {SystemData.mb.DeviceID}");
                    _listBoxInfo.Items.Add($"Manufacturer: {SystemData.mb.Manufacturer}");
                    _listBoxInfo.Items.Add($"Product: {SystemData.mb.Product}");
                    _listBoxInfo.Items.Add($"Max capacity: {SystemData.mb.MaxCapacity / 1024 / 1024} Gb");
                    _listBoxInfo.Items.Add($"Maximum RAM modules: {SystemData.mb.MemoryDevices}");
                    _listBoxInfo.Items.Add($"Primary bus type: {SystemData.mb.PrimaryBusType}");
                    _listBoxInfo.Items.Add($"Secondary bus type: {SystemData.mb.SecondaryBusType}");
                    _listBoxInfo.Items.Add($"Status: {SystemData.mb.Status}");
                    break;
                case "RAM":
                    _listBoxInfo.Items.Clear();

                    for (int i = 0; i < SystemData.ram.Capacity.Count; i++)
                    {
                        _listBoxInfo.Items.Add($" ----- RAM Module: {i}  ----- ");
                        _listBoxInfo.Items.Add($"Capacity: {SystemData.ram.Capacity[i] / 1024 / 1024 / 1024} Gb");
                        _listBoxInfo.Items.Add($"Speed: {SystemData.ram.Speed[i]} MHz");
                        _listBoxInfo.Items.Add($"Voltage: {SystemData.ram.ConfiguredVoltage[i] / 1000} V");
                        _listBoxInfo.Items.Add($"Data width: {SystemData.ram.DataWidth[i]} bit");
                        _listBoxInfo.Items.Add($"Form factor: {RamFormFactor((RAMFormFactors)SystemData.ram.FormFactor[i])}");
                        _listBoxInfo.Items.Add($"Part number: {SystemData.ram.PartNumber[i]}");
                        _listBoxInfo.Items.Add($"Manufacturer: {SystemData.ram.Manufacturer[i]}");
                    }
                    break;
                case "BIOS":
                    _listBoxInfo.Items.Clear();

                    for (int i = 0; i < SystemData.bios.BiosCharacteristics.Length; i++)
                    {
                        biosData += (SystemData.bios.BiosCharacteristics[i] + " ");
                    }

                    _listBoxInfo.Items.Add($"Used BIOS fields: {biosData}");
                    _listBoxInfo.Items.Add($"Caption: {SystemData.bios.Caption}");
                    _listBoxInfo.Items.Add($"Manufacturer: {SystemData.bios.Manufacturer}");
                    _listBoxInfo.Items.Add($"Release date: {SystemData.bios.ReleaseDate}");
                    _listBoxInfo.Items.Add($"Status: {SystemData.bios.Status}");
                    _listBoxInfo.Items.Add($"Version: {SystemData.bios.Version}");
                    break;
                case "GPU":
                    _listBoxInfo.Items.Clear();

                    _listBoxInfo.Items.Add($"Adapter compatibility: {SystemData.gpu.AdapterCompatibility}");
                    _listBoxInfo.Items.Add($"Adapter memory: {SystemData.gpu.AdapterRAM / 1024 / 1024 } Mb");
                    _listBoxInfo.Items.Add($"Caption: {SystemData.gpu.Caption}");
                    _listBoxInfo.Items.Add($"Current bits per pixel: {SystemData.gpu.CurrentBitsPerPixel}");
                    _listBoxInfo.Items.Add($"Current colors: {SystemData.gpu.CurrentNumberOfColors}");
                    _listBoxInfo.Items.Add($"Current horizontal resolution: {SystemData.gpu.CurrentHorizontalResolution} px");
                    _listBoxInfo.Items.Add($"Current vertical resolution: {SystemData.gpu.CurrentVerticalResolution} px");
                    _listBoxInfo.Items.Add($"Current refresh rate: {SystemData.gpu.CurrentRefreshRate}");
                    _listBoxInfo.Items.Add($"DeviceID: {SystemData.gpu.DeviceID}");
                    _listBoxInfo.Items.Add($"Driver date: {SystemData.gpu.DriverDate}");
                    _listBoxInfo.Items.Add($"Driver version: {SystemData.gpu.DriverVersion}");
                    _listBoxInfo.Items.Add($"Minimum refresh rate: {SystemData.gpu.MinRefreshRate}");
                    _listBoxInfo.Items.Add($"Maximum refresh rate: {SystemData.gpu.MaxRefreshRate}");
                    _listBoxInfo.Items.Add($"Monochrome: {SystemData.gpu.IsMonochrome}");
                    _listBoxInfo.Items.Add($"Status: {SystemData.gpu.Status}");
                    _listBoxInfo.Items.Add($"Video architecture: {GPU_architecture((VideoArchitectureTypes)SystemData.gpu.VideoArchitecture)}");
                    _listBoxInfo.Items.Add($"Video memory: {GPU_Memory((VideoMemoryTypes)SystemData.gpu.VideoMemoryType)}");
                    _listBoxInfo.Items.Add($"Video processor: {SystemData.gpu.VideoProcessor}");
                    break;
                case "HDs":
                    _listBoxInfo.Items.Clear();

                    for (int i = 0; i < SystemData.hd.Caption.Count; i++)
                    {
                        _listBoxInfo.Items.Add($" ----- Hard Drive: {i} ----- ");

                        _listBoxInfo.Items.Add($"Caption: {SystemData.hd.Caption[i]}");
                        _listBoxInfo.Items.Add($"Description: {SystemData.hd.Description[i]}");
                        _listBoxInfo.Items.Add($"File system: {SystemData.hd.FileSystem[i]}");
                        _listBoxInfo.Items.Add($"Total space: {SystemData.hd.Size[i] / 1024 / 1024 / 1024} Gb");
                        _listBoxInfo.Items.Add($"Free space: {SystemData.hd.FreeSpace[i] / 1024 / 1024 / 1024} Gb");
                        _listBoxInfo.Items.Add($"Volume name: {SystemData.hd.VolumeName[i]}");
                        _listBoxInfo.Items.Add($"Volume serial number: {SystemData.hd.VolumeSerialNumber[i]}");
                        _listBoxInfo.Items.Add($"Manufacturer: {SystemData.hd.Manufacturer[i]}");
                        _listBoxInfo.Items.Add($"Model: {SystemData.hd.Model[i]}");
                        _listBoxInfo.Items.Add($"Name: {SystemData.hd.Name[i]}");
                        
                    }
                    break;
                case "OS":
                    _listBoxInfo.Items.Clear();

                    _listBoxInfo.Items.Add($"Boot device: {SystemData.os.BootDevice}");
                    _listBoxInfo.Items.Add($"Build: {SystemData.os.BuildNumber}");
                    _listBoxInfo.Items.Add($"Caption: {SystemData.os.Caption}");
                    _listBoxInfo.Items.Add($"CodeSet: {SystemData.os.CodeSet}");
                    _listBoxInfo.Items.Add($"PC Name: {SystemData.os.CSName}");
                    _listBoxInfo.Items.Add($"Install date: {SystemData.os.InstallDate}");
                    _listBoxInfo.Items.Add($"Last bootup time: {SystemData.os.LastBootUpTime}");
                    _listBoxInfo.Items.Add($"Manufacturer: {SystemData.os.Manufacturer}");
                    _listBoxInfo.Items.Add($"OS architecture: {SystemData.os.OSArchitecture}");
                    _listBoxInfo.Items.Add($"Portable OS: {SystemData.os.PortableOperatingSystem}");
                    _listBoxInfo.Items.Add($"Primary: {SystemData.os.Primary}");
                    _listBoxInfo.Items.Add($"Registered user: {SystemData.os.RegisteredUser}");
                    _listBoxInfo.Items.Add($"Serial number: {SystemData.os.SerialNumber}");
                    _listBoxInfo.Items.Add($"Status: {SystemData.os.Status}");
                    _listBoxInfo.Items.Add($"System directory: {SystemData.os.SystemDirectory}");
                    _listBoxInfo.Items.Add($"Windows directory: {SystemData.os.WindowsDirectory}");
                    _listBoxInfo.Items.Add($"System drive: {SystemData.os.SystemDrive}");
                    _listBoxInfo.Items.Add($"Version: {SystemData.os.Version}");
                    break;
                default:
                    break;
            }
        }

        private static string RamFormFactor(RAMFormFactors formFactor) => formFactor.ToString();

        private static string GPU_architecture(VideoArchitectureTypes architect) => architect.ToString();

        private static string GPU_Memory(VideoMemoryTypes memory) => memory.ToString();
    }
}
