using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using DBang.Data;
using DBang.Messages;
using DBang.Users;

namespace DBang.Config
{
    public static class Instances
    {
        private static readonly ISender _smsSender;
        private static readonly IDatabase _database;
        private static readonly UserManager _userManager;

        static Instances()
        {
            RESTingHandles = new Dictionary<string, Func<NameValueCollection, bool>>();
            RESTedHandles = new Dictionary<string, Action<NameValueCollection, string>>();

            _smsSender = new SmsSender("", "", "");
            _userManager = new UserManager(_smsSender);
            _database = new Database("System.Data.SqlClient", "Server=(local);database=dbang;User ID=sa;Password=sa");

            RESTedHandles.Add("sign_in", _userManager.SignIn);
        }

        public static IDatabase Database
        {
            get { return _database; }
        }

        public static Dictionary<string, Func<NameValueCollection, bool>> RESTingHandles { get; private set; }

        public static Dictionary<string, Action<NameValueCollection, string>> RESTedHandles { get; private set; }
    }
}