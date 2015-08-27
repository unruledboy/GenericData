using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OverflowStack.GenericData.ServerDomains.DataAccess;
using OverflowStack.GenericData.ServerDomains.Models;
using OverflowStack.GenericData.SharedDomains.Models;

namespace OverflowStack.GenericData.Services.Logic.DataAccess
{
    public class SqlDataAccess : BaseDataAccess
    {
        private static readonly Dictionary<string, SqlDbType> Mappings = new Dictionary<string, SqlDbType>
        {
            {"BYTE", SqlDbType.TinyInt},
            {"INT16", SqlDbType.SmallInt},
            {"INT32", SqlDbType.Int},
            {"INT64", SqlDbType.BigInt},
            {"BOOLEAN", SqlDbType.Bit},
            {"DOUBLE", SqlDbType.Float},
            {"DECIMAL", SqlDbType.Money},
            {"DATE", SqlDbType.Date},
            {"DATETIME", SqlDbType.DateTime},
            {"DATETIME2", SqlDbType.DateTime},
            {"NSTRING", SqlDbType.NVarChar},
            {"STRING", SqlDbType.VarChar},
            {"NCHAR", SqlDbType.NChar},
            {"CHAR", SqlDbType.Char},
            {"XML", SqlDbType.Xml},
            {"GUID", SqlDbType.UniqueIdentifier}
        };

        public override string ConnectionType
        {
            get { return "SQLServer"; }
        }

        public override DataList Process(Request request, Connection connection, Schema schema)
        {
            var result = new DataList();
            using (var sqlConnection = new SqlConnection(connection.ConnectionString))
            {
                var command = sqlConnection.CreateCommand();
                command.CommandText = schema.CommandText;
                command.CommandType = (CommandType)Enum.Parse(typeof(CommandType), schema.CommandType);
                foreach (var parameter in schema.Parameters)
                {
                    var sqlParameter = new SqlParameter(parameter.Name, MapType(parameter.DataType));
                    switch (sqlParameter.SqlDbType)
                    {
                        case SqlDbType.Binary:
                        case SqlDbType.Char:
                        case SqlDbType.NChar:
                        case SqlDbType.NVarChar:
                        case SqlDbType.VarBinary:
                        case SqlDbType.VarChar:
                            sqlParameter.Size = parameter.Size;
                            break;
                        case SqlDbType.Decimal:
                            sqlParameter.Precision = parameter.Precision;
                            break;
                    }
                    sqlParameter.Precision = parameter.Precision;
                    command.Parameters.Add(sqlParameter);
                }
                sqlConnection.Open();
                var data = request.Payload.Data;
                var recordCount = data.Records.Count;
                if (recordCount > 0)
                {
                    for (var i = 0; i < recordCount; i++)
                    {
                        var record = data.Records[i];
                        for (var j = 0; j < data.Columns.Count; j++)
                        {
                            var parameter = command.Parameters[data.Columns[j]];
                            switch (parameter.SqlDbType)
                            {
                                case SqlDbType.UniqueIdentifier:
                                    parameter.Value = Guid.Parse(record.Values[j].ToString());
                                    break;
                                default:
                                    parameter.Value = record.Values[j];
                                    break;
                            }
                        }
                        AddData(result, command);
                    }
                }
                else
                    AddData(result, command);
                sqlConnection.Close();
            }
            return result;
        }

        private void AddData(DataList result, SqlCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                if (result.Columns == null)
                    result.Columns = new List<string>();
                if (result.Records == null)
                    result.Records = new List<DataRecord>();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    result.Columns.Add(reader.GetName(i));
                }
                while (reader.Read())
                {
                    var record = new DataRecord { Values = new List<object>() };
                    foreach (var column in result.Columns)
                    {
                        record.Values.Add(reader[column]);
                    }
                    result.Records.Add(record);
                }
            }
        }

        private SqlDbType MapType(string dataType)
        {
            SqlDbType type;
            if (Mappings.TryGetValue(dataType.ToUpperInvariant(), out type))
                return type;
            return SqlDbType.NVarChar;
        }
    }
}