using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class GameStarter
{
    public SinglePlayerMode SinglePlayerMode { get; protected set;}
    public SingleModeSave SingleModeSave { get; protected set; }

    public GameStarter()
    {
        SinglePlayerMode = new SinglePlayerMode(4,5);
    }

    public void StartGame(SinglePlayerMode singlePlayerMode)
    {
        SingleModeSave = null;
        SinglePlayerMode = singlePlayerMode;

        SceneManager.LoadScene("SingleMode");
    }

    public void LoadGame()
    {
        if (!Game.Instance.SaveManager.IsSaveAvaliable)
            return;

        SingleModeSave = Game.Instance.SaveManager.Load();

        if (SingleModeSave != null)
            SceneManager.LoadScene("SingleMode");
    }
}
