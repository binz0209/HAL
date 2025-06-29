using UnityEngine;
using UnityEngine.Video; // Để sử dụng VideoPlayer
using UnityEngine.SceneManagement; // Để sử dụng SceneManager

public class VideoEndTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public int sceneToLoad = 1;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video has finished. Loading next scene...");
        SceneManager.LoadScene(sceneToLoad);
    }
}
