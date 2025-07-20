using UnityEngine;

public class SettingsMenuManager : MonoBehaviour
{
    public GameObject settingsMenuPrefab;  // Kéo Prefab vào Inspector

    private static SettingsMenuManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (settingsMenuPrefab != null)
            {
                GameObject menu = Instantiate(settingsMenuPrefab);
                DontDestroyOnLoad(menu);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
