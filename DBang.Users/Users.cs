using System;
using DBang.Data;
using DBang.Messages;
using DBang.Users.Entities;
using System.Data;
using System.Globalization;

namespace DBang.Users
{
    public partial class UserManager
    {
        private static readonly Random _vCodeGen = new Random();
        //private readonly IDatabase _database;
        private readonly ISender _sender;

        public UserManager(ISender sender)
        {
            _sender = sender;
            //_database = database;
        }
    }
}
