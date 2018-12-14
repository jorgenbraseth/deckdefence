using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    public static TurretBuilder instance;
    public GameObject buildFX;

    public Hand hand;
    public Card playingNow;

    private void Awake()
    {
        instance = this;
    }

    public bool CanAffordCurrentCard => playingNow.cost <= PlayerStats.instance.energy;

    public void buildOn(Tile tile)
    {        
        if (playingNow == null)
            return;

        if (!CanAffordCurrentCard)
            return;        

        if (tile.turret != null)
            return;

        hand.Play(playingNow);
        BuildingCard building = (BuildingCard) playingNow;
        GameObject toBuild = building.buildingPrefab;
        PlayerStats.instance.energy -= building.cost;
        Destroy(Instantiate(buildFX, tile.transform.position, Quaternion.identity), 5f);
        tile.turret = Instantiate(toBuild, tile.transform.position, Quaternion.identity);
        playingNow = null;
    }
}
