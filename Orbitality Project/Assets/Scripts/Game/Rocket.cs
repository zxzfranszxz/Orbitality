using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour
{
    public GameObject explosionFX;

    private RocketSO rocketSO;

    Rigidbody rigidBody;

    float timeToDeath = 10;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        
    }

    private void Start()
    {
        rigidBody.velocity = transform.forward * Data.planetSpeed * (rocketSO.Acceleration / 10f);

        SoundManager.Instance.PlaySingle(SoundManager.Instance.AudioClipManager.RocketLaunchAC);
        
    }

    public RocketSO RocketSO
    {
        set
        {
            rocketSO = value;

            transform.localScale = new Vector3(1, 1, 1) * Mathf.Sqrt(rocketSO.Weight);
            rigidBody.mass = rocketSO.Weight;
        }
    }

    void Update()
    {
        if (rocketSO)
        {
            rigidBody.AddForce(transform.forward * rocketSO.Acceleration * Time.deltaTime, ForceMode.Acceleration);

            transform.rotation = Quaternion.LookRotation(rigidBody.velocity);
        }

        timeToDeath -= Time.deltaTime;
        if (timeToDeath < 0)
        {
            CreateExplosion(transform.parent);
            Destroy(gameObject);
        }
            

    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform fxParentTransform = transform.parent;

        if(collision.gameObject.tag == "planet")
        {
            PlanetView planetView = collision.gameObject.GetComponent<PlanetView>();
            if(planetView && rocketSO)
            {
                planetView.Damage(rocketSO.Damage);
            }

            fxParentTransform = collision.transform;
        }
        else if (collision.gameObject.tag == "rocket")
            return;


        CreateExplosion(fxParentTransform);
        Destroy(gameObject);
    }

    private void CreateExplosion(Transform parent)
    {
        Instantiate(explosionFX, transform.position, transform.rotation, parent);
    }


}
