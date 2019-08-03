using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "RocketSO", menuName = "RocketSO")]
public class RocketSO : ScriptableObject
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float weight;
    [SerializeField]
    private float cooldown;

    public int Damage { get { return damage; } }
    public float Acceleration { get { return acceleration; } }
    public float Weight { get { return weight; } }
    public float Cooldown { get { return cooldown; } }
}
