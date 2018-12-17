using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public Turret turret;
    
    private Renderer rend;

    public bool TileIsFree => turret == null;


    private bool CanUseCurrentCardOnThisTile =>
        CardPlayer.instance.PlayingNow != null && CardPlayer.instance.CanAffordCurrentCard && TileIsFree;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        CardPlayer.instance.playCard(this);
    }

    private void OnMouseOver()
    {        
        
        if (EventSystem.current.IsPointerOverGameObject())
        {
            CardPlayer.instance.placeholderOff(this);
            return;
        }

        var building = CardPlayer.instance.PlayingNow;
        if (building == null)
            return;

        CardPlayer.instance.placeholderOn(this);
    }

    private void OnMouseExit()
    {
        CardPlayer.instance.placeholderOff(this);
    }
}