using System.Windows;

namespace SystemInformationUtilityWMI
{
    /// <summary>
    /// Логика взаимодействия для SplashScreenWindow.xaml
    /// </summary>
    public partial class SplashScreenWindow : Window
    {
        public SplashScreenWindow()
        {
            InitializeComponent();
        }

        public string Progress
        {
            set
            {
                LoadingText.Text = value;
            }
        }
    }
}
