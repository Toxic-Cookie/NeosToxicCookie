using Newtonsoft.Json; //Access JSON serializer
using System.IO; //File management

/// <summary>
/// Saves and loads data in JSON format. (UTF-8 Not included!)
/// </summary>
public static class JSONManager
{
    //Save
    public static void Serialize<T>(T data, string path)
    {
        using (StreamWriter file = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, data);
        }
    }

    //Load
    public static T Deserialize<T>(string path)
    {
        using (StreamReader file = File.OpenText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            T DeserializedObject = (T)serializer.Deserialize(file, typeof(T));
            return DeserializedObject;
        }
    }

    //Delete
    public static void Delete(string path)
    {
        File.Delete(path);
    }
}