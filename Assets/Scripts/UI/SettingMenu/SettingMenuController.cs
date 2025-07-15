using UnityEngine;

public class SettingsMenuController : MonoBehaviour
{
    public GameObject settingsMenu;  // Đối tượng menu cài đặt

    void Start()
    {
        // Ẩn menu cài đặt khi bắt đầu trò chơi
        settingsMenu.SetActive(false);
    }

    public void ToggleSettingsMenu()
    {
        // Kiểm tra trạng thái hiện tại và chuyển sang trạng thái ngược lại
        bool isActive = settingsMenu.activeSelf;
        settingsMenu.SetActive(!isActive);
    }

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
