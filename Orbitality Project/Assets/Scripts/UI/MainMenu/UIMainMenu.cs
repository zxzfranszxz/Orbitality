﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button loadButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    GameObject singlePlayerDialogPrefab;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayClick);
        loadButton.onClick.AddListener(OnLoadClick);
        quitButton.onClick.AddListener(OnQuitClick);
        
    }

    public void OnPlayClick()
    {
        Instantiate(singlePlayerDialogPrefab, transform);
    }

    public void OnLoadClick()
    {

    }

    public void OnQuitClick()
    {
        Game.Instance.Quit();
    }
}