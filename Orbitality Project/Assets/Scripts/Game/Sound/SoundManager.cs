using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioSource EfxSource { get; protected set; }

    public static SoundManager Instance { get; protected set; }

    public AudioClipManager AudioClipManager { get; protected set; }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        EfxSource = GetComponent<AudioSource>();

        AudioClipManager = new AudioClipManager();

        EfxSource.playOnAwake = false;

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        EfxSource.clip = clip;
        EfxSource.Play();
    }
}
