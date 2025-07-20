using System.Collections;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameoverText;
    private bool isGameOver = false;
    private ChangeScene changeSceneObject;

    public void Start()
    {
        changeSceneObject = FindObjectOfType<ChangeScene>();
    }
    public void ShowGameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        if (gameoverText != null)
        {
            gameoverText.text = "Game Over";
            gameoverText.alpha = 0f;
            gameoverText.gameObject.SetActive(true);
            StartCoroutine(FadeInText());
        }

        // Delay 5s and load main menu  
        StartCoroutine(DelayedDeleteDataAndGoToMainMenu(5f));
    }

    private IEnumerator FadeInText()
    {
        float duration = 2f;
        float timer = 0f;
        while (timer < duration)
        {
            gameoverText.alpha = Mathf.Lerp(0f, 1f, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        gameoverText.alpha = 1f;
    }

    private IEnumerator DelayedDeleteDataAndGoToMainMenu(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        changeSceneObject.DeleteDataAndGoToMainMenu();
    }
}
