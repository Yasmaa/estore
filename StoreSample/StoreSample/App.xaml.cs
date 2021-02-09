using StoreSample.Helpers;
using Xamarin.Forms;

namespace StoreSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        }

        public App(string dbPath)
        {
            Settings.DatabasePath = dbPath;
            InitializeComponent();
            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}