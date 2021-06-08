
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DilevryProject.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            InitializeComponent();
            Master = new MenuPage();
            Detail = new NavigationPage(new StorePage()) 
            {
                BarBackgroundColor = Color.FromHex("#FBC96D"),
                BarTextColor = Color.FromHex("#151E34"),
                Title = "Acceuil", 
            };
        }
    }
}