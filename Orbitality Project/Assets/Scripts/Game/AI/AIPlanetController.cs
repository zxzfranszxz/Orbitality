using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIPlanetController
{
    public List<PlanetController> planetList { get; set; }
    public PlanetController PlanetController { get; set; }


    public void Shoot()
    {
        if (PlanetController != null)
            PlanetController.Shoot();
    }

    public void Update()
    {
        //Debug.Log((PlanetController.PlanetModel.Angle - Mathf.PI / 2) * Mathf.Rad2Deg);
        if (PlanetController.PlanetModel.IsAlive && PlanetController.PlanetModel.IsRocketReady)
        {
            Quaternion quaternion = Quaternion.Euler(0, (PlanetController.PlanetModel.Angle - Mathf.PI / 2) * -Mathf.Rad2Deg , 0);
            foreach (PlanetController planetController in planetList)
            {
                if (planetController == PlanetController || !planetController.PlanetModel.IsAlive)
                    continue;

                Vector3 targetVector = planetController.PlanetView.transform.position - PlanetController.PlanetView.transform.position;

                Vector3 dirVector = (quaternion * targetVector);
                Vector3 dirVectorNormalized = dirVector.normalized;

                if (dirVectorNormalized.z > 0.5f)
                {
                    Shoot();
                    break;
                }
            }
        }
    }
}
