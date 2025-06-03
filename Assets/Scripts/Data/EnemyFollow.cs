using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyFollow : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D rb;
    public float speed = 2f;
    private bool isActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    public void ActivateChase()
    {
        isActive = true;
    }

    void FixedUpdate()
    {
        if (!isActive || target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);


        if (direction.x > 0.1f)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (direction.x < -0.1f)
            transform.localScale = new Vector3(1, 1, 1);
    }
}
