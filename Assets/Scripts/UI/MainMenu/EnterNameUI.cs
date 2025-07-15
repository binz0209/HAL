using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnterNameUI : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void OnNext()
    {
        string playerName = nameInput.text.Trim();
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.LogWarning("Name should not be empty");
            return;
        }

        SaveManager.Instance.pendingPlayerName = playerName;
        Debug.Log($"Player name set to: {playerName}");
        SceneManager.LoadScene(3);
    }
}