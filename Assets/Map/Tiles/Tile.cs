using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public GameObject turret;
    
    public Color notBuildableColor;
    public Color buildableColor;
    private Color originalColor;

    private Renderer rend;

    public bool TileIsFree => turret == null;


    private bool CanUseCurrentCardOnThisTile =>
        TurretBuilder.instance.playingNow != null && TurretBuilder.instance.CanAffordCurrentCard && TileIsFree;
    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
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
            rend.material.color = originalColor;
            return;
        }

        var building = TurretBuilder.instance.playingNow;
        if (building == null)
            return;

        if (CanUseCurrentCardOnThisTile)
        {
            rend.material.color = buildableColor;
        }
        else
        {
            rend.material.color = notBuildableColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}