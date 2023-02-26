using Microsoft.AspNetCore.Mvc;
using SomeExternalLibrary;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SimpleExampleController : Controller
{
    private readonly IExample _exampleLibrary;
    public SimpleExampleController(IExample exampleLibrary)
    {
        _exampleLibrary = exampleLibrary;
    }
    
    [HttpGet("do-stuff/{id:int}")]
    public IActionResult DoStuff(int id)
    {
        Console.WriteLine("DoStuff Endpoint called");
        _exampleLibrary.DoStuff(id);
        Console.WriteLine("DoStuff Done");
        return Ok();
    }
    
    /*
     * Cancellation token is used to stop the flow gracefully
     */
    
    [HttpGet("do-stuff-async/{id:int}")]
    public async Task<IActionResult> DoStuffAsync(int id, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("DoStuffAsync Endpoint called");
        await _exampleLibrary.DoStuffAsync(id, cancellationToken);
        Console.WriteLine("DoStuffAsync Done");
        return Ok();
    }
    
    [HttpGet("do-stuff-with-return/{id:int}")]
    public ActionResult<int> DoStuffAndReturnSomething(int id)
    {
        Console.WriteLine("DoStuffAndReturnSomething Endpoint called");
        var result = _exampleLibrary.DoStuffAndReturnSomething(id);
        Console.WriteLine("DoStuffAndReturnSomething Done");
        return Ok(result);
    }
    
    [HttpGet("do-stuff-with-return-async/{id:int}")]
    public async Task<ActionResult<int>> DoStuffAndReturnSomethingAsync(int id, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("DoStuffAndReturnSomethingAsync Endpoint called");
        var result = await _exampleLibrary.DoStuffAndReturnSomethingAsync(id, cancellationToken);
        Console.WriteLine("DoStuffAndReturnSomethingAsync Done");
        return Ok(result);
    }

    [HttpGet("block-example/{id:int}")]
    public ActionResult<int> BlockExample(int id)
    {
        Console.WriteLine("Blocking example called");
        var result = _exampleLibrary.BlockExample(id);
        return Ok(result);
    }
    
    [HttpGet("block-example-async/{id:int}")]
    public async Task<ActionResult<int>> BlockExampleAsync(int id, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Blocking Async example called");
        var result = await _exampleLibrary.BlockExampleAsync(id,cancellationToken);
        return Ok(result);
    }
    
    [HttpGet("multiple/{id:int}")]
    public async Task<ActionResult<int>> MultipleTasksAsync(int id, CancellationToken cancellationToken = default)
    {
        Console.WriteLine("MultipleTasksAsync example called");
        var result = await _exampleLibrary.MultipleTasksAsync(id,cancellationToken);
        return Ok(result);
    }
}