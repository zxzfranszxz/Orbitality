﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public GameStarter GameStarter { get; protected set; }
    public SaveManager SaveManager { get; protected set; }

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
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
        GameStarter = new GameStarter();
        SaveManager = new SaveManager();

        new  GameObject("SoundManager").AddComponent<SoundManager>();
    }
    

    public void Quit()
    {
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        Time.timeScale = pause ? 0 : 1;
    }

    
}
