using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetView : MonoBehaviour
{
    public event System.Action<int> OnDamageEvent;

    
    private float uvSpeed = 1f;
    private float circlesSpeed = 1f;

    

    GameObject rocketPrefab;

    public PlanetModel PlanetModel { get; set; }

    public GameObject Circles;

    private Material material;

    void Start()
    {
        uvSpeed = (Random.value - 0.5f) * 2;
        circlesSpeed = (Random.value - 0.5f) * 100;

        material = GetComponent<MeshRenderer>().material;
        material.color = new Color(Random.value, Random.value, Random.value);

        transform.localScale = new Vector3( 1, 1, 1) * Data.planetSize;

        rocketPrefab = Resources.Load<GameObject>(ResourcesData.rocketPrefabPath);


        if (Circles)
            Circles.SetActive( Random.value > 0.5f ? true : false);
    }
    
    void Update()
    {
        if(PlanetModel != null)
        {
            transform.position = new Vector3(Mathf.Sin(PlanetModel.Angle), 0, Mathf.Cos(PlanetModel.Angle)) * PlanetModel.OrbitRadius;
            transform.rotation = Quaternion.Euler(0, (PlanetModel.Angle - Mathf.PI / 2) * Mathf.Rad2Deg, 0);
        }

        Vector2 mainTextureOffset = material.GetTextureOffset("_DetailAlbedoMap");
        mainTextureOffset.x +=  uvSpeed * Time.deltaTime;

        material.SetTextureOffset("_DetailAlbedoMap", mainTextureOffset);

        if (Circles)
            Circles.transform.Rotate(Vector3.up, circlesSpeed * Time.deltaTime);
    }

    public void Damage(int damage)
    {
        if (OnDamageEvent != null)
            OnDamageEvent.Invoke(damage);
    }


    public void Shoot(PlanetModel planetModel)
    {
        GameObject rocketGO = Instantiate(rocketPrefab, transform.parent);
        rocketGO.transform.position = GetForwardPoint();
        rocketGO.transform.rotation = transform.rotation;
        Rocket rocket = rocketGO.GetComponent<Rocket>();
        rocket.RocketSO = planetModel.RocketSO;
    }
    
    public Vector3 GetForwardPoint()
    {
        return transform.position + transform.forward * Data.planetSize;
    }
}
