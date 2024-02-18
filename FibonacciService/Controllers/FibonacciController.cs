using Microsoft.AspNetCore.Mvc;
using Messages.Requests;
using Messages.Responses;

namespace FibonacciService.Controllers;

[Route("[controller]")]
[ApiController]
public class FibonacciController : Controller
{
    // POST FibonacciService/fibonacci
    [HttpPost]
    public IActionResult Post([FromBody] FibonacciRequest request)
    {
        //Validation
        if (!(request.Number > 0))
        {
            return BadRequest("Number must be greater than 0");
        }

        //Benchmark
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        //Logic
        var isFibonacci = IsFibonacci(request.Number);
        
        watch.Stop();

        //Response
        return Ok(new FibonacciResponse
        {
            Number = request.Number,
            IsFibonacci = isFibonacci,
            ElapsedMilliseconds = watch.ElapsedMilliseconds
        });
    }
    
    private bool isPerfectSquare(ulong x)
    {
        ulong s = (ulong) Math.Sqrt(x);
        return (s * s == x);
    }
    
    private bool IsFibonacci(ulong number)
    {
        return isPerfectSquare(5 * number * number + 4) || isPerfectSquare(5 * number * number - 4);
    }
}