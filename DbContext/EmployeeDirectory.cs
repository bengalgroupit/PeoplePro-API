using System.Data;
using System.Data.SqlClient;
using PeoplePro.Dtos;
using PeoplePro.Models;
using PeoplePro.ViewModels;

namespace PeoplePro.DbContext;

public class EmployeeDirectory(IConfiguration configuration) : Connection(configuration)
{
    public List<EmployeeDirectoryViewModel> Search(SearchDto input)
    {
        var directoryViewModelList = new List<EmployeeDirectoryViewModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());  //Previous Data Source=172.16.18.59;Initial Catalog=EDS
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Employee_Search", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@SearchText", input.SearchText);
            sqlCommand.Parameters.AddWithValue("@SearchType", input.SearchType);
            sqlCommand.Parameters.AddWithValue("@Offset", input.Offset);
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                try
                {
                    directoryViewModelList.Add(new EmployeeDirectoryViewModel()
                    {
                        EmpCode = Convert.ToString(sqlDataReader["EmpCode"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        BloodGroup = Convert.ToString(sqlDataReader["BloodGroup"]),
                        Designation = Convert.ToString(sqlDataReader["Designation"]),
                        Department = Convert.ToString(sqlDataReader["Department"]),
                        Section = Convert.ToString(sqlDataReader["Section"]),
                        Company = Convert.ToString(sqlDataReader["Company"]),
                        Location = Convert.ToString(sqlDataReader["Location"]),
                        MobileNo = Convert.ToString(sqlDataReader["MobileNo"]),
                        Email = Convert.ToString(sqlDataReader["Email"]),
                        Ipx = Convert.ToString(sqlDataReader["Ipx"]),
                        MotherName = Convert.ToString(sqlDataReader["MotherName"]),
                        FatherName = Convert.ToString(sqlDataReader["FatherName"]),
                        PresentAddress = Convert.ToString(sqlDataReader["PresentAddress"]),
                        PermanentAddress = Convert.ToString(sqlDataReader["PermanentAddress"]),
                        Photo = (byte[]) sqlDataReader["Photo"],
                        EmergencyContact = Convert.ToString(sqlDataReader["EmergencyContact"]),
                        MaritalStatus = Convert.ToString(sqlDataReader["MaritalStatus"]),
                        IsBloodDonor = Convert.ToBoolean(sqlDataReader["IsBloodDonor"]),
                        IsActive = Convert.ToBoolean(sqlDataReader["IsActive"]),
                        ExpLevel = Convert.ToInt32(sqlDataReader["ExpLevel"]),
                        JoiningDate = new DateTime?(Convert.ToDateTime(sqlDataReader["JoiningDate"])),
                        Gender = Convert.ToString(sqlDataReader["Gender"]),
                        InActiveFrom = Convert.ToDateTime(sqlDataReader["InActiveFrom"]),
                        Religion = Convert.ToString(sqlDataReader["Religion"])
                    });
                }
                catch
                {
                    //
                }
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return directoryViewModelList;
    }

    public SearchOptionViewModel GetOptions() => new()
    {
        Companies = GetCompanies(),
        Departments = GetDepartments(),
        Designations = GetDesignations(),
        Locations = GetLocations(),
        BloodGroups = GetBloodGroups(),
        Genders = GetGenders(),
        Religions = GetReligions()
    };

    private List<SearchOptionModel> GetCompanies()
    {
        var companies = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Company_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                companies.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return companies;
    }

    private List<SearchOptionModel> GetDepartments()
    {
        var departments = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Department_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                departments.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return departments;
    }

    private List<SearchOptionModel> GetDesignations()
    {
        var designations = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Designation_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                designations.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return designations;
    }

    private List<SearchOptionModel> GetLocations()
    {
        var locations = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Location_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                locations.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return locations;
    }

    private List<SearchOptionModel> GetBloodGroups()
    {
        var bloodGroups = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_BloodGroup_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                bloodGroups.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return bloodGroups;
    }

    private List<SearchOptionModel> GetGenders()
    {
        var genders = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Gender_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                genders.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return genders;
    }

    private List<SearchOptionModel> GetReligions()
    {
        var religions = new List<SearchOptionModel>();
        using var sqlConnection = new SqlConnection(GetEdsConnectionString());
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand("usp_Religion_List", sqlConnection))
        {
            sqlCommand.CommandType = CommandType.StoredProcedure;
            var sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                var searchOptionModel = new SearchOptionModel()
                {
                    Name = Convert.ToString(sqlDataReader["Name"])
                };
                religions.Add(searchOptionModel);
            }
            sqlDataReader.Close();
        }
        sqlConnection.Close();
        return religions;
    }
}