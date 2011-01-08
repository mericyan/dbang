using System;
using System.Data;
using System.Data.Common;

namespace DBang.Data
{
    public partial class Database
    {
        #region IDatabase Members

        public object ExecuteScalar(string dataSource, string cmdText, params IDataParameter[] parameters)
        {
            Func<DbCommand, object> executeScalar = comm => comm.ExecuteScalar();

            return Execute(executeScalar, dataSource, cmdText, parameters);
        }

        public int ExecuteNonQuery(string dataSource, string cmdText, params IDataParameter[] parameters)
        {
            Func<DbCommand, int> executeNonQuery = comm => comm.ExecuteNonQuery();

            return Execute(executeNonQuery, dataSource, cmdText, parameters);
        }

        public DataSet ExecuteDataSet(string dataSource, string cmdText, params IDataParameter[] parameters)
        {
            Func<DbCommand, DataSet> executeDataSet = comm =>
            {
                var dsResult = new DataSet();

                using (DbDataAdapter adapter = _dbProviderFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = comm;
                    adapter.Fill(dsResult);
                }

                return dsResult;
            };

            return Execute(executeDataSet, dataSource, cmdText, parameters);
        }

        public string ExecuteXml(string dataSource, string cmdText, params IDataParameter[] parameters)
        {
            const string fmtResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?><tables>{0}</tables>";
            const string fmtTable = "<table{0}>{1}</table{0}>";
            const string fmtRow = "<row {0}/>";
            const string fmtColumn = "{0}=\"{1}\" ";

            Func<DbCommand, string> executeXml = comm =>
            {
                string xmlResult;

                using (DbDataReader reader = comm.ExecuteReader())
                {
                    int i = 0;
                    string xmlTables = "";

                    do
                    {
                        string xmlRows = "";

                        while (reader.Read())
                        {
                            string xmlColumns = "";

                            for (int j = 0; j < reader.VisibleFieldCount; j++)
                            {
                                if (reader.IsDBNull(j))
                                    continue;

                                string name = reader.GetName(j);
                                string value = Convert.ToString(reader.GetValue(j));
                                name = string.IsNullOrEmpty(name) ? "column" + j : name;

                                xmlColumns += string.Format(fmtColumn, name, value);
                            }

                            xmlRows += string.Format(fmtRow, xmlColumns);
                        }

                        xmlTables += string.Format(fmtTable, i++, xmlRows);
                    } while (reader.NextResult());

                    xmlResult = string.Format(fmtResult, xmlTables);
                }

                return xmlResult;
            };

            return Execute(executeXml, dataSource, cmdText, parameters);
        }

        #endregion
    }
}