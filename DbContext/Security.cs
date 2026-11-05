
using System.Data;
using System.Data.SqlClient;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class Security(IConfiguration configuration) : Connection(configuration)
{
    public bool ValidateDevice(string userId, string deviceId)
    {
        var flag = false;
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_sec_Device_Status", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.Parameters.AddWithValue("@DeviceId", deviceId);
                    using (var sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        if (sqlDataReader.Read())
                        {
                            if (sqlDataReader["IsActivated"] != DBNull.Value)
                                flag = Convert.ToBoolean(sqlDataReader["IsActivated"]);
                        }
                    }
                }
            }
        }
        catch
        {
            return false;
        }
        return flag;
    }

    public string GetDeviceStatus(string userId, string deviceId)
    {
        var deviceStatus = "Request";
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_sec_Device_Status", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@DeviceId", deviceId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                        deviceStatus = Convert.ToBoolean(sqlDataReader["IsActivated"]) ? "Activated" : "Inactivated";
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
           
            return deviceStatus;
        }
    }

    public bool RemoveDevice(string userId)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_app_Device_Remove", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public bool CreateDeviceRequest(DeviceDto device)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_sec_Device_Request", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", device.UserId);
                    sqlCommand.Parameters.AddWithValue("@DeviceId", device.DeviceId);
                    sqlCommand.Parameters.AddWithValue("@Brand", device.Brand);
                    sqlCommand.Parameters.AddWithValue("@Model", device.Model);
                    sqlCommand.Parameters.AddWithValue("@OsVersion", device.OsVersion);
                    sqlCommand.Parameters.AddWithValue("@Remarks", "");
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public bool CreateLog(LogDto log)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_sec_Log_Create", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", log.UserId);
                    sqlCommand.Parameters.AddWithValue("@LogText", log.LogText);
                    sqlCommand.Parameters.AddWithValue("@LogData", log.LogData);
                    sqlCommand.Parameters.AddWithValue("@LogTypeId", log.LogTypeId);
                    return sqlCommand.ExecuteNonQuery() == 1;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public UserAccessModel GetUserAccess(
        string? userId,
        string? version,
        string? deviceId)
    {
        var userAccess = new UserAccessModel();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_sec_User_Access", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                sqlCommand.Parameters.AddWithValue("@Version", version);
                sqlCommand.Parameters.AddWithValue("@DeviceId", deviceId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows && sqlDataReader.Read())
                {
                    userAccess.UserId = userId;
                    userAccess.EditionId = Convert.ToInt32(sqlDataReader["EditionId"]);
                    userAccess.Edition = Convert.ToString(sqlDataReader["Edition"]);
                    userAccess.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                    userAccess.ControlPanel = Convert.ToBoolean(sqlDataReader["ControlPanel"]);
                    userAccess.Notifier = Convert.ToBoolean(sqlDataReader["Notifier"]);
                    userAccess.ZoneManager = Convert.ToBoolean(sqlDataReader["ZoneManager"]);
                    userAccess.LocationManager = Convert.ToBoolean(sqlDataReader["LocationManager"]);
                    userAccess.AttendanceMonitor = Convert.ToBoolean(sqlDataReader["AttendanceMonitor"]);
                    userAccess.Poll = Convert.ToBoolean(sqlDataReader["Poll"]);
                    userAccess.Directory = Convert.ToBoolean(sqlDataReader["Directory"]);
                    userAccess.Canteen = Convert.ToBoolean(sqlDataReader["Canteen"]);
                    userAccess.Transport = Convert.ToBoolean(sqlDataReader["Transport"]);
                    userAccess.Notification = Convert.ToBoolean(sqlDataReader["Notification"]);
                    userAccess.Notice = Convert.ToBoolean(sqlDataReader["Notice"]);
                    userAccess.Attendance = Convert.ToBoolean(sqlDataReader["Attendance"]);
                    userAccess.Leave = Convert.ToBoolean(sqlDataReader["Leave"]);
                    userAccess.Outstation = Convert.ToBoolean(sqlDataReader["Outstation"]);
                    userAccess.Approval = Convert.ToBoolean(sqlDataReader["Approval"]);
                    userAccess.Payslip = Convert.ToBoolean(sqlDataReader["Payslip"]);
                    userAccess.JobCard = Convert.ToBoolean(sqlDataReader["JobCard"]);
                    userAccess.Holiday = Convert.ToBoolean(sqlDataReader["Holiday"]);
                    userAccess.JobHistory = Convert.ToBoolean(sqlDataReader["JobHistory"]);
                    userAccess.Hiring = Convert.ToBoolean(sqlDataReader["Hiring"]);
                    userAccess.ProvidentFund = Convert.ToBoolean(sqlDataReader["ProvidentFund"]);
                    userAccess.MyProfile = Convert.ToBoolean(sqlDataReader["MyProfile"]);
                    userAccess.Policies = Convert.ToBoolean(sqlDataReader["Policies"]);
                    userAccess.UpdateProfile = Convert.ToBoolean(sqlDataReader["UpdateProfile"]);
                    userAccess.CanteenManager = Convert.ToBoolean(sqlDataReader["CanteenManager"]);
                    userAccess.JobCardDownload = Convert.ToBoolean(sqlDataReader["JobCardDownload"]);
                    userAccess.Regularization = Convert.ToBoolean(sqlDataReader["Regularization"]);
                    userAccess.BusLate = Convert.ToBoolean(sqlDataReader["BusLate"]);
                    userAccess.DriverId = Convert.ToString(sqlDataReader["DriverId"]);
                    userAccess.PrintToken = Convert.ToBoolean(sqlDataReader["PrintToken"]);
                    userAccess.Timeout = Convert.ToInt32(sqlDataReader["Timeout"]);
                    userAccess.DeviceId = Convert.ToString(sqlDataReader["DeviceId"]);
                    userAccess.Debug = Convert.ToBoolean(sqlDataReader["Debug"]);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return userAccess;
        }
    }

    public UserAccessViewModel GetUserAccessGet(string userId)
    {
        var userAccessGet = new UserAccessViewModel();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_sec_User_Access_Get", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserId", userId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows && sqlDataReader.Read())
                {
                    userAccessGet.UserId = Convert.ToString(sqlDataReader["UserId"]);
                    userAccessGet.Name = Convert.ToString(sqlDataReader["Name"]);
                    userAccessGet.Department = Convert.ToString(sqlDataReader["Department"]);
                    userAccessGet.Designation = Convert.ToString(sqlDataReader["Designation"]);
                    userAccessGet.EditionId = Convert.ToInt32(sqlDataReader["EditionId"]);
                    userAccessGet.Edition = Convert.ToString(sqlDataReader["Edition"]);
                    userAccessGet.IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]);
                    userAccessGet.ControlPanel = Convert.ToBoolean(sqlDataReader["ControlPanel"]);
                    userAccessGet.Notifier = Convert.ToBoolean(sqlDataReader["Notifier"]);
                    userAccessGet.ZoneManager = Convert.ToBoolean(sqlDataReader["ZoneManager"]);
                    userAccessGet.LocationManager = Convert.ToBoolean(sqlDataReader["LocationManager"]);
                    userAccessGet.AttendanceMonitor = Convert.ToBoolean(sqlDataReader["AttendanceMonitor"]);
                    userAccessGet.Poll = Convert.ToBoolean(sqlDataReader["Poll"]);
                    userAccessGet.Directory = Convert.ToBoolean(sqlDataReader["Directory"]);
                    userAccessGet.Canteen = Convert.ToBoolean(sqlDataReader["Canteen"]);
                    userAccessGet.Transport = Convert.ToBoolean(sqlDataReader["Transport"]);
                    userAccessGet.Notification = Convert.ToBoolean(sqlDataReader["Notification"]);
                    userAccessGet.Notice = Convert.ToBoolean(sqlDataReader["Notice"]);
                    userAccessGet.Attendance = Convert.ToBoolean(sqlDataReader["Attendance"]);
                    userAccessGet.Leave = Convert.ToBoolean(sqlDataReader["Leave"]);
                    userAccessGet.Outstation = Convert.ToBoolean(sqlDataReader["Outstation"]);
                    userAccessGet.Approval = Convert.ToBoolean(sqlDataReader["Approval"]);
                    userAccessGet.Payslip = Convert.ToBoolean(sqlDataReader["Payslip"]);
                    userAccessGet.JobCard = Convert.ToBoolean(sqlDataReader["JobCard"]);
                    userAccessGet.Holiday = Convert.ToBoolean(sqlDataReader["Holiday"]);
                    userAccessGet.JobHistory = Convert.ToBoolean(sqlDataReader["JobHistory"]);
                    userAccessGet.Hiring = Convert.ToBoolean(sqlDataReader["Hiring"]);
                    userAccessGet.ProvidentFund = Convert.ToBoolean(sqlDataReader["ProvidentFund"]);
                    userAccessGet.MyProfile = Convert.ToBoolean(sqlDataReader["MyProfile"]);
                    userAccessGet.Policies = Convert.ToBoolean(sqlDataReader["Policies"]);
                    userAccessGet.UpdateProfile = Convert.ToBoolean(sqlDataReader["UpdateProfile"]);
                    userAccessGet.CanteenManager = Convert.ToBoolean(sqlDataReader["CanteenManager"]);
                    userAccessGet.JobCardDownload = Convert.ToBoolean(sqlDataReader["JobCardDownload"]);
                    userAccessGet.Regularization = Convert.ToBoolean(sqlDataReader["Regularization"]);
                    userAccessGet.BusLate = Convert.ToBoolean(sqlDataReader["BusLate"]);
                    userAccessGet.DriverId = Convert.ToString(sqlDataReader["DriverId"]);
                    userAccessGet.PrintToken = Convert.ToBoolean(sqlDataReader["PrintToken"]);
                    userAccessGet.Timeout = Convert.ToInt32(sqlDataReader["Timeout"]);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return userAccessGet;
        }
    }

    public bool UpdateUserAccess(UserAccessModel ua)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_sec_User_Access_Update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", ua.UserId);
                    sqlCommand.Parameters.AddWithValue("@EditionId", ua.EditionId);
                    sqlCommand.Parameters.AddWithValue("@IsActive", ua.IsActive);
                    sqlCommand.Parameters.AddWithValue("@ControlPanel", ua.ControlPanel);
                    sqlCommand.Parameters.AddWithValue("@Notifier", ua.Notifier);
                    sqlCommand.Parameters.AddWithValue("@ZoneManager", ua.ZoneManager);
                    sqlCommand.Parameters.AddWithValue("@LocationManager", ua.LocationManager);
                    sqlCommand.Parameters.AddWithValue("@AttendanceMonitor", ua.AttendanceMonitor);
                    sqlCommand.Parameters.AddWithValue("@Poll", ua.Poll);
                    sqlCommand.Parameters.AddWithValue("@Directory", ua.Directory);
                    sqlCommand.Parameters.AddWithValue("@Canteen", ua.Canteen);
                    sqlCommand.Parameters.AddWithValue("@Transport", ua.Transport);
                    sqlCommand.Parameters.AddWithValue("@Notification", ua.Notification);
                    sqlCommand.Parameters.AddWithValue("@Notice", ua.Notice);
                    sqlCommand.Parameters.AddWithValue("@Attendance", ua.Attendance);
                    sqlCommand.Parameters.AddWithValue("@Leave", ua.Leave);
                    sqlCommand.Parameters.AddWithValue("@Outstation", ua.Outstation);
                    sqlCommand.Parameters.AddWithValue("@Approval", ua.Approval);
                    sqlCommand.Parameters.AddWithValue("@Payslip", ua.Payslip);
                    sqlCommand.Parameters.AddWithValue("@JobCard", ua.JobCard);
                    sqlCommand.Parameters.AddWithValue("@Holiday", ua.Holiday);
                    sqlCommand.Parameters.AddWithValue("@JobHistory", ua.JobHistory);
                    sqlCommand.Parameters.AddWithValue("@Hiring", ua.Hiring);
                    sqlCommand.Parameters.AddWithValue("@ProvidentFund", ua.ProvidentFund);
                    sqlCommand.Parameters.AddWithValue("@MyProfile", ua.MyProfile);
                    sqlCommand.Parameters.AddWithValue("@Policies", ua.Policies);
                    sqlCommand.Parameters.AddWithValue("@UpdateProfile", ua.UpdateProfile);
                    sqlCommand.Parameters.AddWithValue("@CanteenManager", ua.CanteenManager);
                    sqlCommand.Parameters.AddWithValue("@PrintToken", ua.PrintToken);
                    sqlCommand.Parameters.AddWithValue("@JobCardDownload", ua.JobCardDownload);
                    sqlCommand.Parameters.AddWithValue("@Regularization", ua.Regularization);
                    sqlCommand.Parameters.AddWithValue("@BusLate", ua.BusLate);
                    sqlCommand.Parameters.AddWithValue("@Timeout", ua.Timeout);
                    sqlCommand.Parameters.AddWithValue("@Debug", ua.Debug);
					return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
        }
        catch (Exception ex)
        {
            var message = ex.Message;
            return false;
        }
    }
}