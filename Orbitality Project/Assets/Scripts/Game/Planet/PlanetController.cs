using UnityEngine;
using System.Collections;
using System;

public class PlanetController
{
    public event Action<PlanetController> OnDeathEvent;

    public PlanetModel PlanetModel { get; protected set; }
    public PlanetView PlanetView { get; protected set; }

    public PlanetController(PlanetModel planetModel, PlanetView planetView)
    {
        PlanetModel = planetModel;
        PlanetView = planetView;

        PlanetModel.OnShootEvent += PlanetView.Shoot;
        PlanetView.OnDamageEvent += PlanetModel.Damage;

        PlanetModel.OnDeathEvent += PlanetModel_OnDeath;

    }

    private void PlanetModel_OnDeath(PlanetModel obj)
    {
        if (OnDeathEvent != null)
            OnDeathEvent.Invoke(this);
    }

    public void Shoot()
    {
        PlanetModel.Shoot();
    }

    public void Update()
    {
        PlanetModel.Update();
    }
    
}
