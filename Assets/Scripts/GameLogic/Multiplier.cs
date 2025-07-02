using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody), typeof(Renderer))]

public class Multiplier : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 10f;
    [SerializeField] private float _explosionRadius = 5f;

    private float _multiplyChance = 1f;
    private GameObject _prefabToMultiply;
    private Renderer _renderer;
    private Rigidbody _rigidbody;

    public void HandleMultiply()
    {
        bool shouldSplit = Random.value <= _multiplyChance;

        if (shouldSplit && _multiplyChance > 0.01f) 
        {
            Multiply();
        }

        Destroy(gameObject);
    }

    private void Awake()
    {
        _prefabToMultiply = gameObject;
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
        _renderer.material.color = Random.ColorHSV();
    }

    private void Multiply()
    {
        int cubesToSpawn = Random.Range(2, 7); 
        Vector3 originalScale = transform.localScale;
        Vector3 originalPosition = transform.position;

        for (int i = 0; i < cubesToSpawn; i++)
        {
            GameObject newObject = Instantiate(_prefabToMultiply, originalPosition, Quaternion.identity); 
            newObject.transform.localScale = originalScale / 2f;

            Rigidbody newRigibody = newObject.GetComponent<Rigidbody>();
            Multiplier multiplyScript = newObject.GetComponent<Multiplier>();

            newRigibody.AddExplosionForce(_explosionForce, originalPosition, _explosionRadius);

            multiplyScript._multiplyChance = _multiplyChance / 2f;
            multiplyScript._explosionForce = _explosionForce;
            multiplyScript._explosionRadius = _explosionRadius;
        }
    }
}