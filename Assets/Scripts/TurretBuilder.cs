using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    public static TurretBuilder instance;
    public GameObject buildFX;

    public Hand hand;
    private Card _playingNow;
    private GameObject buildPlaceholder;
    public Material buildableMaterial;
    public Material nonBuildableMaterial;

    private void Awake()
    {
        instance = this;
    }

    public bool CanAffordCurrentCard => _playingNow.cost <= PlayerStats.instance.energy;


    public void SetPlayingNow(Card c)
    {        
        _playingNow = c;
        if (c == null)
        {
            Destroy(buildPlaceholder);
            buildPlaceholder = null;
        }
        else
        {
            var prefab = ((BuildingCard)_playingNow).buildingPrefab;
            var placeHolder = Instantiate(prefab);        
            placeHolder.GetComponent<MonoBehaviour>().enabled = false;
            placeHolder.SetActive(false);
            buildPlaceholder = placeHolder;    
        }
        
    }

    public Card PlayingNow => _playingNow;
    
    public void buildOn(Tile tile)
    {        
        if (_playingNow == null)
            return;

        if (!CanAffordCurrentCard)
            return;        

        if (tile.turret != null)
            return;

        hand.Play(_playingNow);
        BuildingCard building = (BuildingCard) _playingNow;
        GameObject toBuild = building.buildingPrefab;
        PlayerStats.instance.energy -= building.cost;
        Destroy(Instantiate(buildFX, tile.transform.position, Quaternion.identity), 5f);
        tile.turret = Instantiate(toBuild, tile.transform.position, Quaternion.identity);
        SetPlayingNow(null);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetPlayingNow(null);            
        }
    }

    public void placeholderOn(Tile t)
    {
        if (buildPlaceholder == null)
            return;
        buildPlaceholder.transform.position = t.transform.position;
        buildPlaceholder.SetActive(true);

        bool canBuild = _playingNow != null && t.TileIsFree && CanAffordCurrentCard;
        if (canBuild)
        {
            MeshRenderer[] componentsInChildren = buildPlaceholder.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in componentsInChildren)
            {
                renderer.material = buildableMaterial;
            }
        }
        else
        {
            MeshRenderer[] componentsInChildren = buildPlaceholder.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in componentsInChildren)
            {
                renderer.material = nonBuildableMaterial;
            }
        }
        
        
    }
    public void placeholderOff(Tile t)
    {
        if (buildPlaceholder == null)
            return;

        buildPlaceholder.SetActive(false);                
    }
}
