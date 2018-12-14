using UnityEngine;

[System.Serializable]
public class Card : ScriptableObject
{
    public int cost;
    private PlayerStats stats;
    public Sprite icon;

    private void Awake()
    {
        stats = PlayerStats.instance;
    }

    public bool CanAfford => stats.energy >= cost;
}
