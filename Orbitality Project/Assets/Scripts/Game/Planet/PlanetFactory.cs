using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetFactory
{
    GameObject planetRef;
    Transform parentT;

    int countId = 1;
    List<RocketSO> rocketSOList;

    public PlanetFactory(Transform parent)
    {
        parentT = parent;
        planetRef = Resources.Load<GameObject>(ResourcesData.planetPath);

        rocketSOList = new List<RocketSO>();
        rocketSOList.AddRange( Resources.LoadAll<RocketSO>(ResourcesData.rocketsPath) );
    }

    public PlanetController CreatePlanet()
    {
        RocketSO randomRocketSO = rocketSOList[Random.Range(0, rocketSOList.Count)];
        PlanetModel planetModel = new PlanetModel(Data.planetMaxHP, countId, randomRocketSO);


        GameObject planetGO = GameObject.Instantiate(planetRef, parentT);
        PlanetView planetView = planetGO.GetComponent<PlanetView>();
        planetView.PlanetModel = planetModel;



        PlanetController planetController = new PlanetController(planetModel, planetView);

        countId++;
        return planetController;
    }

    public PlanetController CreatePlanet(PlanetModelSave modelSave)
    {
        RocketSO rocketSO = rocketSOList.Find(p => p.name == modelSave.rocketSOName);
        PlanetModel planetModel = new PlanetModel(modelSave, rocketSO);


        GameObject planetGO = GameObject.Instantiate(planetRef, parentT);
        PlanetView planetView = planetGO.GetComponent<PlanetView>();
        planetView.PlanetModel = planetModel;


        PlanetController planetController = new PlanetController(planetModel, planetView);
        return planetController;
    }
}
