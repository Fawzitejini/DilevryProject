using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DilevryProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("fr-MA");
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTAxNUAzMTM5MmUzMTJlMzBJU0VTZG03a3BtcW9EVmVxaHk4OHZrUlNhdGVLdTdBam1PZENSZHNDVXJFPQ==");
            MainPage = new MainPage();
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
