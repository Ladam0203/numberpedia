using Microsoft.AspNetCore.Mvc;
using Messages.Requests;
using Messages.Responses;

namespace PrimeService.Controllers;

[Route("[controller]")]
[ApiController]
public class PrimeController : Controller
{
    // POST PrimeService0/prime
    [HttpPost]
    public IActionResult Post([FromBody] PrimeRequest request)
    {
        //Validation
        if (!(request.Number > 0))
        {
            return BadRequest("Number must be greater than 0");
        }

        //Calculation
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
        if (request.Number == 1)
        {
            watch.Stop();
            return Ok(new PrimeResponse
            {
                Number = request.Number,
                IsPrime = false,
                ElapsedMilliseconds = watch.ElapsedMilliseconds
            });
        }
        
        var isPrime = true;
        for (ulong i = 2; i < request.Number; i++)
        {
            if (request.Number % i == 0)
            {
                isPrime = false;
                break;
            }
        }
        
        watch.Stop();

        //Response
        return Ok(new PrimeResponse
        {
            Number = request.Number,
            IsPrime = isPrime,
            ElapsedMilliseconds = watch.ElapsedMilliseconds
        });
    }
}