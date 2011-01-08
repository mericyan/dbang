using System;
using System.Data;
using System.Data.Common;

namespace DBang.Data
{
    public static class DbCommandExtensions
    {
        public static void AddParameters(this DbCommand comm, params IDataParameter[] parameters)
        {
            foreach (IDataParameter param in parameters)
            {
                DbParameter newParam = comm.CreateParameter();

                newParam.DbType = param.DbType;
                newParam.Direction = param.Direction;
                newParam.IsNullable = param.IsNullable;
                newParam.SourceColumn = param.SourceColumn;
                newParam.ParameterName = param.ParameterName;
                newParam.Value = param.Value ?? DBNull.Value;

                if (param.SourceVersion != 0)
                    newParam.SourceVersion = param.SourceVersion;

                comm.Parameters.Add(newParam);
            }
        }
    }
}