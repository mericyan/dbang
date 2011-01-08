using System.Data;

namespace DBang.Data
{
    public partial class Database
    {
        #region IDatabase Members

        public object ExecuteScalar(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteScalar(_defaultDataSource, cmdText, parameters);
        }

        public int ExecuteNonQuery(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteNonQuery(_defaultDataSource, cmdText, parameters);
        }

        public DataSet ExecuteDataSet(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteDataSet(_defaultDataSource, cmdText, parameters);
        }

        public string ExecuteXml(string cmdText, params IDataParameter[] parameters)
        {
            return ExecuteXml(_defaultDataSource, cmdText, parameters);
        }

        #endregion
    }
}