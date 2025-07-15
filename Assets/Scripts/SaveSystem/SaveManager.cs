using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public SaveData currentData;
    public string pendingPlayerName;

    private string saveDirectory;
    private string saveFileName = "save.json";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            saveDirectory = Path.Combine(Application.persistentDataPath, "Saves");
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string fullPath = Path.Combine(saveDirectory, saveFileName);
        string json = JsonUtility.ToJson(currentData, true);
        File.WriteAllText(fullPath, json);
        // Log content of the save file for debugging purposes
        if (currentData != null)
        {
            Debug.Log($"Saving data: {json}");
        }
        else
        {
            Debug.LogWarning("Current data is null, nothing to save.");
        }
        Debug.Log($"Game saved to: {fullPath}");
    }

    public SaveData Load()
    {
        string fullPath = Path.Combine(saveDirectory, saveFileName);
        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            currentData = JsonUtility.FromJson<SaveData>(json);
            return currentData;
        }
        else
        {
            Debug.LogWarning("Save file not found.");
            return null;
        }
    }

    public bool HasSave()
    {
        string fullPath = Path.Combine(saveDirectory, saveFileName);
        return File.Exists(fullPath);
    }

}
