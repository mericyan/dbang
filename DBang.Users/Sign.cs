using System.Collections.Specialized;
using System.Web;

namespace DBang.Users
{
    public partial class UserManager
    {
        public void SignIn(NameValueCollection aa, string xml)
        {
            if (xml == null)
                return;

            HttpContext.Current.Session["UserId"] = "";
            HttpContext.Current.Session["UserRoles"] = "";
        }
    }
}