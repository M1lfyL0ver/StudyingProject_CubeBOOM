using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;

    public event Action<Cube[]> OnCubesMultiplied;

    public void HandleMultiply(Cube cube)
    {
        if (cube != null)
        {
            Multiply(cube);
        }
    }

    private void Multiply(Cube originalCube)
    {
        int CubeAmount = Random.Range(_minCubes, _maxCubes + 1);
        Cube[] newCubes = new Cube[CubeAmount];
        Vector3 originalPosition = originalCube.transform.position;
        Vector3 originalScale = originalCube.transform.localScale;

        if (originalCube.GetMultiplierChance() >= Random.value)
        {
            for (int i = 0; i < CubeAmount; i++)
            {
                newCubes[i] = Instantiate(originalCube, originalPosition, Quaternion.identity);
                newCubes[i].transform.localScale = originalScale / 2;
                newCubes[i].DecreaseMultiplierChance();
            }

            OnCubesMultiplied?.Invoke(newCubes);
        }

        Destroy(originalCube.gameObject);
    }
}
