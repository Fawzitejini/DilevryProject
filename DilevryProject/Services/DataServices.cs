using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilevryProject.Services
{
    class DataServices:BaseSevice
    {
        public static DataServices Instance
        {
            get => new DataServices();
        }

        #region "InternetRequiest"
       private async Task<List<Model.CategoriesModels>> GetLocalCategories()
        {
            return (await Clients.Child("Categories").OnceAsync<Model.LocalCategoriesModels>()).Select(
                c => new Model.CategoriesModels
                {
                    CategoriesID = c.Object.CategoriesID,
                    CategoriesName = c.Object.CategoriesName,
                    CategoriesImage = Yimage(c.Object.CategoriesImage),
                }
                ).ToList();
        }
       private async Task<List<Model.ProductModel>> GetLocalProducts()
        {
            try
            {

           
           
            return (await Clients.Child("Stock").OnceAsync<Model.LocalProductsModels>()).Select(c => new Model.ProductModel
            {
                 Avis=c.Object.Avis,
                  DatePublier =c.Object.DatePublier,
                  ProductCategories =c.Object.ProductCategories,
                  ProductDiscreption=c.Object.ProductDiscreption,
                  ProductId=c.Object.ProductId,
                   IsSales=c.Object.IsSales,
                   ProductImage=Yimage(c.Object.ProductImage),
                    ProductName=c.Object.ProductName,
                   ProductQte=c.Object.ProductQte,
                    ProductSalesPrice=c.Object.ProductSalesPrice,
                    ProductUnitPrice=c.Object.ProductUnitPrice,
                  // Rating=c.Object.Avis.Rate
            }).ToList(); }
           catch (Exception)
            {

                throw new NullReferenceException("This a Catalogue");
            }
        }
        const string Prefix = "Art";
        public async Task<List<Model.ProductsAvis>> Avis(Model.ProductModel f)
        {
            return (await Clients.Child("Stock").Child(Prefix + f.ProductId.ToString()).Child("Avis").OnceAsync<Model.ProductsAvis>()).Select(
                c => new Model.ProductsAvis
                {
                    Comment = c.Object.Comment,
                    Rate = c.Object.Rate
                }).ToList();

        }




        #endregion
        #region "Initialize"
        public async Task<List<Model.CategoriesModels>> GetCategories()
        {
            try
            {
               return (await GetLocalCategories()).Join(await GetLocalProducts(), x => x.CategoriesID, a => a.ProductCategories.CategoriesID, (x, a) => new Model.CategoriesModels
            {
                 CategoriesID = x.CategoriesID,
                 CategoriesImage=x.CategoriesImage,
                 CategoriesName=x.CategoriesName,
            }).ToList().GroupBy(c => c.CategoriesID).Select(a => new Model.CategoriesModels
            {
                CategoriesID = a.FirstOrDefault().CategoriesID,
                CategoriesImage = a.FirstOrDefault().CategoriesImage,
                CategoriesName = a.FirstOrDefault().CategoriesName,
            }).ToList();
            }
            catch (Exception)
            {

                throw new NullReferenceException("This a Categorie");
            }

           
        }
        public async Task<List<Model.ProductModel>> GetAllProducts()
        {
           var im = await GetLocalProducts();
          var CurrentDate = DateTime.Now;
      
            foreach(var x in im)
            {
            var PubDate = x.DatePublier;
              var DateDiff = (CurrentDate.Subtract(PubDate)).TotalDays;
                if (x.IsSales == true)
                {
                    x.ProductsType = Model.ProductType.Sales;
                    x.TauxReduce = (x.ProductUnitPrice - x.ProductSalesPrice) / x.ProductUnitPrice ;
                }
                else if (DateDiff < 10)
                {
                    x.ProductsType = Model.ProductType.New;
                }else{
                    x.ProductsType = Model.ProductType.Normal;
                }
            }
            return im;
        }

        public async Task<List<Model.ProductModel>> GetTopRatedProducts()
        {
            var im = (await GetAllProducts()).Where(b => b.Avis != null).ToList();

            foreach (var xB in im)
            {
                var op = await Avis(xB);
                xB.Rating = op.Sum(c => c.Rate) / op.Count;
                xB.AvisCount = op.Count;
            };
            return im.OrderByDescending(a=>a.Rating).Take(10).ToList();
        }
        public async Task<List<Model.ProductModel>> GetCataloguProducts()
        {
            var im = await GetAllProducts();
            foreach (var xB in im)
            {
                if (xB.IsSales == true)
                {
                    xB.ProductsType = Model.ProductType.Sales;
                }
                else
                {
                    xB.ProductsType = Model.ProductType.Normal;
                }
            };
            return im;
        }
        public async Task<List<Model.ProductModel>> GetSalesProducts()
        {
            var im = (await GetAllProducts()).Where(b => b.IsSales == true).ToList();
          
            return im;
        }
        public async Task<List<Model.ProductModel>> GetNewProducts()
        {
            var im = (await GetAllProducts()).Where(b => (DateTime.Now.Subtract(b.DatePublier)).TotalDays <10).ToList();

            return im;
        }


        #endregion
    }
}
