using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public GameObject turret;
    
    private Renderer rend;

    public bool TileIsFree => turret == null;


    private bool CanUseCurrentCardOnThisTile =>
        TurretBuilder.instance.PlayingNow != null && TurretBuilder.instance.CanAffordCurrentCard && TileIsFree;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        TurretBuilder.instance.buildOn(this);
    }

    private void OnMouseOver()
    {        
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            TurretBuilder.instance.placeholderOff(this);
            return;
        }

        var building = TurretBuilder.instance.PlayingNow;
        if (building == null)
            return;

        TurretBuilder.instance.placeholderOn(this);
    }

    private void OnMouseExit()
    {
        TurretBuilder.instance.placeholderOff(this);
    }
}