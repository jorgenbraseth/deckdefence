using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public float energy = 100f;
    public float maxEnergy = 500f;
    public float incomeRatePerSecond = 10f;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        AddEnergy(Time.deltaTime / (1/incomeRatePerSecond));
    }

    public void AddEnergy(float amount)
    {
        energy += amount;
        energy = Mathf.Clamp(energy, 0, 500);
    }
}
