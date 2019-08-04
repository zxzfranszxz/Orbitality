using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SimpleFX : MonoBehaviour
{
    public AudioClip audioClip;

    public ParticleSystem ParticleSystem { get; protected set; }

    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();

        SoundManager.Instance.PlaySingle(audioClip);
    }


    void Update()
    {
        if (ParticleSystem.isStopped)
            Destroy(gameObject);
    }
}
