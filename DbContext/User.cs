
using System.Data;
using System.Data.SqlClient;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class User(IConfiguration configuration) : Connection(configuration)
{
    public List<LeaveApplicationModel> GetLeaveApplications(string empId)
    {
        List<LeaveApplicationModel> leaveApplications = new List<LeaveApplicationModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Leave_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var applicationModel = new LeaveApplicationModel()
                    {
                        ApplicationDate = Convert.ToDateTime(sqlDataReader["ApplicationDate"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        StartDate = Convert.ToDateTime(sqlDataReader["StartDate"]),
                        EndDate = Convert.ToDateTime(sqlDataReader["EndDate"]),
                        TotalDays = Convert.ToDouble(sqlDataReader["TotalDays"]),
                        Remarks = Convert.ToString(sqlDataReader["Remarks"]),
                        Status = Convert.ToString(sqlDataReader["Status"]),
                        LeaveType = Convert.ToString(sqlDataReader["LeaveType"]),
                        DurationType = Convert.ToString(sqlDataReader["DurationType"]),
                        DocNumber = Convert.ToString(sqlDataReader["DocNumber"])
                    };
                    leaveApplications.Add(applicationModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return leaveApplications;
        }
    }

    public List<OutstationModel> GetOutstationDuties(string empId)
    {
        List<OutstationModel> outstationDuties = new List<OutstationModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Outstation_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                    outstationDuties.Add(new OutstationModel()
                    {
                        ApplicationDate = Convert.ToDateTime(sqlDataReader["ApplicationDate"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        StartDate = Convert.ToDateTime(sqlDataReader["StartDate"]),
                        EndDate = Convert.ToDateTime(sqlDataReader["EndDate"]),
                        TotalDays = Convert.ToDouble(sqlDataReader["TotalDays"]),
                        Location = Convert.ToString(sqlDataReader["Location"]),
                        Status = Convert.ToString(sqlDataReader["Status"]),
                        DurationType = Convert.ToString(sqlDataReader["DurationType"]),
                        DocNumber = Convert.ToString(sqlDataReader["DocNumber"])
                    });
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return outstationDuties;
        }
    }

    public List<LeaveApplicationApprovalModel> GetLeaveApprovals(
        string empId,
        string docNumber)
    {
        List<LeaveApplicationApprovalModel> leaveApprovals = new List<LeaveApplicationApprovalModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Leave_Action_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                sqlCommand.Parameters.AddWithValue("@DocNumber", docNumber);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var applicationApprovalModel = new LeaveApplicationApprovalModel()
                    {
                        StepNumber = Convert.ToInt32(sqlDataReader["StepNumber"]),
                        ActionDate = Convert.ToDateTime(sqlDataReader["ActionDate"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        TaskName = Convert.ToString(sqlDataReader["TaskName"]),
                        Approver = Convert.ToString(sqlDataReader["Approver"]),
                        Status = Convert.ToString(sqlDataReader["Status"])
                    };
                    leaveApprovals.Add(applicationApprovalModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return leaveApprovals;
        }
    }

    public List<OutstationApprovalModel> GetOutstationApprovals(
        string empId,
        string docNumber)
    {
        List<OutstationApprovalModel> outstationApprovals = new List<OutstationApprovalModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Get_Outstation_Action_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                sqlCommand.Parameters.AddWithValue("@DocNumber", docNumber);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var outstationApprovalModel = new OutstationApprovalModel()
                    {
                        StepNumber = Convert.ToInt32(sqlDataReader["StepNumber"]),
                        ActionDate = Convert.ToDateTime(sqlDataReader["ActionDate"]).ToString("yyyy-MM-ddTHH:mm:ss.fffZ"),
                        TaskName = Convert.ToString(sqlDataReader["TaskName"]),
                        Approver = Convert.ToString(sqlDataReader["Approver"]),
                        Status = Convert.ToString(sqlDataReader["Status"])
                    };
                    outstationApprovals.Add(outstationApprovalModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return outstationApprovals;
        }
    }

    public List<JobCardModel> GetJobCard(
        string empId,
        string fromDate,
        string toDate)
    {
        List<JobCardModel> jobCard = new List<JobCardModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Job_Card", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                sqlCommand.Parameters.AddWithValue("@FromDate", fromDate);
                sqlCommand.Parameters.AddWithValue("@ToDate", toDate);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return jobCard;
                while (sqlDataReader.Read())
                    jobCard.Add(new JobCardModel()
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
                return jobCard;
            }
        }
    }

    public List<ProvidentFundModel> GetProvidentFund(
        string empId,
        DateTime fromDate,
        DateTime toDate)
    {
        List<ProvidentFundModel> providentFund = new List<ProvidentFundModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_Provident_Fund", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                sqlCommand.Parameters.AddWithValue("@FromDate", fromDate);
                sqlCommand.Parameters.AddWithValue("@ToDate", toDate);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return providentFund;
                while (sqlDataReader.Read())
                {
                    var providentFundModel = new ProvidentFundModel()
                    {
                        PayrollNo = Convert.ToString(sqlDataReader["PayrollNo"]),
                        SalaryPeriod = Convert.ToString(sqlDataReader["SalaryPeriod"]),
                        Amount = Convert.ToDecimal(sqlDataReader["Amount"])
                    };
                    providentFund.Add(providentFundModel);
                }
                return providentFund;
            }
        }
    }

    public UserInformationViewModel GetUserInformation(string empCode)
    {
        var userInformation = new UserInformationViewModel();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_User_Information", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return userInformation;
                while (sqlDataReader.Read())
                {
                    userInformation.EmpId = Convert.ToString(sqlDataReader["EmpId"]);
                    userInformation.EmpCode = Convert.ToString(sqlDataReader["EmpCode"]);
                    userInformation.Name = Convert.ToString(sqlDataReader["Name"]);
                    userInformation.Designation = Convert.ToString(sqlDataReader["Designation"]);
                    userInformation.DepartmentName = Convert.ToString(sqlDataReader["DepartmentName"]);
                    userInformation.DepartmentId = Convert.ToString(sqlDataReader["DepartmentId"]);
                    userInformation.CompanyName = Convert.ToString(sqlDataReader["CompanyName"]);
                    userInformation.CompanyCode = Convert.ToString(sqlDataReader["CompanyCode"]);
                    if (!sqlDataReader.IsDBNull(sqlDataReader.GetOrdinal("Photo")))
                        userInformation.Photo = (byte[]) sqlDataReader["Photo"];
                    userInformation.BirthDate = Convert.ToDateTime(sqlDataReader["BirthDate"]);
                    userInformation.Gender = Convert.ToString(sqlDataReader["Gender"]);
                    userInformation.MobileNo = Convert.ToString(sqlDataReader["MobileNo"]);
                    userInformation.JoiningDate = Convert.ToDateTime(sqlDataReader["JoiningDate"]);
                    userInformation.ConfirmationDate = Convert.ToDateTime(sqlDataReader["ConfirmationDate"]);
                    userInformation.BloodGroup = Convert.ToString(sqlDataReader["BloodGroup"]);
                    userInformation.MaritalStatus = Convert.ToString(sqlDataReader["MaritalStatus"]);
                    userInformation.Email = Convert.ToString(sqlDataReader["Email"]);
                    userInformation.NID = Convert.ToString(sqlDataReader["NID"]);
                    userInformation.CurrentAddress = Convert.ToString(sqlDataReader["CurrentAddress"]);
                    userInformation.PermanentAddress = Convert.ToString(sqlDataReader["PermanentAddress"]);
                    userInformation.MotherName = Convert.ToString(sqlDataReader["MotherName"]);
                    userInformation.FatherName = Convert.ToString(sqlDataReader["FatherName"]);
                    userInformation.BankAccountNo = Convert.ToString(sqlDataReader["BankAccountNo"]);
                    userInformation.GrossSalary = Convert.ToString(sqlDataReader["GrossSalary"]);
                    userInformation.SpouseName = Convert.ToString(sqlDataReader["SpouseName"]);
                    userInformation.OperatingLocation = Convert.ToString(sqlDataReader["OperatingLocation"]);
                    userInformation.OperatingAddress = Convert.ToString(sqlDataReader["OperatingAddress"]);
                    userInformation.AttendanceLocation = Convert.ToString(sqlDataReader["AttendanceLocation"]);
                    userInformation.AttendanceLocationId = Convert.ToString(sqlDataReader["AttendanceLocationId"]);
                    userInformation.ManagerName = Convert.ToString(sqlDataReader["ManagerName"]);
                    userInformation.ManagerDesignation = Convert.ToString(sqlDataReader["ManagerDesignation"]);
                }
                return userInformation;
            }
        }
    }

    public List<UserAttendanceZoneModel> GetUserAttendanceZones(
        string empCode,
        string attendanceLocationId)
    {
        List<UserAttendanceZoneModel> userAttendanceZones = new List<UserAttendanceZoneModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_User_Attendance_Zones", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                sqlCommand.Parameters.AddWithValue("@AttendanceLocationId", attendanceLocationId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var attendanceZoneModel = new UserAttendanceZoneModel()
                    {
                        ZoneId = Convert.ToInt64(sqlDataReader["ZoneId"]),
                        Name = sqlDataReader["Name"].ToString(),
                        Latitude = Convert.ToDouble(sqlDataReader["Latitude"]),
                        Longitude = Convert.ToDouble(sqlDataReader["Longitude"]),
                        BaseLatitude = Convert.ToDouble(sqlDataReader["BaseLatitude"]),
                        BaseLongitude = Convert.ToDouble(sqlDataReader["BaseLongitude"])
                    };
                    userAttendanceZones.Add(attendanceZoneModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return userAttendanceZones;
        }
    }

    public List<ApprovalViewModel> GetPendingApprovals(string empCode)
    {
        List<ApprovalViewModel> pendingApprovals = new List<ApprovalViewModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_WorkFlow_Pending_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var approvalViewModel1 = new ApprovalViewModel();
                    approvalViewModel1.WorkFlowTaskId = Convert.ToString(sqlDataReader["WorkFlowTaskId"]);
                    approvalViewModel1.DocNumber = Convert.ToString(sqlDataReader["DocNumber"]);
                    approvalViewModel1.TaskName = Convert.ToString(sqlDataReader["TaskName"]);
                    var dateTime = Convert.ToDateTime(sqlDataReader["TaskDate"]);
                    approvalViewModel1.TaskDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    dateTime = Convert.ToDateTime(sqlDataReader["TaskDueDate"]);
                    approvalViewModel1.TaskDueDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    approvalViewModel1.EmpCode = Convert.ToString(sqlDataReader["EmpCode"]);
                    approvalViewModel1.EmpName = Convert.ToString(sqlDataReader["EmpName"]);
                    approvalViewModel1.Designation = Convert.ToString(sqlDataReader["Designation"]);
                    approvalViewModel1.Department = Convert.ToString(sqlDataReader["Department"]);
                    approvalViewModel1.Remark = Convert.ToString(sqlDataReader["Remark"]);
                    dateTime = Convert.ToDateTime(sqlDataReader["ApplyDate"]);
                    approvalViewModel1.ApplyDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    dateTime = Convert.ToDateTime(sqlDataReader["StartDate"]);
                    approvalViewModel1.StartDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    dateTime = Convert.ToDateTime(sqlDataReader["EndDate"]);
                    approvalViewModel1.EndDate = dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
                    approvalViewModel1.TaskType = Convert.ToString(sqlDataReader["TaskType"]);
                    approvalViewModel1.TaskTypeLine = Convert.ToString(sqlDataReader["TaskTypeLine"]);
                    approvalViewModel1.DurationType = Convert.ToString(sqlDataReader["DurationType"]);
                    approvalViewModel1.TotalDays = Convert.ToDouble(sqlDataReader["TotalDays"]);
                    var approvalViewModel2 = approvalViewModel1;
                    pendingApprovals.Add(approvalViewModel2);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return pendingApprovals;
        }
    }

    public List<PaySlipModel> GetPayslips(string empId)
    {
        List<PaySlipModel> payslips = new List<PaySlipModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_PaySlip", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", empId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return payslips;
                while (sqlDataReader.Read())
                {
                    var paySlipModel = new PaySlipModel()
                    {
                        PayrollId = Convert.ToString(sqlDataReader["PayrollId"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        FromDate = Convert.ToString(sqlDataReader["FromDate"]),
                        ToDate = Convert.ToString(sqlDataReader["ToDate"]),
                        GrossAmount = Convert.ToDouble(sqlDataReader["GrossAmount"]),
                        DeductionAmount = Convert.ToDouble(sqlDataReader["DeductionAmount"]),
                        NetAmount = Convert.ToDouble(sqlDataReader["NetAmount"]),
                        InWord = Convert.ToString(sqlDataReader["InWord"]),
                        SalaryType = Convert.ToString(sqlDataReader["SalaryType"])
                    };
                    payslips.Add(paySlipModel);
                }
                return payslips;
            }
        }
    }

    public List<PaySlipLineModel> GetPayslipLines(string payrollId)
    {
        List<PaySlipLineModel> payslipLines = new List<PaySlipLineModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_InteAcc_PaySlip_Lines", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@PayrollId", payrollId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows)
                    return payslipLines;
                while (sqlDataReader.Read())
                {
                    var paySlipLineModel = new PaySlipLineModel()
                    {
                        HeadName = Convert.ToString(sqlDataReader["HeadName"]),
                        IsEarning = Convert.ToBoolean(sqlDataReader["IsEarning"]),
                        HeadType = Convert.ToString(sqlDataReader["HeadType"]),
                        Amount = Convert.ToDouble(sqlDataReader["Amount"])
                    };
                    payslipLines.Add(paySlipLineModel);
                }
                return payslipLines;
            }
        }
    }

    public bool ProfileUpdate(ProfileUpdateDto data)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetEdsConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_Employee_Profile_Update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", data.EmpCode);
                        sqlCommand.Parameters.AddWithValue("@BloodGroup", data.BloodGroup.Data);
                        sqlCommand.Parameters.AddWithValue("@IsBloodDonor", data.IsBloodDonor.Data);
                        sqlCommand.Parameters.AddWithValue("@Ipx", data.Ipx.Data);
                        sqlCommand.Parameters.AddWithValue("@MobileNo", data.MobileNo.Data);
                        sqlCommand.Parameters.AddWithValue("@MobileNoEmergency", data.MobileNoEmergency.Data);
                        sqlCommand.Parameters.AddWithValue("@Email", data.Email.Data);
                        var numArray = Convert.FromBase64String(data.Image.Data);
                        sqlCommand.Parameters.AddWithValue("@Photo", numArray);
                    
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
        }
        catch
        {
            return false;
        }
    }

    public ProfileUpdateViewModel GetProfile(string empCode)
    {
        var profile = new ProfileUpdateViewModel();
        using (var sqlConnection = new SqlConnection(GetEdsConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Employee_Profile_Get", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (!sqlDataReader.HasRows || !sqlDataReader.Read())
                    return profile;
                profile.BloodGroup = Convert.ToString(sqlDataReader["BloodGroup"]);
                profile.Ipx = Convert.ToString(sqlDataReader["Ipx"]);
                profile.Email = Convert.ToString(sqlDataReader["Email"]);
                profile.MobileNo = Convert.ToString(sqlDataReader["MobileNo"]);
                profile.EmergencyContact = Convert.ToString(sqlDataReader["EmergencyContact"]);
                profile.IsBloodDonor = new bool?(Convert.ToBoolean(sqlDataReader["IsBloodDonor"]));


                

                return profile;
            }
        }
    }

    public bool SaveAttendanceZone(List<AttendanceLocationModel> zones)
    {
        var attendanceLocationId = zones.First<AttendanceLocationModel>().AttendanceLocationId;
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlTransaction = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (var sqlCommand = new SqlCommand("DELETE FROM AttendanceZone WHERE AttendaceLocationId=@AttendanceLocationId", sqlConnection))
                    {
                        sqlCommand.Transaction = sqlTransaction;
                        sqlCommand.Parameters.AddWithValue("@AttendanceLocationId", attendanceLocationId);
                        sqlCommand.ExecuteNonQuery();
                    }
                    using (var sqlCommand = new SqlCommand("usp_Attendance_Zone_Save", sqlConnection))
                    {
                        sqlCommand.Transaction = sqlTransaction;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        foreach (var zone in zones)
                        {
                            sqlCommand.Parameters.Clear();
                            sqlCommand.Parameters.AddWithValue("@Name", zone.Name);
                            sqlCommand.Parameters.AddWithValue("@Latitude", zone.Latitude);
                            sqlCommand.Parameters.AddWithValue("@Longitude", zone.Longitude);
                            sqlCommand.Parameters.AddWithValue("@AttendanceLocationId", attendanceLocationId);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    sqlTransaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    sqlTransaction.Rollback();
                    return false;
                }
            }
        }
    }

    public List<AttendanceLocationModel> GetAttendanceZones(
        string attendanceLocationId)
    {
        List<AttendanceLocationModel> attendanceZones = new List<AttendanceLocationModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_Attendance_Zone_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@AttendanceLocationId", attendanceLocationId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var attendanceLocationModel = new AttendanceLocationModel()
                    {
                        AttendanceLocationId = Convert.ToString(sqlDataReader["AttendanceLocationId"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        Latitude = Convert.ToDouble(sqlDataReader["Latitude"]),
                        Longitude = Convert.ToDouble(sqlDataReader["Longitude"])
                    };
                    attendanceZones.Add(attendanceLocationModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return attendanceZones;
        }
    }

    public List<AttendanceLocationModel> GetAttendanceLocations()
    {
        List<AttendanceLocationModel> attendanceLocations = new List<AttendanceLocationModel>();
        using (var sqlConnection = new SqlConnection(GetConnectionString()))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_app_Attendance_Location_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var attendanceLocationModel = new AttendanceLocationModel()
                    {
                        AttendanceLocationId = Convert.ToString(sqlDataReader["AttendanceLocationId"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        Latitude = Convert.ToDouble(sqlDataReader["Latitude"]),
                        Longitude = Convert.ToDouble(sqlDataReader["Longitude"])
                    };
                    attendanceLocations.Add(attendanceLocationModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return attendanceLocations;
        }
    }

    public bool UpdateAttendanceLocation(string empCode, string attendanceLocationId)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_InteAcc_User_Attendance_Location_Update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", empCode);
                    sqlCommand.Parameters.AddWithValue("@AttendanceLocationId", attendanceLocationId);
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

    public string? Login(string? userId, string? password)
    {
        try
        {
            var empty1 = string.Empty;
            var empty2 = string.Empty;
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_InteAcc_User_Login", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@UserId", userId);
                    var sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows && sqlDataReader.Read())
                    {
                        empty1 = sqlDataReader["EmpId"].ToString();
                        empty2 = sqlDataReader["PasswordHash"].ToString();
                    }
                    return BCrypt.Net.BCrypt.Verify(password, empty2) ? empty1 : null;
                }
            }
        }
        catch
        {
            return null;
        }
    }

    public bool ChangePassword(PasswordDto data)
    {
        try
        {
            using (var sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using (var sqlCommand = new SqlCommand("usp_InteAcc_User_Change_Password", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpCode", data.EmpCode);
                    sqlCommand.Parameters.AddWithValue("@Password", data.Password);
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