
namespace PeoplePro.Dtos;

public class SearchDto
{
    public string? SearchText { get; set; }

    public string? SearchType { get; set; }

    public int Offset { get; set; }
}