
using PeoplePro.Models;

namespace PeoplePro.ViewModels;

public class PollVIewModel
{
    public PollModel Poll { get; set; } = new();

    public List<PollLineModel> PollLines { get; set; } = new();
}