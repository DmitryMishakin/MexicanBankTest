using MexicanBankTest.BLL.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MexicanBankTest.Presentation.Controllers;
[Route("api/[controller]")]
public class ValueController (IValueService valueService, ILogger<ValueController> logger): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Dictionary<int,string> values)
    {
        logger.LogInformation("Start executing Create method with values: {values}",
            string.Join(",", values.Select(el=>$"{el.Key}:{el.Value}")));
        
        await valueService.CreateValueAsync(values);
        
        logger.LogInformation("End executing Create method");
        
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? code, [FromQuery] string? value)
    {
        logger.LogInformation("Start executing Get method");
        
        var result = await valueService.GetValueAsync(code, value);
        
        logger.LogInformation("End executing Get method");
        
        return Ok(result);
    }
}