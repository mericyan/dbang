using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using SysHttpContext = System.Web.HttpContext;

namespace DBang.Security
{
    public static class Authentication
    {
        private static readonly Dictionary<string, int> _userActions = new Dictionary<string, int>();

        static Authentication()
        {
            var userActions = (Hashtable) ConfigurationManager.GetSection("authentication.userActions");

            foreach (string action in userActions.Keys)
            {
                int permission = Convert.ToInt32(userActions[action]);

                if (permission == 0 || permission == 1)
                    _userActions.Add(action, permission);
            }
        }

        public static bool Check()
        {
            //if (SysHttpContext.Current.Request.IsLocal)
            //    return true;

            var userId = SysHttpContext.Current.Session["UserId"] as string;
            string action = SysHttpContext.Current.Request.FilePath;
            action = action.Substring(1, action.Length - 6);

            int permission;
            if (_userActions.TryGetValue(action, out permission) && (permission == 0 || userId != null))
                return true;

            SysHttpContext.Current.Response.Write("F:000-0000");
            return false;
        }
    }
}