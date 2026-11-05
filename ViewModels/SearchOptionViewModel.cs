
using PeoplePro.Models;

namespace PeoplePro.ViewModels;

public class SearchOptionViewModel
{
    public List<SearchOptionModel>? Companies { get; set; }

    public List<SearchOptionModel>? Departments { get; set; }

    public List<SearchOptionModel>? Designations { get; set; }

    public List<SearchOptionModel>? Locations { get; set; }

    public List<SearchOptionModel>? BloodGroups { get; set; }

    public List<SearchOptionModel>? Genders { get; set; }

    public List<SearchOptionModel>? Religions { get; set; }
}