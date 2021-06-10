using System;
using System.Collections.Generic;
using System.Text;

namespace DilevryProject.AppClass
{
    public enum State
    {
        Collaps, Expand
    }
    class GlobalVariable
    {
        public static State States { get; set; }
        public static Model.UserModel CurrentUser { get ; set; }
    }
}
