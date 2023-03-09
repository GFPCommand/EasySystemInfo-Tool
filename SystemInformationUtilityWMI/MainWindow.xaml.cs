using System.Windows;

namespace SystemInformationUtilityWMI
{
    public partial class MainWindow : Window
    {
        private readonly ViewManager _viewManager;

        enum ActiveTab { CPU, MB, RAM, BIOS, GPU, HDs, OS }

        public MainWindow()
        {
            InitializeComponent();

            CPUinfo_Button.IsEnabled = false;

            _viewManager = new(VendorImage, Properties);

            _viewManager.SetLogoImages(ActiveTab.CPU.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.CPU.ToString());

            //text1.Text = "BIOS: " + SystemData.bios.Manufacturer;
            //text2.Text = "CPU: " + SystemData.cpu.Name;
            //text3.Text = "GPU: " + SystemData.gpu.Caption;
            //for (int i = 0; i < SystemData.hd.Model.Count; i++)
            //{
            //    text4.Text += $"HardDrive[{i}]: {SystemData.hd.Model[i]} \n";
            //}
            //text5.Text = "Motherboard: " + SystemData.mb.Manufacturer + " " + SystemData.mb.Product;
            //text6.Text = "OS: " + SystemData.os.Caption;
            //for(int i = 0; i < SystemData.ram.Manufacturer.Count; i++)
            //{
            //    text7.Text += $"RAM[{i}]: {SystemData.ram.Manufacturer[i]} \n";
            //}
        }

        public void CPUinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(false, true, true, true, true, true, true);

            _viewManager.SetLogoImages(ActiveTab.CPU.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.CPU.ToString());
        }

        public void MotherboardInfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, false, true, true, true, true, true);

            _viewManager.SetLogoImages(ActiveTab.MB.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.MB.ToString());
        }

        public void RAMinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, false, true, true, true, true);

            _viewManager.SetLogoImages(ActiveTab.RAM.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.RAM.ToString());
        }

        public void BIOSinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, false, true, true, true);

            _viewManager.SetLogoImages(ActiveTab.BIOS.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.BIOS.ToString());
        }

        public void GPUinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, false, true, true);

            _viewManager.SetLogoImages(ActiveTab.GPU.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.GPU.ToString());
        }

        public void HardDrivesInfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, true, false, true);

            _viewManager.SetLogoImages(ActiveTab.HDs.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.HDs.ToString());
        }

        public void OSinfoViewer(object sender, RoutedEventArgs e)
        {
            EnableButtons(true, true, true, true, true, true, false);

            _viewManager.SetLogoImages(ActiveTab.OS.ToString());
            _viewManager.SetPropertiesAndValues(ActiveTab.OS.ToString());
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
    }
}
