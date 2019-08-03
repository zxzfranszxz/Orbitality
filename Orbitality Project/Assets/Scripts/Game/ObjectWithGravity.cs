using UnityEngine;
using System.Collections;

public class ObjectWithGravity : MonoBehaviour
{
    public float gravityPower;
    public float gravityRange;


    int layerMask; 
    void Start()
    {
        layerMask = 1 << 8;
    }

    public void FixedUpdate()
    {
        foreach (Collider collider in Physics.OverlapSphere(transform.position, gravityRange, layerMask))
        {

            Vector3 forceDirection = transform.position - collider.transform.position;
            
            collider.attachedRigidbody.AddForce(forceDirection.normalized * gravityPower * collider.attachedRigidbody.mass, ForceMode.Acceleration);
        }
    }
}
