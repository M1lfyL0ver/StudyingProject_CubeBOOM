using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    public void CreateExplosion(Cube cube)
    {
        cube.TryGetComponent<Rigidbody>(out Rigidbody cubeToExplose);
        cubeToExplose.AddExplosionForce(_force, cubeToExplose.transform.position, _radius, _upwardModifier, ForceMode.Impulse);
    }
}