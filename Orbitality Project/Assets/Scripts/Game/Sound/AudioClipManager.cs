using UnityEngine;
using System.Collections;

public class AudioClipManager
{

    public AudioClip ButtonAC { get; protected set; }
    public AudioClip RocketLaunchAC { get; protected set; }
    public AudioClip RocketDestroyAC { get; protected set; }
    
    public AudioClipManager()
    {
        ButtonAC = Resources.Load<AudioClip>(ResourcesData.soundsPath + "ButtonClick");
        RocketLaunchAC = Resources.Load<AudioClip>(ResourcesData.soundsPath + "RocketLaunch");
        RocketDestroyAC = Resources.Load<AudioClip>(ResourcesData.soundsPath + "RocketExplosion");
    }

}
