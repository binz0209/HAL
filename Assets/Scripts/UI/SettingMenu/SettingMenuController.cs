using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsMenu;  // Đối tượng menu cài đặt
    public TMP_Text healthText;
    public TMP_Text damageText;

    private SaveData playerData;
    void Start()
    {
        settingsMenu.SetActive(false);
        playerData = SaveManager.Instance.currentData;
        healthText.text = "HP: " + playerData.healthLevel.ToString();
        damageText.text = "DMG: " + playerData.powerLevel.ToString();
    }

    public void ToggleSettingsMenu()
    {
        // Kiểm tra trạng thái hiện tại và chuyển sang trạng thái ngược lại
        bool isActive = settingsMenu.activeSelf;
        settingsMenu.SetActive(!isActive);
    }
    public void GoToMainMenuScenes()
    {
        SceneManager.LoadScene(1);
    }
    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
