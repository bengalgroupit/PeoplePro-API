
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class Report(IConfiguration configuration) : Connection(configuration)
{
    public AttendanceRegularizationReportModel GetAttendances(
        string empCode)
    {
        var attendances = new AttendanceRegularizationReportModel();
        List<AttendanceLineModel> attendanceLineModelList = new List<AttendanceLineModel>();
        attendances.EmpCode = empCode;
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Attendance_Employee_Details", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        attendances.Name = sqlDataReader["Name"].ToString();
                        attendances.JobTitle = sqlDataReader["JobTitle"].ToString();
                        attendances.Company = sqlDataReader["Company"].ToString();
                        attendances.Department = sqlDataReader["Department"].ToString();
                        attendances.OpLocation = sqlDataReader["OpLocation"].ToString();
                    }
                }
                sqlDataReader.Close();
            }
            return attendances;
        }
    }

    public AttendanceReportModel GetAttendances(
        string empCode,
        string fromDate,
        string toDate)
    {
        var attendances = new AttendanceReportModel();
        List<AttendanceLineModel> attendanceLineModelList = new List<AttendanceLineModel>();
        attendances.EmpCode = empCode;
        var attendanceReportModel = attendances;
        var interpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
        interpolatedStringHandler.AppendFormatted<DateTime>(Convert.ToDateTime(fromDate), "dd/MM/yyyy");
        interpolatedStringHandler.AppendLiteral(" to ");
        interpolatedStringHandler.AppendFormatted<DateTime>(Convert.ToDateTime(toDate), "dd/MM/yyyy");
        var stringAndClear = interpolatedStringHandler.ToStringAndClear();
        attendanceReportModel.Period = stringAndClear;
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Attendance_Employee_Details", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        attendances.Name = sqlDataReader["Name"].ToString();
                        attendances.JobTitle = sqlDataReader["JobTitle"].ToString();
                        attendances.Company = sqlDataReader["Company"].ToString();
                        attendances.Department = sqlDataReader["Department"].ToString();
                        attendances.OpLocation = sqlDataReader["OpLocation"].ToString();
                        attendances.Section = sqlDataReader["Section"].ToString();
                    }
                }
                sqlDataReader.Close();
            }
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Report_Job_Card", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                sqlCommand.Parameters.AddWithValue("@FromDate", fromDate);
                sqlCommand.Parameters.AddWithValue("@ToDate", toDate);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                        attendanceLineModelList.Add(new AttendanceLineModel()
                        {
                            Date = Convert.ToDateTime(sqlDataReader["Date"]),
                            Day = Convert.ToString(sqlDataReader["Day"]),
                            Status = Convert.ToString(sqlDataReader["Status"]),
                            InTime = Convert.ToString(sqlDataReader["InTime"]),
                            OutTime = Convert.ToString(sqlDataReader["OutTime"]),
                            LateMinutes = Convert.ToInt32(sqlDataReader["LateMinutes"]),
                            OverTimeHours = Convert.ToDecimal(sqlDataReader["OverTimeHours"]),
                            Remarks = Convert.ToString(sqlDataReader["Remarks"])
                        });
                }
                sqlDataReader.Close();
                attendances.AttendanceLines = attendanceLineModelList;
            }
            return attendances;
        }
    }
}