
namespace PeoplePro.Dtos;

public class AttendanceDto
{
    public string? EmpCode { get; set; }

    public string? LatLng { get; set; }

    public int? ZoneId { get; set; }

    public DateTime? ClientTime { get; set; }
}