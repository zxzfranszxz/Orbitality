using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStarter
{
    public SinglePlayerMode SinglePlayerMode { get; protected set;}

    public GameStarter()
    {
        SinglePlayerMode = new SinglePlayerMode(4,5);
    }

    public void StartGame(SinglePlayerMode singlePlayerMode)
    {

        SinglePlayerMode = singlePlayerMode;

        SceneManager.LoadScene("SingleMode");
    }
    

}
