using Firebase.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace DilevryProject.Services
{
    class BaseSevice
    {
        protected FirebaseClient Clients
        {
            get
            {
                return new FirebaseClient("https://possystem-be235-default-rtdb.firebaseio.com");
            }
        }
        public async System.Threading.Tasks.Task<bool> checkUrlAsync()
        {
            string URL = "https://possystem-be235-default-rtdb.firebaseio.com";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);
                try
                {
                    HttpResponseMessage response = await client.GetAsync(URL);
                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        //   await  ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new Views.NoInternet());
                        return false;
                    }
                }
                catch (Exception)
                {
                    //    await ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new Views.NoInternet());
                    return false;
                }

                //return false;
            }
        }


        protected Xamarin.Forms.ImageSource Yimage(string Ximage)
        {
            var image = Xamarin.Forms.ImageSource.FromStream(
            () => new MemoryStream(Convert.FromBase64String(Ximage)));
            return image;
        }
    }
}
