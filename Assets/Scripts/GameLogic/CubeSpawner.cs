using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;

    public event Action<Cube[]> OnCubesMultiplied;

    private float _decreaseNumber = 2f;

    public void HandleMultiply(Cube cube)
    {
        if (cube != null)
        {
            Multiply(cube);
        }
    }

    private void Multiply(Cube originalCube)
    {
        int cubeAmount = Random.Range(_minCubes, _maxCubes + 1);
        Cube[] newCubes = new Cube[cubeAmount];
        Vector3 originalPosition = originalCube.transform.position;
        Vector3 originalScale = originalCube.transform.localScale;

        if (originalCube.GetMultiplierChance() >= Random.value)
        {
            for (int i = 0; i < cubeAmount; i++)
            {
                newCubes[i] = Instantiate(originalCube, originalPosition, Quaternion.identity);
                newCubes[i].transform.localScale = originalScale / _decreaseNumber;
                newCubes[i].DecreaseMultiplierChance();
            }

            OnCubesMultiplied?.Invoke(newCubes);
        }

        Destroy(originalCube.gameObject);
    }
}
