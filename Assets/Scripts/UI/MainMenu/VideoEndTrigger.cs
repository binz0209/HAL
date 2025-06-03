using UnityEngine;
using UnityEngine.Video; // Để sử dụng VideoPlayer
using UnityEngine.SceneManagement; // Để sử dụng SceneManager

public class VideoEndTrigger : MonoBehaviour
{
    public VideoPlayer videoPlayer;  // Tham chiếu đến VideoPlayer
    public string sceneToLoad = "Scenes/MainMenu";  // Tên scene bạn muốn chuyển đến khi video kết thúc

    void Start()
    {
        // Đảm bảo VideoPlayer đã được gán
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        // Đăng ký sự kiện khi video kết thúc
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // Hàm được gọi khi video kết thúc
    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video has finished. Loading next scene...");
        SceneManager.LoadScene(sceneToLoad);  // Chuyển đến scene mới
    }
}
