using UnityEngine;

[System.Serializable]
public abstract class Card : ScriptableObject
{
    public int cost;
    private PlayerStats stats;
    public Sprite icon;
    public Material buildableMaterial;
    public Material nonBuildableMaterial;
    public GameObject PlayEffect;

    private void Awake()
    {
        stats = PlayerStats.instance;
    }

    public bool CanAfford => PlayerStats.instance.energy >= cost;

    public abstract bool playableOn(Tile t);    

    public abstract GameObject GetWidget();

    
}
