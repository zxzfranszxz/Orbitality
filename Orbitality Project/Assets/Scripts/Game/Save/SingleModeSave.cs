using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class SingleModeSave
{
    public List<PlanetModelSave> planetModelSaveList = new List<PlanetModelSave>();

    public int playerPlanetId;

    public SingleModeSave(List<PlanetController> planetList, int playerPlanetId)
    {
        this.playerPlanetId = playerPlanetId;

        foreach(PlanetController planetController in planetList)
        {
            PlanetModelSave planetModelSave = new PlanetModelSave(planetController.PlanetModel);
            planetModelSaveList.Add(planetModelSave);
        }
    }
}

[Serializable]
public class PlanetModelSave
{
    public int id;
    public int maxHP;
    public int hp;
    public float orbitRadius;
    public float angle;


    public string rocketSOName;

    public float timeToReload;

    public bool isAlive;

    public PlanetModelSave(PlanetModel planetModel)
    {
        id = planetModel.Id;
        maxHP = planetModel.MaxHP;
        hp = planetModel.HP;
        orbitRadius = planetModel.OrbitRadius;
        angle = planetModel.Angle;
        rocketSOName = planetModel.RocketSO.name;
        timeToReload = planetModel.TimeToReload;
        isAlive = planetModel.IsAlive;
    }
}
