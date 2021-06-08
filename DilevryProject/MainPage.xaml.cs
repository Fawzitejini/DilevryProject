using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DilevryProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = ViewModel.UserViewModel.Instance;
        }
        public async void LoadData()
        {
            if ((await Services.DataServices.Instance.checkUrlAsync()) == false)
            {
                await   Navigation.PushModalAsync(new Pages.NoInternetPage());
                return;
            }
         //   await DisplayAlert("ok", (await Services.DataServices.Instance.GetAllProducts()).Count.ToString(), "ok");
        foreach (var x in await Services.DataServices.Instance.GetAllProducts())
            {
              await  DisplayAlert("ok", $"Product: { x.ProductName} \n Rating: {x.Rating} " , "ok");
            }
        }
    }
}
