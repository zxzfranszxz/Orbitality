﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIPauseDialog : MonoBehaviour
{
    [SerializeField]
    Button resumeButton;
    [SerializeField]
    Button saveButton;
    [SerializeField]
    Button loadButton;
    [SerializeField]
    Button quitButton;

    public UIGame UIGame { get; set; }

    Game game;
    // Use this for initialization
    void Start()
    {
        game = Game.Instance;

        resumeButton.onClick.AddListener(OnResumeClick);
        saveButton.onClick.AddListener(OnSaveClick);
        loadButton.onClick.AddListener(OnLoadClick);
        quitButton.onClick.AddListener(OnQuitClick);
    }

    public void OnResumeClick()
    {
        game.Pause(false);
        Destroy(gameObject);
    }

    public void OnSaveClick()
    {

    }

    public void OnLoadClick()
    {

    }

    public void OnQuitClick()
    {
        game.Pause(false);
        SceneManager.LoadScene("MainMenu");
    }
}
