using UnityEngine;
using System.Collections;


public class Rocket : MonoBehaviour
{
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
            Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "planet")
        {
            PlanetView planetView = collision.gameObject.GetComponent<PlanetView>();
            if(planetView && rocketSO)
            {
                planetView.Damage(rocketSO.Damage);
            }
        }
        if (collision.gameObject.tag == "rocket")
            return;

        Destroy(gameObject);
    }


}
