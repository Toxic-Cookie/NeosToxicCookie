using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.IO;

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

    [HttpGet("/getdirectory")]
    public string GetDirectory()
    {
        return Directory.GetCurrentDirectory();
    }

    [HttpGet("/getdrives")]
    public string[] GetDrives()
    {
        return Directory.GetLogicalDrives();
    }

    [HttpGet("/getsubs/{path}")]
    public string[] GetDriveL(string path)
    {
        return Directory.GetDirectories(path);
    }
}
