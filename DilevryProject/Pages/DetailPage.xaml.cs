using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DilevryProject.Pages
{
    public enum State
    {
        Expand,Collaps
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            BindingContext = ViewModel.MasterViewModel.Instance;
        }
        public async void FlayoutToCart()
        {
            AddtoCart.IsEnabled = false;
            var value = int.Parse(numericupdown.Value.ToString());
            var value2 = int.Parse(CartButton.BadgeText);
            for (int i = 1; i <= value; i++)
            {
                var initialpoint = new Point(pizza.X, pizza.Y);
            var initialSize = new Size(pizza.Width, pizza.Height);
            var iniRectangle = new Rectangle(initialpoint, initialSize);
            Annimepizza.IsVisible = true;
            var point = new Point(CartButton.Bounds.X + 15, CartButton.Y + 15);
            var CartButtonLocation = point;
            var ToCartCamp = new Rectangle(CartButtonLocation, new Size(CartButton.Bounds.Size.Width - 30, CartButton.Bounds.Size.Height - 30));
            pizza.IsVisible = false;
            //  await Annimepizza.RotateTo(360, 500, Easing.SinInOut);
            pizza.IsVisible = true;
            await Annimepizza.LayoutTo(ToCartCamp, 500, Easing.SinInOut);

            Annimepizza.IsVisible = false;
            await Annimepizza.LayoutTo(iniRectangle);

                value2++;
                CartButton.BadgeText=value2.ToString();
        }
            AddtoCart.IsEnabled = true;
            //  await Annimepizza.RotateTo(0, 10, Easing.SinInOut);
        }

        private void AddtoCart_Clicked(object sender, EventArgs e)
        {
           
               FlayoutToCart();
        }
        private async void ExpandLayout()
        {
           
            var point = new Point(CartButton.Bounds.X + 30, CartButton.Y + 30);
            var CartButtonLocation = point;
            var ToCartCamp = new Rectangle(CartButtonLocation, new Size(0, 0));
           
            if (States == State.Collaps)
            {
          await CartLayout.LayoutTo(ToCartCamp);
            CartLayout.IsVisible = true;
             var ContY = ContainerLayout.Bounds.Y + 100;
            var ContX = ContainerLayout.Bounds.X;
            var ContLocation = new Point(ContX,ContY);
            var ContSize = new Size(ContainerLayout.Width, ContainerLayout.Height-100);
            var Container = new Rectangle(ContLocation,ContSize);
         
            await CartLayout.LayoutTo(Container,1000, Easing.SinInOut);
            States = State.Expand;
            }
            else
            {
                await CartLayout.LayoutTo(ToCartCamp,1000,Easing.SinInOut);
                States = State.Collaps;
                CartLayout.IsVisible = false;
                 

            }
         
        }
        State States { get; set; }= State.Collaps;
        private void CartClick(object sender, EventArgs e)
        {
            ExpandLayout();
        }
    }
}