using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private static Game instance;


    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(this);

        Init();


        
    }

    private void Init()
    {

    }
    

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    public static Game Instance
    {
        get
        {
            return instance;
        }
    }
}
