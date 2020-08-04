using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;

[Serializable]
public static class DotnetProjectData
{
    public static List<UserData> UserDataList;

    [HttpGet("/AddUserData/name/guid")]
    public static string AddUserData(string name, Guid guid)
    {
        UserDataList = JSONManager.Deserialize<List<UserData>>(Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        UserData userData = new UserData { UserName = name, UserGUID = guid };

        if (UserDataList.Find(data => data.UserName == userData.UserName) == null)
        {
            UserDataList.Add(userData);

            JSONManager.Serialize(UserDataList, Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

            return "Success: User data created.";
        }
        else
        {
            return "Error: User data already exists.";
        }
    }

    [HttpGet("/GetUserData/guid")]
    public static string GetUser(Guid guid)
    {
        UserDataList = JSONManager.Deserialize<List<UserData>>(Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        if (UserDataList.Find(data => data.UserGUID == guid) != null)
        {
            return UserDataList.Find(data => data.UserGUID == guid).UserName;
        }
        else
        {
            return "Error: User data does not exist.";
        }
    }

    [HttpGet("/Initialize")]
    public static string Initialize()
    {
        List<UserData> InitialList = new List<UserData>();

        JSONManager.Serialize(InitialList, Directory.GetCurrentDirectory() + "/DotnetProjectData/UserData.json");

        return "Initialized!";
    }
}

public class UserData
{
    public string UserName;
    public Guid UserGUID;
}
