using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    private Collider _collider;
    private Rigidbody _rigidbody;
    private float _multiplierChance = 1f;

    private void Awake()
    {
        TryGetComponent<Rigidbody>(out _rigidbody);
        Rigidbody = _rigidbody;
    }

    public void DecreaseMultiplierChance()
    {
        _multiplierChance /= 2;
    }

    public float GetMultiplierChance()
    {
        return _multiplierChance;
    }

    public Rigidbody Rigidbody { get; private set; }
}
