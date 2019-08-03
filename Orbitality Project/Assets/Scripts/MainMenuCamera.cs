using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, Mathf.Sin(Time.time / 2) * 4, 0);
    }
}
