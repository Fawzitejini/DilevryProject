using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DilevryProject.Views
{
    class TemplateSelector : DataTemplateSelector

    {
        public DataTemplate NewCatalogue { get; set; }
        public DataTemplate SalesCatalogue{ get; set; }
        public DataTemplate NormalCatalogue { get; set; }
       
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (((Model.ProductModel)item).ProductsType == Model.ProductType.New)
            {
            return NewCatalogue;
            }else if (((Model.ProductModel)item).ProductsType == Model.ProductType.Sales)
            {
                return SalesCatalogue;
            }
            else
            {
                return NormalCatalogue;
            }
        }
    }
}
