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
    public string Get(string a, string b)
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

    [HttpGet("/save/{a}/{b}")]
    public string Save(string a, int b)
    {
        TestData testData = new TestData();
        testData.CoolString = a;
        testData.CoolInt = b;

        JSONManager.Serialize(testData, "/home/pi/DotnetProjectData/cooldata.json");

        return "Saved: " + testData;
    }

    [HttpGet("/load")]
    public string Get()
    {
        TestData testData = new TestData();

        testData = JSONManager.Deserialize<TestData>("/home/pi/DotnetProjectData/cooldata.json");

        return testData.CoolString + " " + testData.CoolInt.ToString();
    }
}

[Serializable]
public class TestData
{
    public string CoolString;
    public int CoolInt;
}
