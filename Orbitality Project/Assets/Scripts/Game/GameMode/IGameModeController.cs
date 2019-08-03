using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IGameModeController 
{

    List<PlanetController> PlanetList { get; }

    PlayerPlanetController PlayerPlanetController { get; }
}
