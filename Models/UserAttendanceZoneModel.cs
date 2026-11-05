

namespace PeoplePro.Models;

public class UserAttendanceZoneModel
{
    public long ZoneId { get; set; }

    public string? Name { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public double BaseLatitude { get; set; }

    public double BaseLongitude { get; set; }
}