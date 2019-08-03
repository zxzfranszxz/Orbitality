using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIController
{
    
    public readonly List<AIPlanetController> aiPlanetControllers = new List<AIPlanetController>();
    public IGameModeController GameModeController { get; protected set; }

    public AIController(IGameModeController gameModeController)
    {
        GameModeController = gameModeController;
    }

    public AIPlanetController CreateAIPlanetController(PlanetController planetController)
    {
        AIPlanetController aiPlanetController = new AIPlanetController();
        aiPlanetController.PlanetController = planetController;
        aiPlanetController.planetList = GameModeController.PlanetList;
        aiPlanetControllers.Add(aiPlanetController);

        return aiPlanetController;
    }

    public void Update()
    {
        foreach (AIPlanetController aIPlanetController in aiPlanetControllers)
            aIPlanetController.Update();
    }
}
