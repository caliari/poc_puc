using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIG.Models
{
    public class UserModel
    {
        public const string USER_SESSION_KEY = "USER_VIEW_KEY";
        
        public Usuario usuario { get; set; }
        
        public static UserModel AuthenticatedUser
        {
            get
            {
                return HttpContext.Current.Session[USER_SESSION_KEY] as UserModel;
            }
        }

        public static void Disconnect()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}