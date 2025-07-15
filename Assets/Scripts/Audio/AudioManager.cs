using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource bgmSource;
    public AudioSource sfxSource;

    public AudioClip bgmClip;
    public AudioClip clickClip;
    public AudioClip attackClip; // Default attack sound
    public AudioClip axeClip;
    public AudioClip swordClip;
    public AudioClip damagedClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        // Singleton Pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }
    }
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    public void PlayBGM()
    {
        if (bgmSource && bgmClip)
        {
            bgmSource.clip = bgmClip;
            bgmSource.loop = true;
            bgmSource.Play();
        }
    }

    public void PlayClick()
    {
        if (sfxSource && clickClip)
        {
            if (!sfxSource.isPlaying) 
            {
                sfxSource.PlayOneShot(clickClip);
            }
            else
            {
                sfxSource.Stop();
                sfxSource.PlayOneShot(clickClip);
            }
        }
    }

    public void PlayAttack()
    {
        AudioClip clipToPlay = null;
        clipToPlay = swordClip;
        sfxSource.PlayOneShot(swordClip);
    }

    public void PlayDamaged()
    {
        if (sfxSource && damagedClip)
        {
            sfxSource.PlayOneShot(damagedClip);
        }
    }
}
