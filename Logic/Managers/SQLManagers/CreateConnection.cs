using System.Data.SqlClient;

namespace Logic.Managers.SQLManagers
{
    public class CreateConnection
    {
        internal static SqlConnection CreateSqlConnection()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=SHALEV-LAPTOP;Initial Catalog=OOCProject;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            return cnn;
        }
    }
}
