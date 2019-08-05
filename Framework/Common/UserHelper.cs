using Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Common
{
    public class UserHelper
    {
        /// <summary>
        /// 一般用于控制台，MVC不使用
        /// </summary>
        public static CurrentUser CurrentUser { get; set; }

        private static string userKey {
            get { return "CurrentUser"; }
        }

        public static void SetCurrentUser(CurrentUser userModel)
        {
            ////使用Cookie
            //{
            //    var cookie = Framework.Common.JsonHelper.Serialize(userModel);

            //    CookieHelper.SetCookie(userKey, CookieHelper.EncryptCookie(cookie));
            //}

            //使用session
            {
                SessionHelper.SetSession(userKey, userModel);
            }
            
        }

        public static CurrentUser GetCurrentUser()
        {
            CurrentUser currentUser = null;

            ////使用Cookie
            //{
            //    string cookieString = CookieHelper.GetCookie(userKey);//使用cookie

            //    if (!string.IsNullOrWhiteSpace(cookieString))
            //    {
            //        string decryptCookie = CookieHelper.DecryptCookie(cookieString);

            //        currentUser = JsonHelper.Deserialize<CurrentUser>(decryptCookie);
            //    }
            //}

            //使用session
            {
                currentUser = SessionHelper.GetSession(userKey) as CurrentUser;
            }

            return currentUser;

            //return System.Web.HttpContext.Current?.Session?["CurrentUser"] as CurrentUser;
        }

        public static void Clear()
        {
            ////使用Cookie
            //CookieHelper.SetCookie(userKey, "", -1);

            //使用session
            SessionHelper.Clear(userKey);
        }
    }
}
