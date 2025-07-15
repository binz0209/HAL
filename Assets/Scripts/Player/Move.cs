using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();               
        rb.freezeRotation = true;
    }

    void Update()
    {        
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
                
        moveInput = new Vector2(moveX, moveY).normalized;
              
        if (moveX > 0)
            transform.localScale = new Vector3(-1, 1, 1); 
        else if (moveX < 0)
            transform.localScale = new Vector3(1, 1, 1); 
    }

    void FixedUpdate()
    {        
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object has the "Teleport" tag
        if (other.CompareTag("Teleport"))
        {
            SaveManager.Instance.currentData.gold += CoinUIManager.Instance.getCoinValue();
            SaveManager.Instance.currentData.currentMapLevel++;
            SaveManager.Instance.Save();
            SceneManager.LoadScene(7);
        }
    }
}
