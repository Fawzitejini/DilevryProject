using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.Model
{
    public enum ProductType
    {
        Sales,Normal,New
    }
    public class ProductModel
    {
       
        public ProductType ProductsType { get; set; }
        public string ProductName { get; set; }
        public Xamarin.Forms.ImageSource ProductImage { get; set; }
        public Model.CategoriesModels ProductCategories { get; set; }
        public double ProductUnitPrice { get; set; }
        public int ProductQte { get; set; }
        public string ProductDiscreption { get; set; }
        public int ProductId { get; set; }
        public int AvisCount { get; set; }
        public ProductsAvis Avis { get; set; }
        public double ProductSalesPrice { get; set; }
        public double Rating { get; set; }
        public bool IsSales { get; set; }
        public DateTime DatePublier { get; set; }
        public double TauxReduce { get; set; }
    }
    public class LocalProductsModels
    {
        public int AvisCount { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Model.CategoriesModels ProductCategories { get; set; }
        public double ProductUnitPrice { get; set; }
        public int ProductQte { get; set; }
        public string ProductDiscreption { get; set; }
        public int ProductId { get; set; }
        public ProductsAvis Avis { get; set; }
        public double ProductSalesPrice { get; set; }
        public double Rating { get; set; }
        public bool IsSales { get; set; }
        public DateTime DatePublier { get; set; }
    }

    public class ProductsAvis
    {
        public string ID { get; set; }
        public string Comment { get; set; }
        public bool IsLike { get; set; }
        public double Rate { get; set; }
    }
}
