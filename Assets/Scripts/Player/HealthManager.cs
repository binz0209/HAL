using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image Health;
    public float healthAmount = 100f;
    public float damageOnCollision = 10f;

    void Start()
    {
        // Tự động tìm Canvas → Health
        if (Health == null)
        {
            healthAmount = SaveManager.Instance.currentData.healthLevel;
            GameObject canvas = GameObject.Find("Canvas");
            if (canvas != null)
            {
                Transform healthTransform = canvas.transform.Find("Health");
                if (healthTransform != null)
                {
                    Health = healthTransform.GetComponent<Image>();
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy object 'Health' trong Canvas.");
                }
            }
        }
    }

    void Update()
    {
        if (healthAmount <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void TakeDamage(float damage, Vector2 knockbackDir, float knockbackForce = 10f)
    {
        healthAmount -= damage;
        healthAmount = Mathf.Clamp(healthAmount, 0, SaveManager.Instance.currentData.healthLevel);
        if (Health != null)
            Health.fillAmount = healthAmount / SaveManager.Instance.currentData.healthLevel;
        AudioManager.Instance.PlayDamaged();
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
