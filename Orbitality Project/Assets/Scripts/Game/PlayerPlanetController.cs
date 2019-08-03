using UnityEngine;
using System.Collections;


public class PlayerPlanetController
{
    
    public PlanetController PlanetController { get; set; }



    public void Shoot()
    {
        if (PlanetController != null)
            PlanetController.Shoot();
    }

    
}
