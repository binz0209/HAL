using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager Instance;

    public enum OperationMode
    {
        None,
        LoadGame,
        SaveGame
    }

    private string nextSceneName;
    private OperationMode mode = OperationMode.None;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("[LoadingManager] Ready (Singleton).");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Debug.Log("[LoadingManager] Standby → wait StartOperation().");
    }

    public void StartOperation(string sceneName, OperationMode opMode)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("[LoadingManager] SceneName null!");
            return;
        }

        nextSceneName = sceneName;
        mode = opMode;

        Debug.Log($"[LoadingManager] Next Scene: {nextSceneName} | Mode: {mode}");

        switch (mode)
        {
            case OperationMode.LoadGame:
                if (SaveManager.Instance.currentData == null && SaveManager.Instance.HasSave())
                {
                    SaveManager.Instance.Load();
                    Debug.Log("[LoadingManager] Loaded save file.");
                }
                break;

            case OperationMode.SaveGame:
                if (SaveManager.Instance.currentData != null)
                {
                    SaveManager.Instance.Save();
                    Debug.Log("[LoadingManager] Saved new data.");
                }
                else
                {
                    Debug.LogWarning("[LoadingManager] No data to save!");
                }
                break;

            default:
                Debug.LogError("[LoadingManager] Mode invalid!");
                return;
        }

        StartCoroutine(LoadNextSceneAsync());
    }

    private System.Collections.IEnumerator LoadNextSceneAsync()
    {
        Debug.Log("[LoadingManager] Loading scene...");

        yield return new WaitUntil(() =>
            SaveManager.Instance != null &&
            (mode == OperationMode.LoadGame ? SaveManager.Instance.currentData != null : true)
        );

        yield return new WaitForSeconds(1f);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
