using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DBang.Data
{
    public partial class Database : IDatabase
    {
        private readonly Dictionary<string, string> _connStrings;
        private readonly DbProviderFactory _dbProviderFactory;
        private readonly string _defaultDataSource;

        public Database(string providerInvariantName, params string[] connStrings)
        {
            _connStrings = new Dictionary<string, string>();
            _dbProviderFactory = DbProviderFactories.GetFactory(providerInvariantName);

            foreach (string connString in connStrings)
            {
                using (DbConnection conn = _dbProviderFactory.CreateConnection())
                {
                    conn.ConnectionString = connString;
                    _connStrings[conn.DataSource] = connString;

                    if (_defaultDataSource == null)
                        _defaultDataSource = conn.DataSource;
                }
            }
        }

        private TResult Execute<TResult>(Func<DbCommand, TResult> execute, string dataSource, string cmdText, params IDataParameter[] parameters)
        {
            TResult result = default(TResult);

            using (DbConnection conn = _dbProviderFactory.CreateConnection())
            {
                using (DbCommand comm = conn.CreateCommand())
                {
                    try
                    {
                        if (parameters != null && parameters.Length > 0)
                            comm.AddParameters(parameters);

                        comm.CommandText = cmdText;
                        comm.Connection.ConnectionString = _connStrings[dataSource];
                        comm.CommandType = cmdText.Contains(" ") ? CommandType.Text : CommandType.StoredProcedure;

                        comm.Connection.Open();
                        using (comm.Transaction = conn.BeginTransaction())
                        {
                            result = execute(comm);
                            comm.Transaction.Commit();
                        }
                    }
                    catch (Exception exp)
                    {
                        exp.Alert(this);

                        if (comm.Transaction != null)
                            comm.Transaction.Rollback();
                    }
                }
            }

            return result;
        }
    }
}