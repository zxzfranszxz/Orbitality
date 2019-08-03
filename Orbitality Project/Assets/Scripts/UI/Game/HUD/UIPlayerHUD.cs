using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPlayerHUD : BasePlanetHUD
{
    public PlayerPlanetController PlayerPlanetController { get; protected set; }

    [SerializeField]
    Button shootButton;

    private void Start()
    {
        shootButton.onClick.AddListener(OnShootClick);
    }

    private void OnShootClick()
    {
        PlayerPlanetController.Shoot();
    }

    public void SetPlayerPlanetController(PlayerPlanetController playerPlanetController)
    {
        PlayerPlanetController = playerPlanetController;

        if(PlayerPlanetController != null)
            base.Init(PlayerPlanetController.PlanetController.PlanetModel);
    }


}
