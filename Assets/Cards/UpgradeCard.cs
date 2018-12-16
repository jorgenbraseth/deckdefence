using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Upgrade", order = 1)]
public class UpgradeCard : Card 
{
    public override bool playableOn(Tile t)
    {
        return !t.TileIsFree;
    }
}
