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
    public partial class OwnBroser : ContentPage
    {
        public OwnBroser()
        {
            InitializeComponent();
            BindingContext = ViewModel.MasterViewModel.Instance;
        }

       
    }
}