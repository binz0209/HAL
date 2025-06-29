using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button continueButton;

    private void Start()
    {
        string savePath = System.IO.Path.Combine(Application.dataPath, "Saves/save.json");
        bool hasSave = System.IO.File.Exists(savePath);

        continueButton.interactable = hasSave;
    }

    public void OnClickContinue()
    {
        SaveManager.Instance.Load();
        Debug.Log("Loaded save.json, starting game...");
        int level = SaveManager.Instance.currentData.currentMapLevel;
        Debug.Log($"Current map level: {level}");
        SceneManager.LoadScene($"Scenes/InGame/Map_{level}");
    }

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
