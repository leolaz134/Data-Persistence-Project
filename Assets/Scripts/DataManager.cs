using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string Name;

    public int highscore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public int highscore;
        public string Name;
    }
    public void SaveDataToFile()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // One master load for all data
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            highscore = data.highscore;
        }
    }

    public void DeleteData()
{
    string path = Application.persistentDataPath + "/savefile.json";
    
    if (File.Exists(path))
    {
        // 1. Delete the physical file
        File.Delete(path);
        
        // 2. Reset the variables in memory so the game knows they are gone
        Name = "";
        highscore = 0;
        
        Debug.Log("Data Deleted and Variables Reset!");
    }
}
}
