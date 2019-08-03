using UnityEngine;
using System.Collections;


public class PlanetModel
{
    public event System.Action<PlanetModel> OnUpdateEvent;
    public event System.Action<PlanetModel> OnDeathEvent;
    public event System.Action<PlanetModel> OnShootEvent;

    public int Id { get; protected set; }
    public int MaxHP { get; protected set; }
    public int HP { get; protected set; }
    public float OrbitRadius { get; protected set; }
    public float Angle { get; protected set; }

    public RocketSO RocketSO { get; protected set; }

    public float TimeToReload { get; protected set; }

    public bool IsAlive { get; protected set; }
    

    public PlanetModel(int maxHP, int id, RocketSO rocketSO)
    {
        Id = id;

        HP = MaxHP = maxHP;
        IsAlive = true;

        OrbitRadius = Data.minOrbitRadius + (id - 1) * Data.orbitStep;

        RocketSO = rocketSO;

        Angle += 2 * Mathf.PI * Random.value;
    }

    public PlanetModel(PlanetModelSave modelSave, RocketSO rocketSO)
    {
        RocketSO = rocketSO;

        Id = modelSave.id;
        HP = modelSave.hp;
        MaxHP = modelSave.maxHP;
        OrbitRadius = modelSave.orbitRadius;
        IsAlive = modelSave.isAlive;
        Angle = modelSave.angle;

        TimeToReload = modelSave.timeToReload;
    }

    public void Update()
    {
        if (TimeToReload > 0)
        {
            TimeToReload -= Time.deltaTime;
            if (TimeToReload < 0)
                TimeToReload = 0;
        }


        Angle += (Time.deltaTime * -Data.planetSpeed) / OrbitRadius;

        if (Angle < 0)
            Angle += 2 * Mathf.PI;
        else if (Angle > 2 * Mathf.PI)
            Angle -= 2 * Mathf.PI;
    }

    public void Shoot()
    {
        if (TimeToReload > 0 || !IsAlive)
            return;

        TimeToReload = RocketSO.Cooldown;
        if (OnShootEvent != null)
            OnShootEvent.Invoke(this);
    }

    public void Damage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            IsAlive = false;

            if(OnDeathEvent != null)
                OnDeathEvent.Invoke(this);
        }

        if (OnUpdateEvent != null)
            OnUpdateEvent.Invoke(this);
    }

    public bool IsRocketReady
    {
        get
        {
            return TimeToReload <= 0;
        }
            
    }
}
