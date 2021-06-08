using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DilevryProject.ViewModel
{
    class MasterViewModel:BaseVM
    {


        private string _CartIcon;
        public string CartIcon { get => _CartIcon; set => SetValue(ref _CartIcon, value); }
        private bool CartState = false;

        private static MasterViewModel _Instance;
        public static MasterViewModel Instance
        {
            get 
            { 
                if (_Instance==null)
                    _Instance =new MasterViewModel();
                return _Instance;
            } 
        }

        private int _Bage;
        public int Bage { get => _Bage; set => SetValue(ref _Bage, value); }
        private MasterViewModel()
        {
            LoadData();
        }

        private string _Browseto;
        public string Url { get => _Browseto; set => SetValue(ref _Browseto, value); }
        public ICommand BrowseTo
        {
            get=> new Command(()=>
                {
                     Application.Current.MainPage =new Pages.MainMasterPage();
                  /*  foreach (var t in await Services.DataServices.Instance.GetTopRatedProducts())
                    {
                    await Application.Current.MainPage.DisplayAlert(t.ProductName, t.Rated.ToString(), "ok");
                    }*/
      });
        }
       
        public ICommand BrowseToDetail
        {
            get => new Command(async() =>
            {
                await Task.Delay(10);
                
             //   await App.Current.MainPage.DisplayAlert("Info", SelectedProduct.ProductName, "ok");
                await ((MasterDetailPage)Application.Current.MainPage).Detail.Navigation.PushAsync(new Pages.DetailPage());
                  DetailProductName = SelectedProduct.ProductName;
                  DetailProductImage = SelectedProduct.ProductImage;
                  DetailProductDescription = SelectedProduct.ProductDiscreption;
                if (SelectedProduct.IsSales == true)
                {
                    DetailProductPrice = SelectedProduct.ProductSalesPrice;
                }
                else
                {
                    DetailProductPrice = SelectedProduct.ProductUnitPrice;
                }
            });
        }
        public ICommand SelectionChanged
        {
            get => new Command(()=> 
            {
                
               
            });
        }

        private string _DetailProductName;
        public string DetailProductName { get => _DetailProductName; set => SetValue(ref _DetailProductName, value); }
        private ImageSource _DetailProductImages;
        public ImageSource   DetailProductImage { get => _DetailProductImages; set => SetValue(ref _DetailProductImages, value); }
        private double _DetailProductPrice;
        public double DetailProductPrice { get => _DetailProductPrice; set => SetValue(ref _DetailProductPrice,value); }
        private string _DetailProductDescription;
        public string DetailProductDescription { get=>_DetailProductDescription; set=>SetValue(ref _DetailProductDescription,value); }
        private int _DetailProductQte;
        public int DetailProductQte { get => _DetailProductQte; set => SetValue(ref _DetailProductQte, value); } 


        private ObservableCollection<Model.CategoriesModels> _GetCategorie;
        public ObservableCollection<Model.CategoriesModels> GetCategorie { get => _GetCategorie; set => SetValue(ref _GetCategorie, value); }

        private ObservableCollection<Model.ProductModel> _ProductCatalogue;
        public ObservableCollection<Model.ProductModel> ProductCatalogue { get => _ProductCatalogue; set => SetValue(ref _ProductCatalogue, value); }

        private ObservableCollection<Model.ProductModel> _TopRatedItems;
        public ObservableCollection<Model.ProductModel> TopRatedItems { get => _TopRatedItems; set => SetValue(ref _TopRatedItems, value); }

        private ObservableCollection<Model.ProductModel> _SalesItems;
        public ObservableCollection<Model.ProductModel> SalesItems { get => _SalesItems; set => SetValue(ref _SalesItems, value); }

        private ObservableCollection<Model.ProductModel> _NewItems;
        public ObservableCollection<Model.ProductModel> NewItems { get => _NewItems; set => SetValue(ref _NewItems, value); }

        private Model.ProductModel _SelectedProduct;
       public Model.ProductModel SelectedProduct { get => _SelectedProduct; set => SetValue(ref _SelectedProduct,value); }

        private bool _ShowSales;
        public bool ShowSales { get => _ShowSales; set => SetValue(ref _ShowSales, value); }
        private bool _ShowTopRated;
        public bool ShowTopRated { get => _ShowTopRated; set => SetValue(ref _ShowTopRated, value); }
        private bool _ShowCategorie;
        public bool ShowCategorie { get => _ShowCategorie; set => SetValue(ref _ShowCategorie, value); }
        private bool _ShowIndiCator;
        public bool ShowIndiCator { get => _ShowIndiCator; set => SetValue(ref _ShowIndiCator, value); }
        private bool _ShowHome;
        public bool ShowHome { get => _ShowHome; set => SetValue(ref _ShowHome, value); }

        private bool _ShowNew;
        public bool ShowNew { get => _ShowNew; set => SetValue(ref _ShowNew, value); }

        private async void LoadData()
        {
            DetailProductQte = 1;
            CartIcon = fonts.AwomeSolid.ShoppingCart;
            ShowHome = false;
            ShowIndiCator = true;

            var Sitms = await Services.DataServices.Instance.GetSalesProducts();
            var Citms = await Services.DataServices.Instance.GetAllProducts();
            var RatedItems = await Services.DataServices.Instance.GetTopRatedProducts();
            var Cat = await Services.DataServices.Instance.GetCategories();
            var NewCat = await Services.DataServices.Instance.GetNewProducts();
            LocalCart = new ObservableCollection<Model.CartModel>();
           if (Cat.Count > 0)
            {
                GetCategorie = new ObservableCollection<Model.CategoriesModels>(Cat);
                ShowCategorie = true;
            }
            else
            {
                ShowCategorie = false;
            }
            if (Citms.Count > 0)
            {
              ProductCatalogue = new ObservableCollection<Model.ProductModel>(Citms);
            }
            else
            {
                ShowTopRated = false;
                ShowSales = false;
                ShowNew = false;
            }
            if (Sitms.Count>0)
            {
                
                SalesItems = new ObservableCollection<Model.ProductModel>(Sitms);
                ShowSales = true;
            }
            else
            {
                ShowSales = false;
            }
            if (RatedItems.Count > 0)
            {
            TopRatedItems = new ObservableCollection<Model.ProductModel>(RatedItems);
                ShowTopRated = true;
            }
            else
            {
                ShowTopRated = false;
            }

            if (NewCat.Count > 0)
            {
                ShowNew = true;
                NewItems = new ObservableCollection<Model.ProductModel>(NewCat);

            }
            else
            {
                ShowNew = false;
            }
         ShowIndiCator = false;  
         ShowHome = true;
            
        }


        private bool _ShowPullToRefresh;
        public bool ShowPullToRefresh { get => _ShowPullToRefresh; set => SetValue(ref _ShowPullToRefresh, value); }
        public ICommand PullTorefresh
        {
            get => new Command(async()=> 
            {
                ShowPullToRefresh = true;

                var Sitms = await Services.DataServices.Instance.GetSalesProducts();
                var Citms = await Services.DataServices.Instance.GetAllProducts();
                var RatedItems = await Services.DataServices.Instance.GetTopRatedProducts();
                var Cat = await Services.DataServices.Instance.GetCategories();
                var NewCat = await Services.DataServices.Instance.GetNewProducts();
                if (Cat.Count > 0)
                {
                    GetCategorie = new ObservableCollection<Model.CategoriesModels>(Cat);
                    ShowCategorie = true;
                }
                else
                {
                    ShowCategorie = false;
                }
                if (Citms.Count > 0)
                {
                    ProductCatalogue = new ObservableCollection<Model.ProductModel>(Citms);
                }
                else
                {
                    ShowTopRated = false;
                    ShowSales = false;
                    ShowNew = false;
                }
                if (Sitms.Count > 0)
                {

                    SalesItems = new ObservableCollection<Model.ProductModel>(Sitms);
                    ShowSales = true;
                }
                else
                {
                    ShowSales = false;
                }
                if (RatedItems.Count > 0)
                {
                    TopRatedItems = new ObservableCollection<Model.ProductModel>(RatedItems);
                    ShowTopRated = true;
                }
                else
                {
                    ShowTopRated = false;
                }

                if (NewCat.Count > 0)
                {
                    ShowNew = true;
                    NewItems = new ObservableCollection<Model.ProductModel>(NewCat);

                }
                else
                {
                    ShowNew = false;
                }
                ShowPullToRefresh = false;
            });
        }

        private ObservableCollection<Model.CategoriesModels> _GetFilterCategorie;
        public ObservableCollection<Model.CategoriesModels> GetFilterCategorie { get => _GetFilterCategorie; set => SetValue(ref _GetFilterCategorie, value); }
        private string _Search;
        public string Search { get => _Search; set => SetValue(ref _Search, value); }
        public ICommand Filters
        {
            get => new Command(async()=> 
            {
                var Filter = await Services.DataServices.Instance.GetAllProducts();
                var Filter2 = Filter.Where(c => c.ProductName.Contains(Search)).ToList();
                if (Search != null)
                {
                 ProductCatalogue = new ObservableCollection<Model.ProductModel>(Filter2);
                }
                else
                {
                    var Citms = await Services.DataServices.Instance.GetAllProducts();
                    ProductCatalogue = new ObservableCollection<Model.ProductModel>(Citms);
                }
            });

           

        }
        private ObservableCollection<Model.CartModel> _Cart;
        public ObservableCollection<Model.CartModel> Cart { get => _Cart; set => SetValue(ref _Cart, value); }
        private ObservableCollection<Model.CartModel> LocalCart { get; set; }
        private double _SumCartTotal;
        public double SumCartTotal { get => _SumCartTotal; set => SetValue(ref _SumCartTotal, value); }
     
        public ICommand AddTocart
        {
            get => new Command(() =>
             {
                LocalCart.Add(new Model.CartModel 
                {
                     CartProductImage=SelectedProduct.ProductImage,
                     CartProductName=SelectedProduct.ProductName,
                     CartProductQte =DetailProductQte,
                     CartProductTotals = DetailProductQte* DetailProductPrice,
                     CartProductUnitPrice=DetailProductPrice 
                });
                 Cart = new ObservableCollection<Model.CartModel>(LocalCart.GroupBy(c=>c.CartProductName)
                     .Select(v=> new Model.CartModel 
                     {
                         CartProductName = v.FirstOrDefault().CartProductName,
                         CartProductQte =v.Sum(a=>a.CartProductQte),
                         CartProductImage=v.FirstOrDefault().CartProductImage,
                         CartProductTotals=v.Sum(o=>o.CartProductTotals),
                         CartProductUnitPrice=v.FirstOrDefault().CartProductUnitPrice
                     }).ToList());
                    SumCartTotal = Cart.Sum(sum => sum.CartProductTotals);
             });

        }
        public ICommand CartStateCommand
        {
            get => new Command(() =>
              {
                  if (CartState == false)
                  {
                      CartIcon = fonts.AwomeSolid.WindowClose;
                      CartState = true;

                  }
                  else
                  {
                      CartIcon = fonts.AwomeSolid.ShoppingCart;
                      CartState = false;
                  }
              });
        }
    }

}
