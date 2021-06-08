using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.Model
{
   public class LocalCategoriesModels
    {
        public string CategoriesName { get; set; }
        public string CategoriesImage { get; set; }
        public string CategoriesID { get; set; }
    }
    public class CategoriesModels
    {
        public string CategoriesName { get; set; }
        public Xamarin.Forms.ImageSource CategoriesImage { get; set; }
        public string CategoriesID { get; set; }
    }
}
