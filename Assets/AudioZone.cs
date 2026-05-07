using UnityEngine;

public class AudioZone : MonoBehaviour
{
    public AudioClip zoneAudio;
    [Range(0f, 1f)]
    public float volume = 1f;
    public bool isDefaultZone = false;

    private AudioSource audioSource;
    private static AudioZone currentZone;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        if (zoneAudio != null)
        {
            audioSource.clip = zoneAudio;
            audioSource.loop = true;
            audioSource.spatialBlend = 0f;
            audioSource.playOnAwake = false;
            audioSource.volume = 0f;
            audioSource.Play();
        }

        if (isDefaultZone)
        {
            audioSource.volume = volume;
            currentZone = this;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (audioSource == null) return;

        if (currentZone != null && currentZone != this)
        {
            if (currentZone.audioSource != null)
                currentZone.audioSource.volume = 0f;
        }

        audioSource.volume = volume;
        currentZone = this;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (audioSource == null) return;
        if (currentZone != this) return;
        audioSource.volume = 0f;
    }
}