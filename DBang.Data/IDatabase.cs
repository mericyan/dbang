using System.Data;
using System.ServiceModel;

namespace DBang.Data
{
    [ServiceContract]
    [ServiceKnownType(typeof (DbType))]
    [ServiceKnownType(typeof (DataParameter))]
    [ServiceKnownType(typeof (DataRowVersion))]
    [ServiceKnownType(typeof (ParameterDirection))]
    public partial interface IDatabase
    {
        [OperationContract]
        object ExecuteScalar(string dataSource, string cmdText, params IDataParameter[] parameters);

        [OperationContract]
        int ExecuteNonQuery(string dataSource, string cmdText, params IDataParameter[] parameters);

        [OperationContract]
        string ExecuteXml(string dataSource, string cmdText, params IDataParameter[] parameters);

        DataSet ExecuteDataSet(string dataSource, string cmdText, params IDataParameter[] parameters);
    }

    public partial interface IDatabase
    {
        [OperationContract]
        object ExecuteScalar(string cmdText, params IDataParameter[] parameters);

        [OperationContract]
        int ExecuteNonQuery(string cmdText, params IDataParameter[] parameters);

        [OperationContract]
        string ExecuteXml(string cmdText, params IDataParameter[] parameters);

        DataSet ExecuteDataSet(string cmdText, params IDataParameter[] parameters);
    }
}