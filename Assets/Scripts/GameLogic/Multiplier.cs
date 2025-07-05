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
        bool isMultiplySuccessed;

        if (cube.GetMultiplierChance() >= Random.value)
        {
            isMultiplySuccessed = true;
            ExploseCube(_cubeSpawner.HandleMultiply(cube, isMultiplySuccessed));
        }
        else
        {
            isMultiplySuccessed = false;
            ExploseCube(_cubeSpawner.HandleMultiply(cube, isMultiplySuccessed));
        }
    }

    private void ExploseCube(Cube[] cubes)
    {
        if(cubes.Length == 1)
        {
            _explosioner.CreateExplosion(cubes[0]);
        }
        else
        {
            _explosioner.CreateExplosion(cubes);
        }
    }
}