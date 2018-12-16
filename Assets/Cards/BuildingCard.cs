using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Building", order = 1)]
public class BuildingCard : Card 
{
    public GameObject buildingPrefab;

    public override bool playableOn(Tile t)
    {
        return t.TileIsFree;
    }
}
