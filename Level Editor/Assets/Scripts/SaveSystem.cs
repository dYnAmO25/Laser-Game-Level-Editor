using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveLevel(string sPath)
    {
        TestFolder();
        
        BinaryFormatter formatter = new BinaryFormatter();
        string path = sPath;
        FileStream stream = new FileStream(path, FileMode.Create);

        Level data = new Level();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Level LoadLevel(string sPath)
    {
        TestFolder();

        string path = sPath;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Level data = formatter.Deserialize(stream) as Level;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Data not Found in " + path);
            return null;
        }
    }

    public static void TestFolder()
    {
        if (!Directory.Exists(Application.persistentDataPath + "/CustomLevels"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/CustomLevels");
        }
    }
}
