using UnityEngine;

public class Multiplier : MonoBehaviour
{
    [SerializeField] private Clicker _clicker;
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private Explosioner _explosioner;

    private void Awake()
    {
        _clicker.OnCubeHit += MultiplyCube;
        _cubeSpawner.OnCubesMultiplied += ExploseCube;
    }

    private void OnDisable()
    {
        _clicker.OnCubeHit -= MultiplyCube;
        _cubeSpawner.OnCubesMultiplied -= ExploseCube;
    }

    private void MultiplyCube(Cube cube)
    {
        _cubeSpawner.HandleMultiply(cube);
    }

    private void ExploseCube(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            _explosioner.CreateExplosion(cube);
        }
    }
}