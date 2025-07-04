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
        _cubeSpawner.CubesMultiplySuccessed += ExploseMultiplyCube;
        _cubeSpawner.CubesMultiplyFailed += ExploseDeleteCube;
    }

    private void OnDestroy()
    {
        _clicker.CubeHitDetected -= MultiplyCube;
        _cubeSpawner.CubesMultiplySuccessed -= ExploseMultiplyCube;
        _cubeSpawner.CubesMultiplyFailed -= ExploseDeleteCube;
    }

    private void MultiplyCube(Cube cube)
    { 
        _cubeSpawner.HandleMultiply(cube);
    }

    private void ExploseMultiplyCube(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            _explosioner.CreateMultiplyExplosion(cube.Rigidbody);
        }
    }

    private void ExploseDeleteCube(Cube cube)
    {
        _explosioner.CreateDeleteExplosion(cube);
    }
}