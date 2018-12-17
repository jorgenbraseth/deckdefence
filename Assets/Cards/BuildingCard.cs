using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Building", order = 1)]
public class BuildingCard : Card 
{
    public GameObject buildingPrefab;
    private GameObject placeholder;
    

    private void Awake()
    {
        placeholder = Instantiate(buildingPrefab);        
        placeholder.GetComponent<MonoBehaviour>().enabled = false;
        placeholder.SetActive(false);                   
    }

    public override bool playableOn(Tile t)
    {
        return t.TileIsFree;
    }

    public override GameObject GetWidget()
    {
        return placeholder;
    }

    public void PlayOn(Tile t)
    {
        PlayerStats.instance.energy -= cost;        
        t.turret = Instantiate(buildingPrefab, t.transform.position, Quaternion.identity).GetComponent<Turret>();
        Destroy(Instantiate(PlayEffect, t.transform.position, Quaternion.identity), 5f);
        
    }
}
