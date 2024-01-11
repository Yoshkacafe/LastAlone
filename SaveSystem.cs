using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    private static string DirectoryPath;
    private static bool Initialized;

    public static void Init()
    {
        DirectoryPath = $"{Application.dataPath}/Save/";

        if (Directory.Exists(DirectoryPath))
        {
            Directory.CreateDirectory(DirectoryPath);
        }

        Initialized = true;
    }

    public static void Save(object DataToSave, string FileName = "Save")
    {
        if(!Initialized)
        {
            Init();
        }

        string JSONSave = JsonUtility.ToJson(DataToSave);

        if(File.Exists($"{DirectoryPath}{FileName}.json"))
        {
            File.Delete($"{DirectoryPath}{FileName}.json");
        }

        StreamWriter SaveFileWriter = new StreamWriter($"{DirectoryPath}{FileName}.json");
        SaveFileWriter.WriteLine(JSONSave);
        SaveFileWriter.Close();

    }

    public static void Load<T>(out T LoadedData, string FileName = "Save")
    {
        if(!Initialized)
        {
            Init();
        }

        StreamReader SaveFileReader = new StreamReader($"{DirectoryPath}{FileName}.json");
        string JSONSave = SaveFileReader.ReadLine();
        LoadedData = JsonUtility.FromJson<T>(JSONSave);

    }
}
