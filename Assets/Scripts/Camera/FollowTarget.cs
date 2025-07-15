using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject playerSpawner;  // PlayerSpawner object chứa SPUM_Base(Clone)
    public Vector3 offset;            // Khoảng cách giữa camera và target
    public float smoothSpeed = 0.125f; // Tốc độ di chuyển của camera
    public EdgeCollider2D boundaryCollider; // EdgeCollider2D của object chứa boundary

    private Transform target;         // Target sẽ được gán trong mã (không cần gán trong Inspector)
    private Vector2 minBounds;        // Giới hạn min của camera
    private Vector2 maxBounds;        // Giới hạn max của camera
    private float camHalfHeight;      // Chiều cao nửa camera
    private float camHalfWidth;       // Chiều rộng nửa camera

    void Start()
    {
        if (playerSpawner != null)
        {
            // Dò tìm SPUM_Base(Clone) trong PlayerSpawner có tag "Player"
            Transform player = FindPlayerInSpawner(playerSpawner);

            if (player != null)
            {
                target = player;  // Gán target là SPUM_Base(Clone)
            }
            else
            {
                Debug.LogWarning("No Player (SPUM_Base) found in PlayerSpawner with tag 'Player'!");
            }
        }
        else
        {
            Debug.LogWarning("PlayerSpawner not assigned!");
        }

        // Tính toán các giá trị giới hạn camera từ EdgeCollider2D
        if (boundaryCollider != null)
        {
            Vector2[] points = boundaryCollider.points;
            if (points.Length > 0)
            {
                // Chuyển các điểm collider sang world space
                Vector2 worldMin = boundaryCollider.transform.TransformPoint(points[0]);
                Vector2 worldMax = worldMin;

                foreach (Vector2 point in points)
                {
                    Vector2 worldPoint = boundaryCollider.transform.TransformPoint(point);
                    worldMin = Vector2.Min(worldMin, worldPoint);
                    worldMax = Vector2.Max(worldMax, worldPoint);
                }

                minBounds = worldMin;
                maxBounds = worldMax;
            }
        }

        // Lấy thông tin camera
        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    // Hàm dò tìm SPUM_Base(Clone) trong PlayerSpawner
    Transform FindPlayerInSpawner(GameObject spawner)
    {
        // Kiểm tra tất cả các đối tượng con trong PlayerSpawner
        foreach (Transform child in spawner.transform)
        {
            if (child.CompareTag("Player"))
            {
                Debug.Log("Found Player (SPUM_Base) with tag 'Player': " + child.name);
                // Nếu tìm thấy SPUM_Base(Clone) có tag "Player", trả về transform của nó
                return child;
            }
        }

        // Nếu không tìm thấy, trả về null
        return null;
    }

    void LateUpdate()
    {
        if (target == null || boundaryCollider == null)
            return;

        // Vị trí camera sẽ đến (chỉ thay đổi x và y, giữ nguyên z)
        Vector3 desiredPosition = target.position + offset;

        // Giới hạn camera trong boundary (dùng min và max bounds từ EdgeCollider2D)
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        // Cập nhật vị trí camera mượt mà, giữ nguyên Z
        transform.position = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, transform.position.z), smoothSpeed);
    }
}
