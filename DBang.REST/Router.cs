using System.Web;
using System.Web.Routing;
using DBang.Data;

namespace DBang.REST
{
    public class Router : IRouteHandler
    {
        private readonly Responser _responser;

        public Router(IDatabase database)
        {
            _responser = new Responser(database);
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return _responser;
        }

        #endregion
    }
}