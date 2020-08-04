using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;

public class DataController
{
    [HttpGet("/AddUserData/name/guid")]
    public string AddUserData(string name, Guid guid)
    {
        DotnetProjectData.UserDataList = JSONManager.Deserialize<List<UserData>>(Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        UserData userData = new UserData { UserName = name, UserGUID = guid };

        if (DotnetProjectData.UserDataList.Find(data => data.UserName == userData.UserName) == null)
        {
            DotnetProjectData.UserDataList.Add(userData);

            JSONManager.Serialize(DotnetProjectData.UserDataList, Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

            return "Success: User data created.";
        }
        else
        {
            return "Error: User data already exists.";
        }
    }

    [HttpGet("/GetUserData/guid")]
    public string GetUser(Guid guid)
    {
        DotnetProjectData.UserDataList = JSONManager.Deserialize<List<UserData>>(Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        if (DotnetProjectData.UserDataList.Find(data => data.UserGUID == guid) != null)
        {
            return DotnetProjectData.UserDataList.Find(data => data.UserGUID == guid).UserName;
        }
        else
        {
            return "Error: User data does not exist.";
        }
    }

    [HttpGet("/Initialize")]
    public string Initialize()
    {
        List<UserData> InitialList = new List<UserData>();

        JSONManager.Serialize(InitialList, Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        return "Initialized!";
    }
}
