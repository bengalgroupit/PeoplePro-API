
using System.Data;
using System.Data.SqlClient;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class BGICMS(IConfiguration configuration)
{
    private readonly string? _connectionString = configuration.GetConnectionString("BGICMS");

    public bool TokenRequest(string empId)
    {
        using var conn = new SqlConnection(_connectionString);
        conn.Open();
        using var cmd = new SqlCommand("usp_App_Token_Print_Request", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EmployeeId", empId);
        try
        {
            return cmd.ExecuteNonQuery() == 1;
        }
        catch
        {
            return false;
        }
    }

    public MealClosingModel MealClosing(MealClosingDto data)
    {
        var mealClosingModel = new MealClosingModel()
        {
            IsSuccess = true,
            Message = "Unable to process your meal closing request."
        };
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlTransaction = sqlConnection.BeginTransaction())
            {
                try
                {
                   
                        using (var sqlCommand = new SqlCommand("usp_App_Meal_Close", sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddWithValue("@EmployeeId", data.Username);
                            sqlCommand.Parameters.AddWithValue("@MealDate", data.IssueDate);
                            sqlCommand.Parameters.AddWithValue("@ActionType", 1);
                            var sqlParameter = sqlCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                            sqlParameter.Direction = ParameterDirection.Output;
                            if (sqlCommand.ExecuteNonQuery() != 1)
                            {
                                mealClosingModel.IsSuccess = false;
                                mealClosingModel.Message = (string)sqlParameter.Value;
                                
                            }
                        }
                    

                    if (mealClosingModel.IsSuccess)
                    {
                        sqlTransaction.Commit();
                        mealClosingModel.Message = "Meal closing request processed successfully.";
                    }
                    else
                        sqlTransaction.Rollback();
                    return mealClosingModel;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    sqlTransaction.Rollback();
                    return mealClosingModel;
                }
            }
        }
    }

    public List<MealClosingListModel> MealClosingList(string userId)
    {
        var closingListModelList = new List<MealClosingListModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Meal_Closed_List", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Username", userId);
                var dr = sqlCommand.ExecuteReader();
                while (dr.Read())
                {
                    var closingListModel = new MealClosingListModel()
                    {
                        Id =Convert.ToInt64(dr["Id"]),
                        EmpId = Convert.ToString(dr["EmployeeId"]),
                        IssueDate = Convert.ToDateTime(dr["MealDate"]),
                        IsDriver = false,
                        Cancellable = Convert.ToBoolean(dr["IsCancellable"])
                    };
                    closingListModelList.Add(closingListModel);
                }
                return closingListModelList;
            }
        }
    }

    public List<AdminFactoryGuestTokenModel> AdminFactoryGuestToken()
    {
        var factoryGuestTokenModelList = new List<AdminFactoryGuestTokenModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Factory_Guest_Token", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var factoryGuestTokenModel = new AdminFactoryGuestTokenModel()
                    {
                        TokenId = Convert.ToInt64(sqlDataReader["TokenId"]),
                        TokenNo = Convert.ToString(sqlDataReader["TokenNo"]),
                        RequestedAt = Convert.ToString(sqlDataReader["RequestedAt"]),
                        FactoryGuestId = Convert.ToString(sqlDataReader["FactoryGuestId"])
                    };
                    factoryGuestTokenModelList.Add(factoryGuestTokenModel);
                }
                return factoryGuestTokenModelList;
            }
        }
    }



    public bool MealClosingCancel(MealClosingCancelDto data)
    {
        using (var conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            try
            {

                //var issueDate = new DateTime(1900, 1, 1);
                //const string sql = "SELECT MealDate FROM MealClosed WHERE Id = @Id AND EmployeeId = @EmployeeId";
                //using (var cmd = new SqlCommand(sql,conn))
                //{
                //    cmd.Parameters.AddWithValue("@Id", data.Id);
                //    cmd.Parameters.AddWithValue("@EmployeeId", data.Username);
                //    var dr = cmd.ExecuteReader();
                //    if (dr.HasRows)
                //    {
                //        while (dr.Read())
                //        {
                //            issueDate = Convert.ToDateTime(dr["MealDate"]);
                //            break;
                //        }
                //    }
                //    dr.Close();
                //}


                //if (issueDate == new DateTime(1900, 1, 1))
                //    return false;
                


                using (var sqlCommand = new SqlCommand("usp_App_Meal_Close", conn))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmployeeId", data.Username);
                    sqlCommand.Parameters.AddWithValue("@ActionType",2);
                    sqlCommand.Parameters.AddWithValue("@MealDate", data.MealDate);
                    var sqlParameter = sqlCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    sqlParameter.Direction = ParameterDirection.Output;
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return false;
            }
        }
    }

    public bool MasterCardMemberAddRemove(MasterCardMemberAddRemoveDto data)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            try
            {
                using (var sqlCommand = new SqlCommand("usp_App_Admin_Card_Member_Add_Remove", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@CardId", data.CardId);
                    sqlCommand.Parameters.AddWithValue("@EmpId", data.EmpId);
                    return sqlCommand.ExecuteNonQuery() == 1;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public bool MemberActiveInactive(MemberActiveInactiveDto data)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            try
            {
                using (var sqlCommand = new SqlCommand("usp_App_Admin_Employee_ActiveInactive", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@EmpId", data.EmpId);
                    sqlCommand.Parameters.AddWithValue("@UserId", data.UserId);
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
    }

    public MealMonthlySummaryModel MealMonthlySummary(string userId)
    {
        var monthlySummaryModel = new MealMonthlySummaryModel();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Meal_Monthly_Summary", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@EmpId", userId);
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    monthlySummaryModel.Title = Convert.ToString(sqlDataReader["Title"]);
                    monthlySummaryModel.Total = Convert.ToInt32(sqlDataReader["Total"]);
                    monthlySummaryModel.Employee = Convert.ToInt32(sqlDataReader["Employee"]);
                    monthlySummaryModel.Guest = Convert.ToInt32(sqlDataReader["Guest"]);
                    monthlySummaryModel.Driver = Convert.ToInt32(sqlDataReader["Driver"]);
                }
                return monthlySummaryModel;
            }
        }
    }

    public List<MealCardModel> GetMealCard(
        string userId,
        string fromDate,
        string toDate)
    {
        var mealCard = new List<MealCardModel>();
        using (var sql = new SqlConnection(_connectionString))
        {
            sql.Open();
            using (var cmd = new SqlCommand("usp_App_Meal_Card", sql))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", userId);
                cmd.Parameters.AddWithValue("@StartDate", fromDate);
                cmd.Parameters.AddWithValue("@EndDate", toDate);
                var sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
 

                    var mealCardModel = new MealCardModel()
                    {
                        MealDate = Convert.ToDateTime(sqlDataReader["MealDate"]),
                        MealCount = Convert.ToInt32(sqlDataReader["MealCount"]),
                        GuestCount = Convert.ToInt32(sqlDataReader["GuestCount"]),
                        IsMealClosed = Convert.ToBoolean(sqlDataReader["IsMealClosed"]),
                        StatusText = Convert.ToString(sqlDataReader["StatusText"])
                    };
                    mealCard.Add(mealCardModel);
                }
                return mealCard;
            }
        }
    }

    public List<MemberModel> GetMembers()
    {
        var members = new List<MemberModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Canteen_Members", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var memberModel = new MemberModel()
                    {
                        EmpCode = Convert.ToString(sqlDataReader["EmpCode"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        Designation = Convert.ToString(sqlDataReader["Designation"]),
                        Department = Convert.ToString(sqlDataReader["Department"]),
                        Company = Convert.ToString(sqlDataReader["Company"]),
                        Unit = Convert.ToString(sqlDataReader["Unit"]),
                        IsRiceService = Convert.ToBoolean(sqlDataReader["IsRiceService"]),
                        IsFreeService = Convert.ToBoolean(sqlDataReader["IsFreeService"]),
                        IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]),
                        CardId = Convert.ToString(sqlDataReader["CardId"]),
                        IsGuest = Convert.ToBoolean(sqlDataReader["IsGuest"]),
                        IsMasterCard = Convert.ToBoolean(sqlDataReader["IsMasterCard"])
                    };
                    members.Add(memberModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return members;
        }
    }

    public List<MemberModel> GetMembersQuery(int type, string input)
    {
        var membersQuery = new List<MemberModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Canteen_Members_Type", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Type", type);
                sqlCommand.Parameters.AddWithValue("@Input", input);
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var memberModel = new MemberModel()
                    {
                        EmpCode = Convert.ToString(sqlDataReader["EmpCode"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        Designation = Convert.ToString(sqlDataReader["Designation"]),
                        Department = Convert.ToString(sqlDataReader["Department"]),
                        Company = Convert.ToString(sqlDataReader["Company"]),
                        Unit = Convert.ToString(sqlDataReader["Unit"]),
                        IsRiceService = Convert.ToBoolean(sqlDataReader["IsRiceService"]),
                        IsFreeService = Convert.ToBoolean(sqlDataReader["IsFreeService"]),
                        IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]),
                        CardId = Convert.ToString(sqlDataReader["CardId"]),
                        IsGuest = Convert.ToBoolean(sqlDataReader["IsGuest"]),
                        IsMasterCard = Convert.ToBoolean(sqlDataReader["IsMasterCard"])
                    };
                    membersQuery.Add(memberModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return membersQuery;
        }
    }

    public List<CanteenCardModel> GetCards()
    {
        var cards = new List<CanteenCardModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Cards", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var canteenCardModel = new CanteenCardModel()
                    {
                        CardId = Convert.ToString(sqlDataReader["CardId"]),
                        Description = Convert.ToString(sqlDataReader["Description"]),
                        Total = Convert.ToInt32(sqlDataReader["Total"])
                    };
                    cards.Add(canteenCardModel);
                }
                sqlDataReader.Close();
            }
            sqlConnection.Close();
            return cards;
        }
    }

    public List<MealTodaySummaryModel> GetAdminMealCountSummary()
    {
        var mealCountSummary = new List<MealTodaySummaryModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Meal_Count_Summary", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    var todaySummaryModel = new MealTodaySummaryModel()
                    {
                        Title = Convert.ToString(sqlDataReader["Title"]),
                        MealCount = Convert.ToInt32(sqlDataReader["MealCount"])
                    };
                    mealCountSummary.Add(todaySummaryModel);
                }
                return mealCountSummary;
            }
        }
    }

    public AdminMemberCountModel GetAdminMemberCountSummary()
    {
        var memberCountSummary = new AdminMemberCountModel();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Member_Count", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    memberCountSummary.Total = Convert.ToInt32(sqlDataReader["Total"]);
                    memberCountSummary.PaidCount = Convert.ToInt32(sqlDataReader["PaidCount"]);
                    memberCountSummary.RiceCount = Convert.ToInt32(sqlDataReader["RiceCount"]);
                    memberCountSummary.FreeCount = Convert.ToInt32(sqlDataReader["FreeCount"]);
                }
                return memberCountSummary;
            }
        }
    }

    public List<AdminMealClosingCountModel> GetAdminMealClosingCountSummary()
    {
        var closingCountSummary = new List<AdminMealClosingCountModel>();
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            using (var sqlCommand = new SqlCommand("usp_App_Admin_Meal_Closing_Count", sqlConnection))
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                var sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                    closingCountSummary.Add(new AdminMealClosingCountModel()
                    {
                        Total = Convert.ToInt32(sqlDataReader["Total"]),
                        IsToday = Convert.ToBoolean(sqlDataReader["IsToday"]),
                        IssueDate = Convert.ToDateTime(sqlDataReader["IssueDate"])
                    });
                return closingCountSummary;
            }
        }
    }

    public MealClosingModel UpdateFactoryGuestToken(AdminFactoryGuestTokenModel data)
    {
        var mealClosingModel = new MealClosingModel()
        {
            IsSuccess = false,
            Message = "Unable to process your request."
        };
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();
            try
            {
                using (var sqlCommand = new SqlCommand("usp_App_Admin_Factory_Guest_Token_Update", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@TokenId", data.TokenId);
                    sqlCommand.Parameters.AddWithValue("@FactoryGuestId", data.FactoryGuestId);
                    var sqlParameter = sqlCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 100);
                    sqlParameter.Direction = ParameterDirection.Output;
                    var num = sqlCommand.ExecuteNonQuery();
                    mealClosingModel.Message = (string)sqlParameter.Value;
                    mealClosingModel.IsSuccess = num == 1;
                    return mealClosingModel;
                }
            }
            catch
            {
                return mealClosingModel;
            }
        }
    }

    public List<CanteenDailyMealReportViewModel> AdminMealDailyReport(DateTime reportDate)
    {
        var items = new List<CanteenDailyMealReportViewModel>();
        using var conn = new SqlConnection(_connectionString);
        conn.Open();

        using var cmd = new SqlCommand("usp_App_Admin_Meal_Daily_Report", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ReportDate", reportDate);
        using var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var item = new CanteenDailyMealReportViewModel();
            item.IssueDate = dr["IssueDate"] is DBNull ? DateTime.MinValue : Convert.ToDateTime(dr["IssueDate"]);
            item.EmpId = Convert.ToString(dr["EmployeeId"]) ?? string.Empty;
            item.Name = Convert.ToString(dr["Name"]) ?? string.Empty;
            item.Designation = Convert.ToString(dr["Designation"]) ?? string.Empty;
            item.Department = Convert.ToString(dr["Department"]) ?? string.Empty;
            item.Unit = Convert.ToString(dr["Unit"]) ?? string.Empty;
            item.EmpMeal = Convert.ToInt32(dr["EmpMeal"]);
            item.GuestMeal = Convert.ToInt32(dr["GuestMeal"]);
            item.IsEmpTaken = Convert.ToBoolean(dr["IsEmpTaken"]);
            item.DriverId = Convert.ToString(dr["DriverId"]) ?? string.Empty;
            item.DriverMeal = Convert.ToInt32(dr["DriverMeal"]);
            item.IsDriverTaken = Convert.ToBoolean(dr["IsDriverTaken"]);
            item.TotalMeal = Convert.ToInt32(dr["TotalMeal"]);
            item.IsMealClosed = Convert.ToBoolean(dr["IsMealClosed"]);
            item.StatusText = Convert.ToString(dr["StatusText"]) ?? string.Empty;
            item.IsFreeService = Convert.ToBoolean(dr["IsFreeService"]);
            item.IsRiceService = Convert.ToBoolean(dr["IsRiceService"]);
            items.Add(item);
        }
        return items;
    }
}