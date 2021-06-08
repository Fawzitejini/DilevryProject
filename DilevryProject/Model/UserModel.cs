using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.Model
{
    class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullnName { get; set; }
        public string UserPassword { get; set; }
        public Xamarin.Forms.ImageSource UserAvatar { get; set; }
        public string UserEmail { get; set; }
        public double UserFidelParseDiscount { get; set; }
        public bool IsActive { get; set; }
        public string Addresse { get; set; }
    }
}
