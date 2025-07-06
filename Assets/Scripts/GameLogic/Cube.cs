using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _multiplierChance = 1f;
    private float _decreaseNumber = 2f;

    public Rigidbody Rigidbody => _rigidbody;

    public float MultiplierChance => _multiplierChance;

    private void Awake()
    {
        TryGetComponent(out _rigidbody);
    }

    public void DecreaseMultiplierChance()
    {
        _multiplierChance /= _decreaseNumber;
    }
}