using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

public class MathController
{
    [HttpGet("/compare/{a}/{b}")]
    public string Get(float a, float b)
    {
        if (a == b)
        {
            return "Equal!";
        }
        else
        {
            return "Not Equal!";
        }
    }
}
