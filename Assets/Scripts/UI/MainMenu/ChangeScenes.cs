using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void GoToNewGame1Scenes()
    {
        SceneManager.LoadScene("Scenes/NewGame_1_EnterName");
    }
    public void GoToMainMenuScenes()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
    public void GoToNewGame2Scenes()
    {
        SceneManager.LoadScene("Scenes/NewGame_2_Character");
    }
}
