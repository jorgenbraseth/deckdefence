using Cards.Turrets;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Upgrade", order = 1)]
public class UpgradeCard : Card
{
    public GameObject castGizmoPrefab;
    public GameObject Badge;

    public override bool playableOn(Tile t)
    {
        return !t.TileIsFree;
    }

    public override GameObject GetWidget()
    {
        return castGizmoPrefab;
    }

    public void PlayOn(Tile tile)
    {
        ITurret turret = tile.turret;
        turret.AddBadge(Badge);    
        if(turret is Turret)
            ((Turret)turret).fireRate *= 2;

        if (turret is LaserTurret)
            ((LaserTurret) turret).dps *= 2;
        Destroy(Instantiate(PlayEffect, tile.transform.position, Quaternion.identity),3f);
        }
}
