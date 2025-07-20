using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void GoToNewGame1Scenes()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMainMenuScenes()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToNewGame2Scenes()
    {
        SceneManager.LoadScene(3);
    }
    public void GoToContinueScene()
    {
        if (SaveManager.Instance.HasSave())
        {
            SaveData data = SaveManager.Instance.Load();

            string mapToLoad = "";
            switch (data.currentMapLevel)
            {
                case 1:
                    mapToLoad = "Scenes/InGame/Map_1";
                    break;
                case 2:
                    mapToLoad = "Scenes/InGame/Map_2";
                    break;
                default:
                    mapToLoad = "Scenes/InGame/Map_1"; // fallback
                    break;
            }

            SceneManager.LoadScene(6);
            LoadingManager.Instance.StartOperation(mapToLoad, LoadingManager.OperationMode.LoadGame);
        }
    }

    //Delete data after deadth and changescene main menu
    public void DeleteDataAndGoToMainMenu()
    {
        SaveManager.Instance.ClearSave();
        SceneManager.LoadScene(1);
    }

    //Delete Data and Quit Game
    public void DeleteDataAndQuitGame()
    {
        SaveManager.Instance.ClearSave();
        Application.Quit();
    }
}
