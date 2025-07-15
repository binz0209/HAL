using UnityEngine;

public class CameraBoundary : MonoBehaviour
{
    public Vector2 boundaryMin; // Giới hạn dưới (min) của camera (ví dụ: Vector2(-10, -10))
    public Vector2 boundaryMax; // Giới hạn trên (max) của camera (ví dụ: Vector2(10, 10))

    // Bạn có thể sử dụng collider của môi trường để tự động tính toán boundary
    void OnDrawGizmos()
    {
        // Vẽ các gizmos trong editor để dễ dàng thấy boundary
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(boundaryMin.x, boundaryMin.y, 0), new Vector3(boundaryMax.x, boundaryMin.y, 0)); // Bottom
        Gizmos.DrawLine(new Vector3(boundaryMax.x, boundaryMin.y, 0), new Vector3(boundaryMax.x, boundaryMax.y, 0)); // Right
        Gizmos.DrawLine(new Vector3(boundaryMax.x, boundaryMax.y, 0), new Vector3(boundaryMin.x, boundaryMax.y, 0)); // Top
        Gizmos.DrawLine(new Vector3(boundaryMin.x, boundaryMax.y, 0), new Vector3(boundaryMin.x, boundaryMin.y, 0)); // Left
    }
}
