using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DilevryProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SatrtPage : ContentPage
    {
        public SatrtPage()
        {
            InitializeComponent();
           Device.StartTimer(TimeSpan.FromSeconds(10),SpalshTime);
           
            

        }
        private bool SpalshTime()
        {

            Application.Current.MainPage = new MainPage();
          //  BindingContext =  ViewModel.MasterViewModel.Instance;
         
            return false;
        }
    }
}