using System.Data;
using System.Runtime.Serialization;

namespace DBang.Data
{
    [DataContract]
    public class DataParameter : IDataParameter
    {
        public DataParameter(string parameterName, object value)
        {
            Value = value;
            ParameterName = "@" + parameterName.TrimStart('@');
        }

        #region IDataParameter Members

        [DataMember]
        public object Value { get; set; }

        [DataMember]
        public bool IsNullable { get; set; }

        [DataMember]
        public DbType DbType { get; set; }

        [DataMember]
        public string SourceColumn { get; set; }

        [DataMember]
        public string ParameterName { get; set; }

        [DataMember]
        public ParameterDirection Direction { get; set; }

        [DataMember]
        public DataRowVersion SourceVersion { get; set; }

        #endregion
    }
}