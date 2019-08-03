using UnityEngine;
using System.Collections;

public class UIPlanetHUDFactory
{
    GameObject PlanetHUDPrefab;

    Transform containerTransform;

    public UIPlanetHUDFactory(Transform containerTransform)
    {
        this.containerTransform = containerTransform;

        PlanetHUDPrefab = Resources.Load<GameObject>(ResourcesData.planetHUDPath);
    }

    public UIPlanetHUD CreatePlanetHUD(PlanetController planetController)
    {
        GameObject planetHUDGO = GameObject.Instantiate(PlanetHUDPrefab, containerTransform);

        UIPlanetHUD uiPlanetHUD = planetHUDGO.GetComponent<UIPlanetHUD>();
        uiPlanetHUD.Init(planetController.PlanetModel);

        UIFollowTo3dTarget uiFollowTo3DTarget = planetHUDGO.AddComponent<UIFollowTo3dTarget>();
        uiFollowTo3DTarget.SetTarget(planetController.PlanetView.transform);
        uiFollowTo3DTarget.offset = Data.planetHUDOffset;

        return uiPlanetHUD;
    }


}
