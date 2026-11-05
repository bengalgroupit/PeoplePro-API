// Decompiled with JetBrains decompiler
// Type: Hive.DbContext.Hive
// Assembly: Hive, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E73FBB45-C142-4356-94F4-2ADAD06710FA
// Assembly location: C:\Users\Jakir\Desktop\Hive\Hive.dll

using System.Data;
using System.Data.SqlClient;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class Hive(IConfiguration configuration) : Connection(configuration)
{
    public List<EditionModel> GetEditions()
    {
        List<EditionModel> editions = new List<EditionModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Edition_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var editionModel = new EditionModel()
                    {
                        EditionId = Convert.ToInt32(sqlDataReader["EditionId"]),
                        Name = sqlDataReader["Name"].ToString()
                    };
                    editions.Add(editionModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return editions;
        }
    }

	public List<UserAppUpdatedViewModel> GetUserAppUpdated()
	{
		var items = new List<UserAppUpdatedViewModel>();
		using (var sqlConnection = new SqlConnection(GetConnectionString()))
		{
			sqlConnection.Open();
			using (var sqlCommand = new SqlCommand("usp_app_Updated_List", sqlConnection))
			{
				sqlCommand.CommandType = CommandType.StoredProcedure;
				var dr = sqlCommand.ExecuteReader();
				while (dr.Read())
				{
					var item = new UserAppUpdatedViewModel
					{
						UserId = dr["UserId"].ToString(),
						Name = dr["Name"].ToString(),
						Designation = dr["Designation"].ToString(),
						Department = dr["Department"].ToString(),
						UpdatedAt = Convert.ToDateTime(dr["UpdatedAt"])
					};
					items.Add(item);
				}
				dr.Close();
			}
			sqlConnection.Close();
			return items;
		}
	}


	public List<PolicyModel> GetPolicies()
    {
        List<PolicyModel> policies = new List<PolicyModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Policy_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var policyModel = new PolicyModel()
                    {
                        PolicyId = Convert.ToInt32(sqlDataReader["PolicyId"]),
                        Title = sqlDataReader["Title"].ToString(),
                        Subtitle = sqlDataReader["Subtitle"].ToString(),
                        Content = sqlDataReader["Content"].ToString()
                    };
                    policies.Add(policyModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return policies;
        }
    }

    public List<DepartmentModel> GetDepartments()
    {
        List<DepartmentModel> departments = new List<DepartmentModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Department_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var departmentModel = new DepartmentModel()
                    {
                        DepartmentId = sqlDataReader["DepartmentId"].ToString(),
                        Name = sqlDataReader["Name"].ToString()
                    };
                    departments.Add(departmentModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return departments;
        }
    }

    public List<EmployeeAttendanceModel> GetEmployeeAttendances(
        string departmentId,
        DateTime date)
    {
        List<EmployeeAttendanceModel> employeeAttendances = new List<EmployeeAttendanceModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Employee_Attendance_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@DepartmentId", departmentId);
                sqlCommand.Parameters.AddWithValue("@EntryDate", date);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var employeeAttendanceModel = new EmployeeAttendanceModel()
                    {
                        EmpCode = sqlDataReader["EmpCode"].ToString(),
                        Name = sqlDataReader["Name"].ToString(),
                        Designation = sqlDataReader["Designation"].ToString(),
                        Section = sqlDataReader["Section"].ToString(),
                        Department = sqlDataReader["Department"].ToString(),
                        Location = sqlDataReader["Location"].ToString(),
                        Company = sqlDataReader["Company"].ToString(),
                        EntryTime = sqlDataReader["EntryTime"].ToString(),
                        WorkShirtStart = sqlDataReader["WorkShirtStart"].ToString(),
                        GraceMinute = Convert.ToInt32(sqlDataReader["GraceMinute"]),
                        AttendSource = sqlDataReader["AttendSource"].ToString(),
                        IsPresent = Convert.ToBoolean(sqlDataReader["IsPresent"]),
                        IsLate = Convert.ToBoolean(sqlDataReader["IsLate"]),
                        LateMinute = Convert.ToInt32(sqlDataReader["LateMinute"])
                    };
                    employeeAttendances.Add(employeeAttendanceModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return employeeAttendances;
        }
    }

    public List<HolidayModel> GetHolidays()
    {
        List<HolidayModel> holidays = new List<HolidayModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Holiday_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var holidayModel = new HolidayModel()
                    {
                        HolidayId = Convert.ToInt32(sqlDataReader["HolidayId"]),
                        Event = sqlDataReader["Event"].ToString(),
                        Date = sqlDataReader["Date"].ToString(),
                        Day = sqlDataReader["Day"].ToString(),
                        EventDate = Convert.ToDateTime(sqlDataReader["EventDate"]),
                        IsUpcoming = Convert.ToBoolean(sqlDataReader["IsUpcoming"]),
                        DayCount = Convert.ToInt32(sqlDataReader["DayCount"]),
                        StartDate = Convert.ToDateTime(sqlDataReader["StartDate"]),
                        EndDate = Convert.ToDateTime(sqlDataReader["EndDate"])
                    };
                    holidays.Add(holidayModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return holidays;
        }
    }

    public List<NoticeModel> GetNotices()
    {
        List<NoticeModel> notices = new List<NoticeModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Notice_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var noticeModel = new NoticeModel()
                    {
                        NoticeId = Convert.ToInt64(sqlDataReader["NoticeId"]),
                        Title = sqlDataReader["Title"].ToString(),
                        Image = sqlDataReader["Image"].ToString(),
                        Thumbnail = sqlDataReader["Thumbnail"].ToString(),
                        PublishDate = Convert.ToDateTime(sqlDataReader["PublishDate"]),
                        Content = sqlDataReader["Content"].ToString(),
                        IsActive = Convert.ToBoolean(sqlDataReader["IsActive"])
                    };
                    notices.Add(noticeModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return notices;
        }
    }

    public List<NoticeModel> GetActiveNotices()
    {
        List<NoticeModel> activeNotices = new List<NoticeModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Notice_Active", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var noticeModel = new NoticeModel()
                    {
                        NoticeId = Convert.ToInt64(sqlDataReader["NoticeId"]),
                        Title = sqlDataReader["Title"].ToString(),
                        Image = sqlDataReader["Image"].ToString(),
                        Thumbnail = sqlDataReader["Thumbnail"].ToString(),
                        PublishDate = Convert.ToDateTime(sqlDataReader["PublishDate"]),
                        Content = sqlDataReader["Content"].ToString(),
                        IsActive = Convert.ToBoolean(sqlDataReader["IsActive"])
                    };
                    activeNotices.Add(noticeModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return activeNotices;
        }
    }

    public List<ZoneModel> GetUserZones(string latLng)
    {
        List<ZoneModel> userZones = new List<ZoneModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_User_Zone_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@LatLng", latLng);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var zoneModel = new ZoneModel()
                    {
                        ZoneId = Convert.ToInt64(sqlDataReader["ZoneId"]),
                        Name = sqlDataReader["Name"].ToString(),
                        Latitude = Convert.ToDouble(sqlDataReader["Latitude"]),
                        Longitude = Convert.ToDouble(sqlDataReader["Longitude"])
                    };
                    userZones.Add(zoneModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return userZones;
        }
    }

    public long GetLastNotificationId()
    {
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            long lastNotificationId;
            using (var sqlCommand = new SqlCommand("usp_Notification_LastId", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                lastNotificationId = (long) sqlCommand.ExecuteScalar();
            }
            sqlConnection.Close();
            return lastNotificationId;
        }
    }

    public PopupNotification GetPopupNotification()
    {
        var popupNotification = new PopupNotification();
        popupNotification.ImageName = string.Empty;
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Popup_Notification_Get", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        popupNotification.NotificationId = Convert.ToInt32(sqlDataReader["NotificationId"]);
                        popupNotification.ImageName = Convert.ToString(sqlDataReader["ImageName"]);
                        popupNotification.IsRepeated = Convert.ToBoolean(sqlDataReader["IsRepeated"]);
                    }
                }
            }
            sqlConnection.Close();
            return popupNotification;
        }
    }

    public PollVIewModel GetPoll(string empCode)
    {
        var poll = new PollVIewModel();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Poll_Get", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows && sqlDataReader.Read())
                {
                    poll.Poll.PollId = Convert.ToInt32(sqlDataReader["PollId"]);
                    poll.Poll.Name = Convert.ToString(sqlDataReader["Name"]);
                    poll.Poll.Description = Convert.ToString(sqlDataReader["Description"]);
                    poll.Poll.StartTime = Convert.ToDateTime(sqlDataReader["StartTime"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    poll.Poll.EndTime = Convert.ToDateTime(sqlDataReader["EndTime"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    poll.Poll.PollLineId = Convert.ToInt32(sqlDataReader["PollLineId"]);
                    poll.Poll.PollTotal = Convert.ToInt32(sqlDataReader["PollTotal"]);
                }
                sqlDataReader.Close();
            }
            using (var sqlCommand = new SqlCommand("usp_Poll_Line_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PollId", poll.Poll.PollId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return poll;
                while (sqlDataReader.Read())
                {
                    var pollLineModel = new PollLineModel()
                    {
                        PollLineId = Convert.ToInt32(sqlDataReader["PollLineId"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        PollLineCount = Convert.ToInt32(sqlDataReader["PollLineCount"]),
                        PollPercent = Convert.ToDecimal(sqlDataReader["PollPercent"])
                    };
                    poll.PollLines.Add(pollLineModel);
                }
                sqlDataReader.Close();
            }
            return poll;
        }
    }

    public bool SubmitPoll(string empCode, long pollLineId)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_Poll_Submit", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                    sqlCommand.Parameters.AddWithValue("@PollLineId", pollLineId);
                    return sqlCommand.ExecuteNonQuery() == 1;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public List<HubUserViewModel> GetHubUsers()
    {
        List<HubUserViewModel> hubUsers = new List<HubUserViewModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Hub_User_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    try
                    {
                        var hubUserViewModel = new HubUserViewModel()
                        {
                            EmpCode = Convert.ToString(sqlDataReader["EmpCode"]),
                            Name = Convert.ToString(sqlDataReader["Name"]),
                            Designation = Convert.ToString(sqlDataReader["Designation"]),
                            Department = Convert.ToString(sqlDataReader["Department"]),
                            LastSeen = Convert.ToDateTime(sqlDataReader["LastSeen"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                            Photo = (byte[]) sqlDataReader["Photo"],
                            ConnectionId = Convert.ToString(sqlDataReader["ConnectionId"]),
                            IsConnected = Convert.ToBoolean(sqlDataReader["IsConnected"])
                        };
                        hubUsers.Add(hubUserViewModel);
                    }
                    catch
                    {
                    }
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return hubUsers;
        }
    }

    public bool UpdateHubUser(HubUserViewModel user)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_Hub_User_Update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", user.EmpCode);
                    sqlCommand.Parameters.AddWithValue("@ConnectionId", user.ConnectionId);
                    sqlCommand.Parameters.AddWithValue("@IsConnected", user.IsConnected);
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