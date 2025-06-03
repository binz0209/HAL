using UnityEngine;
using UnityEngine.UI; // Để sử dụng Button UI

public class QuitGame : MonoBehaviour
{
    public void QuitApplication()
    {
        Debug.Log("Quitting the game..."); // Log ra Console để kiểm tra
        Application.Quit(); // Dừng chương trình
    }
}
