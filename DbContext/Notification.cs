
using System.Data;
using System.Data.SqlClient;
using PeoplePro.Models;

namespace PeoplePro.DbContext;

public class Notification(IConfiguration configuration) : Connection(configuration)
{
    public long Create(string? title, string? content)
    {
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Notification_Create", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlCommand.Parameters.AddWithValue("@Content", content);
                var num = (long) sqlCommand.ExecuteScalar();
                sqlConnection.Close();
                return num;
            }
        }
    }

    public List<NotificationModel> GetList()
    {
        List<NotificationModel> list = new List<NotificationModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Notification_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                    list.Add(new NotificationModel()
                    {
                        NotificationId = Convert.ToInt64(sqlDataReader["NotificationId"]),
                        Title = Convert.ToString(sqlDataReader["Title"]),
                        Content = Convert.ToString(sqlDataReader["Content"]),
                        CreatedAt = Convert.ToDateTime(sqlDataReader["CreatedAt"])
                    });
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return list;
        }
    }
}