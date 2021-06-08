using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DilevryProject.Services
{
    class UserService:BaseSevice
    {
        private static UserService _Instance;
        public static UserService Instance
        {
            get {
                if (_Instance == null)
                    _Instance = new UserService();
                return _Instance;
                } 
           }

      public async Task<List<Model.UserModel>> Allusers()
        {
            return (await Clients.Child("Users").OnceAsync<Model.UserModel>()).Select(c => new Model.UserModel 
            { 
                UserEmail = c.Object.UserEmail,
                UserName =c.Object.UserName,
                UserID=c.Object.UserID,
                UserPassword=c.Object.UserPassword
                ,FullnName = c.Object.FullnName
            }).ToList();
        }
       
    }
}
