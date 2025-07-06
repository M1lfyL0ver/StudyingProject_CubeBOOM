using UnityEngine;

public class Explosioner : MonoBehaviour
{
    [SerializeField] private float _radiusMultiplyExplosion = 5f;
    [SerializeField] private float _forceMultiplyExplosion = 5f;
    [SerializeField] private float _upwardModifierMultiplyExplosion = 1f;
    [SerializeField] private float _radiusDeleteExplosion = 25f;
    [SerializeField] private float _forceDeleteExplosion = 50f;

    public void CreateExplosion(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.Rigidbody.AddExplosionForce(_forceMultiplyExplosion, cube.transform.position, _radiusMultiplyExplosion, _upwardModifierMultiplyExplosion, ForceMode.Impulse);
        }
    }

    public void CreateExplosion(Cube cube)
    {
        float explosionRadius = _radiusDeleteExplosion * cube.transform.localScale.x;
        float explosionForce = _forceDeleteExplosion * cube.transform.localScale.x;

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.attachedRigidbody;

            if (rigidbody != null)
            {
                float distance = transform.position.SqrDistance(hit.transform.position);
                float forceMultiplier = 1 - Mathf.Clamp01(distance / explosionRadius);

                rigidbody.AddExplosionForce(
                    explosionForce * forceMultiplier,
                    transform.position,
                    explosionRadius,
                    _upwardModifierMultiplyExplosion,
                    ForceMode.Impulse
                );
            }
        }
    }
}