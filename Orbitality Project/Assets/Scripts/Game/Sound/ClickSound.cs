using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ClickSound : MonoBehaviour
{
    private static ClickSound instance;
    private AudioSource source;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
        source = GetComponent<AudioSource>();
        source.playOnAwake = false;
    }
    
    public static void Click()
    {
        if(instance != null)
            instance.source.Play();
    }
}
