
namespace PeoplePro.ViewModels;

public class AttendanceBaseLatLng(double latitude, double longitude)
{
    public double Latitude { get; set; } = latitude;
    public double Longitude { get; set; } = longitude;
}