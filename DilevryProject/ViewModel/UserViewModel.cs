using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DilevryProject.ViewModel
{
    class UserViewModel:BaseVM
    {
        private string _UserName;
        public string UserName { get => _UserName; set => SetValue(ref _UserName, value); }
        private string _UserPwd;
        public string UserPwd { get => _UserPwd; set => SetValue(ref _UserPwd, value); }
        private ObservableCollection<Model.UserModel> _UserList;
        public ObservableCollection<Model.UserModel> UserList { get => _UserList; set => SetValue(ref _UserList, value); }
       
        private static UserViewModel _Instance;
        public static UserViewModel Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new UserViewModel();
                return _Instance;
            }
        }
        private UserViewModel()
        {
            LoadData();
        }
        private async void LoadData()
        {
            UserList = new ObservableCollection<Model.UserModel>(await Services.UserService.Instance.Allusers());
        }

        public ICommand Login
        {
            get => new Command(() =>
             {
                 var usr = UserList.Where(c => c.UserName == UserName).Where(b => b.UserPassword == UserPwd).Select
                 (o => new Model.UserModel
                 {
                     UserName = o.UserName,
                     UserEmail = o.UserEmail,
                     UserID = o.UserID,
                     FullnName = o.FullnName
                 }); 
                ;
                

                
                 if (usr.Count() > 0)
                 {

                     AppClass.GlobalVariable.CurrentUser = usr.FirstOrDefault();
                     App.Current.MainPage = new Pages.MainMasterPage();                  
                     
                 }
                   
             }); 
        }


    }
}
