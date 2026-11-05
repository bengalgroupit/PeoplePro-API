using System.Data;
using System.Data.SqlClient;
using PeoplePro.Dtos;

namespace PeoplePro.DbContext;

public class Attendance(IConfiguration configuration) : Connection(configuration)
{
    public DateTime? Take(string? empCode)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_InteAcc_Attendance_Take", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                    var sqlDataReader = sqlCommand.ExecuteReader();
                    if (!sqlDataReader.HasRows)
                        return new DateTime?();
                    var nullable = new DateTime?(new DateTime(1900, 1, 1));
                    if (sqlDataReader.Read())
                        nullable = Convert.ToDateTime(sqlDataReader["AttendTime"]);
                    sqlDataReader.Close();
                    return nullable;
                }
            }
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            return new DateTime?();
        }
    }

    public bool Log(AttendanceDto data, DateTime? attendTime)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetLogConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_Log_Attendance", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", data.EmpCode);
                    sqlCommand.Parameters.AddWithValue("@LatLng", data.LatLng);
                    sqlCommand.Parameters.AddWithValue("@ZoneId", data.ZoneId);
                    sqlCommand.Parameters.AddWithValue("@ClientTime", data.ClientTime);
                    sqlCommand.Parameters.AddWithValue("@AttendTime", attendTime);
                    return sqlCommand.ExecuteNonQuery() == 1;
                }
            }
        }
        catch
        {
            return false;
        }
    }
}