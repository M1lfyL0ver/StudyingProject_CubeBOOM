using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minCubes = 2;
    [SerializeField] private int _maxCubes = 6;

    private float _decreaseNumber = 2f;

    public Cube[] HandleMultiply(Cube cube, bool isMultiply)
    {
        if (cube != null && isMultiply == true)
        {
            return Multiply(cube);
        }
        else
        {
            Cube[] cubes = new Cube[1];
            cubes[0] = cube;

            DestroyCube(cube);

            return cubes;
        }
    }

    private Cube[] Multiply(Cube originalCube)
    {
        int cubeAmount = Random.Range(_minCubes, _maxCubes + 1);
        Cube[] newCubes = new Cube[cubeAmount];
        Vector3 originalPosition = originalCube.transform.position;
        Vector3 originalScale = originalCube.transform.localScale;

        for (int i = 0; i < cubeAmount; i++)
        {
            newCubes[i] = Instantiate(originalCube, originalPosition, Quaternion.identity);
            newCubes[i].transform.localScale = originalScale / _decreaseNumber;
            newCubes[i].DecreaseMultiplierChance();
        }

        DestroyCube(originalCube);

        return newCubes;
    }

    private void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}
