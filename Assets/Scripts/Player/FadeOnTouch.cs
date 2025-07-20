using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapFadeOnTouch : MonoBehaviour
{
    public float fadeDuration = 1f;
    [Range(0f, 1f)]
    public float targetAlpha = 0.9f;

    private bool isFading = false;
    private bool isRestoring = false;
    private float fadeTimer = 0f;
    private Tilemap tilemap;
    private Color originalColor;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        if (tilemap != null)
        {
            originalColor = tilemap.color;
        }
    }

    void Update()
    {
        if (isFading && tilemap != null)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, targetAlpha, fadeTimer / fadeDuration);
            tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            if (fadeTimer >= fadeDuration)
            {
                isFading = false;
                tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
            }
        }
        else if (isRestoring && tilemap != null)
        {
            fadeTimer += Time.deltaTime;
            float alpha = Mathf.Lerp(targetAlpha, 1f, fadeTimer / fadeDuration);
            tilemap.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            if (fadeTimer >= fadeDuration)
            {
                isRestoring = false;
                tilemap.color = originalColor;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isFading = true;
            isRestoring = false;
            fadeTimer = 0f;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isRestoring = true;
            isFading = false;
            fadeTimer = 0f;
        }
    }
}