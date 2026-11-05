namespace PeoplePro.Dtos;

public class ProfileUpdateDto
{
    public string? EmpCode { get; set; }

    public UpdateProfileDataLine? BloodGroup { get; set; }

    public UpdateProfileDataLine? Image { get; set; }

    public UpdateProfileDataLine? Ipx { get; set; }

    public UpdateProfileDataLine? MobileNo { get; set; }

    public UpdateProfileDataLine? MobileNoEmergency { get; set; }

    public UpdateProfileDataLine? Email { get; set; }

    public UpdateProfileDataLine? IsBloodDonor { get; set; }
}