using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip the_clip;
    public AudioSource audioSource;

    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = the_clip;
        audioSource.Play();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = the_clip;
            audioSource.Play();
        }
    }

    public AudioSource PlayClip(AudioClip clip, Vector3 pos)
    {
        GameObject temp = new GameObject("temp");
        temp.transform.position = pos;
        AudioSource audioSource = temp.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(temp, clip.length);
        return audioSource;
    }
}
