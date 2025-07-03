using UnityEngine;

public class Cube : MonoBehaviour
{
    private Collider _collider;
    private float _multiplierChance = 1f;

    public void DecreaseMultiplierChance() => _multiplierChance /= 2;

    public float GetMultiplierChance() => _multiplierChance;
}
