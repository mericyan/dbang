using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBang.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Common.DbCommand dbc;

            //var g = dbc.ExecuteReader();

            //g.

            var ggg2 = new Database("System.Data.SqlClient", "Server=(local);database=dbang;User ID=sa;Password=sa");

            var fff = ggg2.ExecuteXml("select * from users select * from users");

            //var hhh = fff.GetXml();
        }
    }
}
