using System.Windows;
using System.Windows.Media.Imaging;

namespace SystemInformationUtilityWMI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CPUinfo_Button.IsEnabled = false;

            SetLogoImages("CPU");

            text1.Text = "BIOS: " + SystemData.bios.Manufacturer;
            text2.Text = "CPU: " + SystemData.cpu.Name;
            text3.Text = "GPU: " + SystemData.gpu.Caption;
            for (int i = 0; i < SystemData.hd.Model.Count; i++)
            {
                text4.Text += $"HardDrive[{i}]: {SystemData.hd.Model[i]} \n";
            }
            text5.Text = "Motherboard: " + SystemData.mb.Manufacturer + " " + SystemData.mb.Product;
            text6.Text = "OS: " + SystemData.os.Caption;
            for(int i = 0; i < SystemData.ram.Manufacturer.Count; i++)
            {
                text7.Text += $"RAM[{i}]: {SystemData.ram.Manufacturer[i]} \n";
            }
        }

        public void CPUinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(false, true, true, true, true, true, true);

            SetLogoImages("CPU");
        }

        public void MotherboardInfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, false, true, true, true, true, true);

            SetLogoImages("MB");
        }

        public void RAMinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, false, true, true, true, true);

            SetLogoImages("RAM");
        }

        public void BIOSinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, false, true, true, true);

            SetLogoImages("BIOS");
        }

        public void GPUinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, false, true, true);

            SetLogoImages("GPU");
        }

        public void HardDrivesInfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, true, false, true);

            SetLogoImages("HDs");
        }

        public void OSinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, true, true, false);

            SetLogoImages("OS");
        }

        private void EnableButtons(bool cpu, bool mb, bool ram, bool bios, bool gpu, bool hd, bool os)
        {
            CPUinfo_Button.IsEnabled = cpu;
            MBinfo_Button.IsEnabled = mb;
            RAMinfo_Button.IsEnabled = ram;
            BIOSinfo_Button.IsEnabled = bios;
            GPUinfo_Button.IsEnabled = gpu;
            HardDrivesInfo_Button.IsEnabled = hd;
            OSinfo_Button.IsEnabled = os;
        }

        private void SetLogoImages(string elementName)
        {
            string manufacturer;
            string product;

            switch (elementName)
            {
                case "CPU":
                    manufacturer = SystemData.cpu.Name;

                    if (manufacturer.Contains("AMD Ryzen"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_Ryzen.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("AMD Athlon"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_Athlon.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("AMD FX"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_FX.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("AMD Threadripper"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_Threadripper.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("AMD A"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_A-Series.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Intel Atom"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Intel/Intel_Atom.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Intel Celeron"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Intel/Intel_Celeron.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Intel Core"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Intel/Intel_Core.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Intel Pentium"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Intel/Intel_Pentium.png", System.UriKind.Relative));
                    break;
                case "MB":
                    manufacturer = SystemData.mb.Manufacturer;
                    product = SystemData.mb.Product;

                    if (manufacturer.Contains("ASUS"))
                    {
                        if (product.Contains("Pro") || product.Contains("PRIME"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/ASUS/ASUS.png", System.UriKind.Relative));
                        else if (product.Contains("TUF"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/ASUS/ASUS_TUF.png", System.UriKind.Relative));
                        else if (product.Contains("ROG"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/ASUS/ASUS_ROG.png", System.UriKind.Relative));
                    } 
                    else if (manufacturer.Contains("Gigabyte"))
                    {
                        if (product.Contains("D"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", System.UriKind.Relative));
                        else if (product.Contains("VISION"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", System.UriKind.Relative)); // TODO: find or create(?) logo
                        else if (product.Contains("AORUS"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Gigabyte/Gigabyte_AORUS.png", System.UriKind.Relative));
                        else if (product.Contains("Gaming"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Gigabyte/Gigabyte.png", System.UriKind.Relative)); // TODO: find or create(?) logo
                    } else if (manufacturer.Contains("MSI"))
                    {
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/MSI/MSI.png", System.UriKind.Relative));
                    }
                    break;
                case "RAM":
                    manufacturer = SystemData.ram.Manufacturer[0];

                    if (manufacturer.Contains("Apacer"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Apacer.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Corsair"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Corsair.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Crucial"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Crucial.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("GSkill")) // find out manufacturer code/name in WMI
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/GSKILL.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Kingston FURY")) // find out manufacturer code/name in WMI
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Kingston_FURY.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Kingston")) // find out manufacturer code/name in WMI
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Kingston.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Patriot"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Patriot.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Samsung"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/Samsung.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("XPG"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/RAM/XPG.png", System.UriKind.Relative));

                    break;
                case "BIOS": // TODO: make condition when none of these manufacturers are suitable
                    manufacturer = SystemData.bios.Manufacturer;

                    if (manufacturer.Contains("American Megatrends Inc."))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/BIOS/AMI_logo.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Award"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/BIOS/Award_logo.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Phoenix"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/BIOS/Phoenix_logo.png", System.UriKind.Relative));
                    break;
                case "GPU":
                    manufacturer = SystemData.gpu.VideoProcessor;

                    if (manufacturer.Contains("AMD Radeon"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_Radeon.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Vega"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/AMD_Radeon_Vega.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("ATI Radeon"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/AMD/ATI_Radeon.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("NVIDIA GeForce GTX"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/NVIDIA/NVIDIA_GTX.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("NVIDIA GeForce RTX"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/NVIDIA/NVIDIA_RTX.png", System.UriKind.Relative));
                    else
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/", System.UriKind.Relative));
                    break;
                case "HDs": // if hard drives more than 1 -> add images

                    for (int i = 0; i < SystemData.hd.Model.Count; i++)
                    {
                        product = SystemData.hd.Model[i];

                        if (product.Contains("ST"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/HardDrives/Seagate_logo.png", System.UriKind.Relative));
                        else if (product.Contains("WD") && !product.Contains("HDWD"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/HardDrives/WesternDigital_logo.png", System.UriKind.Relative));
                        else if (product.Contains("HDWD") || product.Contains("HDWT") || product.Contains("DT"))
                            VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/HardDrives/Toshiba_logo.png", System.UriKind.Relative));
                    }
                    
                    break;
                case "OS":
                    manufacturer = SystemData.os.Caption;

                    if (manufacturer.Contains("Windows 7"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Microsoft/Windows_7.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Windows 8"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Microsoft/Windows_8.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Windows 10"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Microsoft/Windows_10.png", System.UriKind.Relative));
                    else if (manufacturer.Contains("Windows 11"))
                        VendorImage.Source = new BitmapImage(new System.Uri("/Resources/Vendors/Microsoft/Windows_11.png", System.UriKind.Relative));
                    break;
                default:
                    break;
            }
        }
    }
}
