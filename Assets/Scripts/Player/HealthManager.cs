using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image Health;
    public float healthAmount = 100f;
    public float damageOnCollision = 10f;

    public float flashDuration = 0.2f;
    private bool isFlashing = false;
    private float flashTimer = 0f;
    private SpriteRenderer[] spriteRenderers;
    private Color[] originalColors;

    private GameOver gameOverScript;
    private bool gameOverCalled = false;
    private float maxHealth;
    void Start()
    {
        if (SaveManager.Instance.currentData.selectedCharacter.Equals("XHum"))
        {
            healthAmount = 250f + SaveManager.Instance.currentData.healthLevel * 10f;
        }
        else if (SaveManager.Instance.currentData.selectedCharacter.Equals("VanAn"))
        {
            healthAmount = 150f + SaveManager.Instance.currentData.healthLevel * 10f;
        } else if (SaveManager.Instance.currentData.selectedCharacter.Equals("TuLinh"))
        {
            healthAmount = 200f + SaveManager.Instance.currentData.healthLevel * 10f;
        }
        maxHealth = healthAmount;
        Debug.Log("Health Amount: " + healthAmount);
        // Tìm Health Bar
        if (Health == null)
        {
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                Transform healthTransform = canvas.transform.Find("Health");
                if (healthTransform != null)
                {
                    Health = healthTransform.GetComponent<Image>();
                }
            }
        }

        // Lưu lại tất cả SpriteRenderer con của nhân vật
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        originalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            originalColors[i] = spriteRenderers[i].color;
        }

        // Tìm GameOver script trên scene
        gameOverScript = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (healthAmount <= 0 && !gameOverCalled)
        {
            gameOverCalled = true;

            if (gameOverScript != null)
                gameOverScript.ShowGameOver();

            // Tắt Collider
            Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
            foreach (var col in colliders)
            {
                col.enabled = false;
            }
            Destroy(gameObject, 1f);
        }


        if (isFlashing)
        {
            flashTimer += Time.deltaTime;
            if (flashTimer <= flashDuration)
            {
                foreach (var sr in spriteRenderers)
                {
                    sr.color = Color.red;
                }
            }
            else
            {
                for (int i = 0; i < spriteRenderers.Length; i++)
                {
                    spriteRenderers[i].color = originalColors[i];
                }
                isFlashing = false;
            }
        }
    }

    public void TakeDamage(float damage, Vector2 knockbackDir, float knockbackForce = 10f)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, maxHealth);

        if (Health != null)
            Health.fillAmount = healthAmount / maxHealth;

        AudioManager.Instance.PlayDamaged();

        // Bắt đầu flash đỏ
        isFlashing = true;
        flashTimer = 0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy_We"))
        {
            Vector2 knockbackDir = transform.position - collision.transform.position;
            TakeDamage(damageOnCollision, knockbackDir);
        }
    }
}
