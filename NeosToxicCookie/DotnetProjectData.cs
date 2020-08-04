using System;
using System.Collections.Generic;

public static class DotnetProjectData
{
    public static List<UserData> UserDataList;
}

public class UserData
{
    public string UserName;
    public Guid UserGUID;
}

public class CookieClickerData
{
    public string Player;

    public float Cookies;
}
