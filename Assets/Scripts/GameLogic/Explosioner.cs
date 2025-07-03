using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    public void CreateExplosion(Rigidbody cube)
    {
        cube.AddExplosionForce(_force, cube.transform.position, _radius, _upwardModifier, ForceMode.Impulse);
    }
}