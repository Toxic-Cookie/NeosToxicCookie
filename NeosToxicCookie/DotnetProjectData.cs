using System;
using System.Collections.Generic;

[Serializable]
public static class DotnetProjectData
{
    public static List<UserData> UserDataList;
}

public class UserData
{
    public string UserName;
    public Guid UserGUID;
}
