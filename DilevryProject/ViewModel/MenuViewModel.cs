using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DilevryProject.ViewModel
{
    class MenuViewModel:BaseVM
    {
        private ObservableCollection<Model.MenuModel> _Menus;
        public ObservableCollection<Model.MenuModel> MainMenus { get => _Menus; set => SetValue(ref _Menus, value); }

        private static MenuViewModel _Instance;
        public static MenuViewModel Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new MenuViewModel();
                return _Instance;

            }
        }
        private void LoadData()
        {
            MainMenus = new ObservableCollection<Model.MenuModel>(Services.MenuService.Instance.Menuss);


        }
        public MenuViewModel()
        {
            LoadData();
        }

    }
}
