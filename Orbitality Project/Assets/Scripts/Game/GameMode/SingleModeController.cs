﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleModeController : MonoBehaviour, IGameModeController
{
    [SerializeField]
    private UIGame uiGame;

    [SerializeField]
    private Transform spaceContainerTransform;

    public PlayerPlanetController PlayerPlanetController { get; protected set; }


    public List<PlanetController> PlanetList { get; } = new List<PlanetController>();

    public AIController AIController { get; protected set; }

    void Start()
    {
        uiGame.SingleModeController = this;
        Init();
    }

    private void Init()
    {
        PlayerPlanetController = new PlayerPlanetController();
        AIController = new AIController(this);

        if (Game.Instance.GameStarter.SingleModeSave == null)
            StartNewGame(Game.Instance.GameStarter.SinglePlayerMode.Enemies + 1);
        else
            StartLoadedGame(Game.Instance.GameStarter.SingleModeSave);

        UIPlanetHUDFactory uiPlanetHUDFactory = new UIPlanetHUDFactory(uiGame.hudContainerTransform);

        foreach (PlanetController planetController in PlanetList)
        {
            UIPlanetHUD uiPlanetHUD = uiPlanetHUDFactory.CreatePlanetHUD(planetController);
            if (planetController.PlanetModel.Id != PlayerPlanetController.PlanetController.PlanetModel.Id)
            {
                uiPlanetHUD.SetHPColor(Color.red);
                AIController.CreateAIPlanetController(planetController);
            }
        }

    }

    private void StartNewGame(int planets)
    {
        PlanetFactory planetFactory = new PlanetFactory(spaceContainerTransform);

        for (int i = 0; i < planets; i++)
        {
            PlanetController planetController = planetFactory.CreatePlanet();
            InitPlanet(planetController);
        }

        SetPlayerPlanet(PlanetList[Random.Range(0, PlanetList.Count)]);
    }

    private void StartLoadedGame(SingleModeSave singleModeSave)
    {
        PlanetFactory planetFactory = new PlanetFactory(spaceContainerTransform);

        foreach (PlanetModelSave modelSave in singleModeSave.planetModelSaveList)
        {
            PlanetController planetController = planetFactory.CreatePlanet(modelSave);
            InitPlanet(planetController);
        }

        PlanetController playerPlanetController = PlanetList.Find(p => p.PlanetModel.Id == singleModeSave.playerPlanetId);
        SetPlayerPlanet(playerPlanetController);
    }

    private void InitPlanet(PlanetController planetController)
    {
        planetController.OnDeathEvent += PlanetController_OnDeathEvent;
        PlanetList.Add(planetController);
    }

    private void PlanetController_OnDeathEvent(PlanetController planetController)
    {
        PlanetList.Remove(planetController);
        Destroy(planetController.PlanetView.gameObject);


        if (planetController == PlayerPlanetController.PlanetController)
            uiGame.ShowResults(false);

        if (PlanetList.Count == 1 && PlanetList[0] == PlayerPlanetController.PlanetController)
            uiGame.ShowResults(true);
    }

    private void Update()
    {
        foreach (PlanetController planetController in PlanetList)
            planetController.Update();

        AIController.Update();
    }

    private void SetPlayerPlanet(PlanetController planetController)
    {
        PlayerPlanetController.PlanetController = planetController;
        uiGame.UIPlayerHUD.SetPlayerPlanetController(PlayerPlanetController);
    }


    
}
