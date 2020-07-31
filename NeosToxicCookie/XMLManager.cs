using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization; //Access XML serializer
using System.IO; //File management

/// <summary>
/// Saves and loads data in XML format. (UTF-8 Not included!)
/// </summary>
public static class XMLManager
{
    //Save
    public static void Serialize<T>(T data, string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        serializer.Serialize(fileStream, data);
        fileStream.Close();
    }

    //Load
    public static T Deserialize<T>(string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.Open);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        T DeserializedObject = (T)serializer.Deserialize(fileStream);
        fileStream.Close();
        return DeserializedObject;
    }

    //Delete
    public static void Delete(string path)
    {
        File.Delete(path);
    }
}