using UnityEngine;
using Random = UnityEngine.Random;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explosioner _explosioner;

    private void Awake()
    {
        _clicker.CubeHitDetected += MultiplyCube;
    }

    private void OnDestroy()
    {
        _clicker.CubeHitDetected -= MultiplyCube;
    }

    private void MultiplyCube(Cube cube)
    {
        if (cube.MultiplierChance >= Random.value)
        {
            ExploseCube(_cubeSpawner.HandleSuccessedMultiply(cube));
            _cubeSpawner.DestroyCube(cube);
        }
        else
        {
            _cubeSpawner.DestroyCube(cube);
        }
    }

    private void ExploseCube(Cube[] cubes)
    {
        _explosioner.CreateExplosion(cubes);
    }

    private void ExploseCube(Cube cube)
    {
        _explosioner.CreateExplosion(cube);
    }
}