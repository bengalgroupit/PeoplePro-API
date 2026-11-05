 
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PeoplePro.DbContext;
using PeoplePro.Dtos;
using PeoplePro.Utils;
using PeoplePro.ViewModels;

namespace PeoplePro.Controllers;

[Route("api/v1/directory")]
[ApiController]
public class DirectoryController(IConfiguration configuration, IMemoryCache memoryCache) : ControllerBase
{
    private readonly EmployeeDirectory _eDirectory = new(configuration);

    [HttpPost("search")]
    public IActionResult Search([FromBody] SearchDto input)
    {
        var interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 3);
        interpolatedStringHandler.AppendLiteral("ck-");
        interpolatedStringHandler.AppendFormatted(input.SearchType);
        interpolatedStringHandler.AppendLiteral("-");
        interpolatedStringHandler.AppendFormatted(input.SearchText);
        interpolatedStringHandler.AppendLiteral("-");
        interpolatedStringHandler.AppendFormatted<int>(input.Offset);
        var stringAndClear = interpolatedStringHandler.ToStringAndClear();
        if (!memoryCache.TryGetValue<List<EmployeeDirectoryViewModel>>(stringAndClear, out var directoryViewModelList))
        {
            directoryViewModelList = _eDirectory.Search(input);
            var options = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7.0));
            memoryCache.Set<List<EmployeeDirectoryViewModel>>(stringAndClear, directoryViewModelList, options);
        }
        return Ok(directoryViewModelList);
    }

    [HttpGet("options")]
    [ApiKey]
    public IActionResult GetOptions()
    {
        if (!memoryCache.TryGetValue<SearchOptionViewModel>("ck-options", out var options1))
        {
            options1 = _eDirectory.GetOptions();
            var options2 = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(7.0));
            memoryCache.Set<SearchOptionViewModel>("ck-options", options1, options2);
        }
        return Ok(options1);
    }
}