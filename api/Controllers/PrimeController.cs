﻿using api.Requests;
using api.Responses;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrimeController : Controller
{
    // POST api/prime
    [HttpPost]
    public IActionResult Post([FromBody] PrimeRequest request)
    {
        //Validation
        if (request.Number < 2)
        {
            return BadRequest("Number must be greater than 1");
        }

        //Calculation
        var watch = System.Diagnostics.Stopwatch.StartNew();
        
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