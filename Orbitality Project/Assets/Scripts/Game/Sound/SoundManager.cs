using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; protected set; }

    public AudioClipManager AudioClipManager { get; protected set; }

    private List<AudioSource> SingleAudioSourceList;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        

        AudioClipManager = new AudioClipManager();
        SingleAudioSourceList = new List<AudioSource>();

        DontDestroyOnLoad(gameObject);
    }



    private void Update()
    {
        foreach(AudioSource audioSource in SingleAudioSourceList)
        {
            if (!audioSource.isPlaying)
                Destroy(audioSource);
        }
        SingleAudioSourceList.RemoveAll(p => p.isPlaying == false);
    }

    public void PlaySingle(AudioClip clip)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = false;
        audioSource.Play();
        SingleAudioSourceList.Add(audioSource);
    }
}
