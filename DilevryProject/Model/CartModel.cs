using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.Model
{
   public class CartModel
    {
      public string CartProductName { get; set; }
      public double CartProductUnitPrice { get; set; }
      public int CartProductQte { get; set; }
      public Xamarin.Forms.ImageSource CartProductImage { get; set; }
      public double CartProductTotals { get; set; }
    }
}
