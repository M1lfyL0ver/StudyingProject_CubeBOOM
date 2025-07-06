using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private float _decreaseNumber = 2f;

    public Rigidbody Rigidbody { get; private set; }

    public float MultiplierChance { get; private set; } = 1f;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void DecreaseMultiplierChance()
    {
        MultiplierChance /= _decreaseNumber;
    }
}