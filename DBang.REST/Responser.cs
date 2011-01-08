using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;
using DBang.Config;
using DBang.Data;
using DBang.Security;

namespace DBang.REST
{
    public class Responser : IHttpHandler, IRequiresSessionState
    {
        private readonly IDatabase _database;

        public Responser(IDatabase database)
        {
            _database = database;
        }

        #region IHttpHandler Members

        public void ProcessRequest(HttpContext context)
        {
            if (!Authentication.Check())
                return;

            string action = context.Request.FilePath;
            action = action.Substring(1, action.Length - 6);
            var paramCollection = new NameValueCollection(context.Request.Form);

            if (Instances.RESTingHandles.ContainsKey(action) && !Instances.RESTingHandles[action](paramCollection))
                return;

            var dataParams = new List<DataParameter>();
            foreach (string key in paramCollection.AllKeys)
                dataParams.Add(new DataParameter(key, paramCollection[key]));

            string xmlResponse = _database.ExecuteXml(action, dataParams.ToArray());
            xmlResponse = xmlResponse ?? "E:000-0000";
            context.Response.Write(xmlResponse);

            if (Instances.RESTedHandles.ContainsKey(action))
                Instances.RESTedHandles[action](paramCollection, xmlResponse);
        }

        public bool IsReusable
        {
            get { return true; }
        }

        #endregion
    }
}