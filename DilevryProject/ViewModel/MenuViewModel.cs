using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace DilevryProject.ViewModel
{
    class MenuViewModel:BaseVM
    {
        private string _UserFullName;
        public string UserFullName { get => _UserFullName; set => SetValue(ref _UserFullName, value); }
        private string _UserEmail;
        public string UserEmail { get => _UserEmail; set => SetValue(ref _UserEmail, value); }
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
            UserFullName = AppClass.GlobalVariable.CurrentUser.FullnName;
            UserEmail = AppClass.GlobalVariable.CurrentUser.UserEmail;
        }
        public MenuViewModel()
        {
            LoadData();
        }

    }
}
