using UnityEngine;
using System.Collections;

public class SinglePlayerMode
{
    public const int minEnemies = 1;
    public const int maxEnemies = 5;
    public int Enemies { get; protected set; }


    public SinglePlayerMode(int min, int max)
    {
        Enemies = Random.Range(min, max + 1);
    }

    

    public static SinglePlayerMode CreateSinglePlayerMode(int min, int max)
    {
        if (min < minEnemies || max > maxEnemies || min > max)
            return null;

        return new SinglePlayerMode(min, max);
    }


}
