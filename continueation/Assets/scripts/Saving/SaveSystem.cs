
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveAtLocation(int[] data, string location)
    {
        //Debug.Log(number + " the number SavePlayer in SaveSystem got");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player." + location;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static int[] LoadFromLocation(string location)
    {
        string path = Application.persistentDataPath + "/player." + location;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            int[] data = formatter.Deserialize(stream) as int[];
            stream.Close();

            return data /* new PlayerData(1) */;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


    public static void SaveBoolAtLocation(bool data, string location)
    {
        //Debug.Log(number + " the number SavePlayer in SaveSystem got");
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player." + location;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static bool LoadBoolFromLocation(string location)
    {
        string path = Application.persistentDataPath + "/player." + location;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            bool data = (bool)formatter.Deserialize(stream);
            stream.Close();

            return data /* new PlayerData(1) */;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return false;
        }
    }


}