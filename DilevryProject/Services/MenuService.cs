using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.Services
{
    class MenuService
    {
        private static MenuService _Instance;
        public static MenuService Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MenuService();
                return _Instance;

            }
        }
        public List<Model.MenuModel> Menuss
        {

            get => new List<Model.MenuModel>
            {
                new Model.MenuModel
                {
                    Captions="Acceuil",Icons=fonts.AwomeSolid.Igloo
                },
                   new Model.MenuModel
                {
                    Captions="Tous les articles",Icons=fonts.AwomeSolid.Store
                },   new Model.MenuModel
                {
                    Captions="Panier",Icons=fonts.AwomeSolid.ShoppingCart
                },   new Model.MenuModel
                {
                    Captions="Compte",Icons=fonts.AwomeSolid.User
                },
            };
        }
    }
}
