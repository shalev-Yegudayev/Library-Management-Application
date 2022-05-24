using System.Data.SqlClient;

namespace Logic.Managers.SQLManagers
{
    internal class ExecuteCommands
    {
        internal static SqlDataReader ExecuteSelect(string selectStatement)
        {
            SqlCommand sqlCommand = CreateNewCommand(selectStatement);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            sqlCommand.Dispose();
            return reader;
        }

        internal static void ExecuteInsert(string insertStatement)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand sqlCommand = CreateNewCommand(insertStatement);
            adapter.InsertCommand = sqlCommand;
            adapter.InsertCommand.ExecuteNonQuery();

            sqlCommand.Dispose();
        }

        private static SqlCommand CreateNewCommand(string sqlStatement)
        {
            SqlConnection cnn = CreateConnection.CreateSqlConnection();

            SqlCommand sqlCommand;
            string sql;

            sql = sqlStatement;
            sqlCommand = new SqlCommand(sql, cnn);
            return sqlCommand;
        }

    }

}
