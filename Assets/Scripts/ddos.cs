using UnityEngine;

public class ddos : MonoBehaviour
{
    private static ddos instance;

    public AudioClip[] playlist; // добавь треки сюда через инспектор
    private AudioSource audioSource;
    private int currentTrack = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();

            if (playlist.Length > 0)
            {
                audioSource.clip = playlist[currentTrack];
                audioSource.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (audioSource != null && !audioSource.isPlaying && playlist.Length > 0)
        {
            currentTrack = (currentTrack + 1) % playlist.Length;
            audioSource.clip = playlist[currentTrack];
            audioSource.Play();
        }
    }
}
