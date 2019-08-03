using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class BasePlanetHUD : MonoBehaviour
{
    [SerializeField]
    protected Slider hpBar;
    [SerializeField]
    protected Slider cdBar;

    public PlanetModel PlanetModel { get; protected set; }

    public virtual void Init(PlanetModel planetModel)
    {
        PlanetModel = planetModel;
        PlanetModel.OnUpdateEvent += PlanetModel_OnUpdateEvent;

        PlanetModel_OnUpdateEvent(PlanetModel);
    }

    protected virtual void PlanetModel_OnUpdateEvent(PlanetModel planetModel)
    {
        hpBar.value = PlanetModel.HP / (float)PlanetModel.MaxHP;
    }

    protected virtual void Update()
    {
        if (PlanetModel == null)
            return;

        float cd = PlanetModel.RocketSO.Cooldown;
        cdBar.value = (cd - PlanetModel.TimeToReload) / cd;
    }

    public void SetHPColor(Color color)
    {
        hpBar.fillRect.GetComponent<Image>().color = color;
    }

    public Slider HPBar
    {
        get { return hpBar; }
    }
}
