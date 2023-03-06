using System.Management;
using System.Threading.Tasks;
using System.Windows;
using SystemInformationUtilityWMI.DataStructs;

namespace SystemInformationUtilityWMI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var splashScreen = new SplashScreenWindow();

            MainWindow = splashScreen;
            splashScreen.Show();

            Task.Factory.StartNew(() => 
            {
                using (ManagementObjectSearcher cpuClass = new("Select * from Win32_Processor"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Talking with CPU...");
                    SystemData.cpu = new CPU_Data(cpuClass);
                }

                using (ManagementObjectSearcher mbClass = new("Select * from Win32_MotherboardDevice"), 
                                                baseBoardClass = new("Select * from Win32_BaseBoard"),
                                                physicalArrayClass = new("Select * from Win32_PhysicalMemoryArray"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Walking with Motherboard...");
                    SystemData.mb = new MB_Data(mbClass, baseBoardClass, physicalArrayClass);
                }

                using (ManagementObjectSearcher physicalClass = new("Select * from Win32_PhysicalMemory"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Running in RAM...");
                    SystemData.ram = new RAM_Data(physicalClass);
                }

                using (ManagementObjectSearcher gpuClass = new("Select * from Win32_VideoController"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Drawing with GPU...");
                    SystemData.gpu = new GPU_Data(gpuClass);
                }

                using (ManagementObjectSearcher biosClass = new("Select * from Win32_BIOS"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Reducing in BIOS...");
                    SystemData.bios = new BIOS_Data(biosClass);
                }

                using (ManagementObjectSearcher hdClass = new("Select * from Win32_LogicalDisk"),
                                                ddClass = new("Select * from Win32_DiskDrive"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Exploring in data archives...");
                    SystemData.hd = new HarDrives_Data(hdClass, ddClass);
                }

                using (ManagementObjectSearcher osClass = new("Select * from Win32_OperatingSystem"))
                {
                    splashScreen.Dispatcher.Invoke(() => splashScreen.Progress = "Traveling in computer system...");
                    SystemData.os = new OS_Data(osClass);
                }

                Dispatcher.Invoke(() =>
                {
                    var mainWindow = new MainWindow();
                    MainWindow = mainWindow;
                    mainWindow.Show();
                    splashScreen.Close();
                });
            });
        }

        private void LoadWMIObjects(ManagementClass manageClass)
        {
            manageClass.Options.UseAmendedQualifiers = true;

            PropertyDataCollection properties = manageClass.Properties;

            foreach (var property in properties)
            {
                foreach (var item in manageClass.GetInstances())
                {
                    MessageBox.Show($"{property.Name} {item.Properties[property.Name.ToString()].Value?.ToString()}");
                }
            }

            //foreach (var item in manageClass.Get())
            //{
            //    short[] v = (short[])item["BiosCharacteristics"];

            //    foreach (var s in v)
            //    {
            //        MessageBox.Show(s.ToString());
            //    }
            //}
        }
    }
}
