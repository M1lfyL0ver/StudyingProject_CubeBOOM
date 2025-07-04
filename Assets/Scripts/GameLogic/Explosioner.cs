using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _force = 5f;
    [SerializeField] private float _upwardModifier = 1f;

    public void CreateMultiplyExplosion(Rigidbody cube)
    {
        cube.AddExplosionForce(_force, cube.transform.position, _radius, _upwardModifier, ForceMode.Impulse);
    }

    public void CreateDeleteExplosion(Cube cube)
    {
        float explosionForce = 50f * cube.transform.localScale.x;
        float explosionRadius = 25f * cube.transform.localScale.x;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.attachedRigidbody;

            if (rigidbody != null)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                float forceMultiplier = 1 - Mathf.Clamp01(distance / explosionRadius);

                rigidbody.AddExplosionForce(
                    explosionForce * forceMultiplier,
                    transform.position,
                    explosionRadius,
                    _upwardModifier,
                    ForceMode.Impulse
                );
            }
        }
    }
}