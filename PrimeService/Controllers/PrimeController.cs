using Microsoft.AspNetCore.Mvc;
using Messages.Requests;
using Messages.Responses;

namespace PrimeService.Controllers;

[Route("[controller]")]
[ApiController]
public class PrimeController : Controller
{
    // POST PrimeService/prime
    [HttpPost]
    public IActionResult Post([FromBody] PrimeRequest request)
    {
        //Validation
        if (!(request.Number > 0))
        {
            return BadRequest("Number must be greater than 0");
        }

        //Benchmark
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        //Logic
        var isPrime = IsPrime(request.Number);
        
        watch.Stop();

        //Response
        return Ok(new PrimeResponse
        {
            Number = request.Number,
            IsPrime = isPrime,
            ElapsedMilliseconds = watch.ElapsedMilliseconds
        });
    }
    
    private bool IsPrime(ulong number)
    {
        if (number < 1)
        {
            throw new ArgumentException("A prime number must be positive.");
        }
        
        if (number == 1)
        {
            return false;
        }
        
        for (ulong i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        
        return true;
    }
}