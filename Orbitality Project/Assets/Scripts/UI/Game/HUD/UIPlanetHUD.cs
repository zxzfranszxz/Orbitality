using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlanetHUD : BasePlanetHUD
{



    public override void Init(PlanetModel planetModel)
    {
        base.Init(planetModel);

        PlanetModel.OnDeathEvent += PlanetModel_OnDeathEvent;
    }

    private void PlanetModel_OnDeathEvent(PlanetModel obj)
    {
        Destroy(gameObject);
    }

}
