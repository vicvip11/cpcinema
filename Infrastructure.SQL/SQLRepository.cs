using System.Collections.Generic;
using System.Data.SqlClient;

using Core.Interface;

namespace Infrastructure.SQL
{
    public class SqlRepository : ISqlRepository
    {
        private readonly string _connectionString;
        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<List<object>> CallStoredProcedure(string StoredProcedureQueryString)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(StoredProcedureQueryString, connection);
                connection.Open();
                var data = new List<List<object>>();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rowData = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            rowData.Add(reader[i]);
                        }
                        data.Add(rowData);
                    }
                }
                return data;
            }
        }
    }
}
