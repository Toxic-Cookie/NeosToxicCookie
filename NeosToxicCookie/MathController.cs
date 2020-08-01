using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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

        JSONManager.Serialize(testData, Directory.GetCurrentDirectory() + "/DotnetProjectData/cooldata.json");

        return "Saved: " + testData;
    }

    [HttpGet("/load")]
    public string Load()
    {
        TestData testData = new TestData();

        testData = JSONManager.Deserialize<TestData>(Directory.GetCurrentDirectory() + "/DotnetProjectData/cooldata.json");

        return testData.CoolString + " " + testData.CoolInt.ToString();
    }
}

[Serializable]
public class TestData
{
    public string CoolString;
    public int CoolInt;
}
