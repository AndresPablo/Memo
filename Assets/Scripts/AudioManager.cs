using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    #region SINGLETON
    public static AudioManager instance;
    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }
    #endregion

    [SerializeField] AudioSource source;
    [SerializeField] AudioClip click1;
    [SerializeField] AudioClip click2;
    [SerializeField] AudioClip flip;
    [SerializeField] AudioClip notMatch;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        source.Pause();
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }

    public void PlayClip(AudioClip clip)
    {
        source.clip = clip;
        Play();
    }

    public void PlayRandomOneShot(AudioClip[] clips)
    {
        if (clips == null || clips.Length == 0)
            return;
        int index = Random.Range(0, clips.Length + 1);
        source.PlayOneShot(clips[index]);
    }

    public void PlayOneShot(AudioClip clip, bool randomizePitch = false)
    {
        if (clip == null)
            return;

        if (randomizePitch) source.pitch = (Random.Range(0.6f, .9f));

        source.PlayOneShot(clip);

        if (randomizePitch) source.pitch = 1f;
    }

    public void PlayNoMatchFX()
    {
        PlayOneShot(notMatch);
    }

    public void PlayClick1()
    {
        PlayOneShot(click1);
    }

    public void PlayClick2()
    {
        PlayOneShot(click2);
    }

    public void PlayFlip()
    {
        PlayOneShot(flip);
    }
}