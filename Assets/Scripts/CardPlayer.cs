using UnityEngine;

public class CardPlayer : MonoBehaviour
{
    public static CardPlayer instance;
    

    public Hand hand;
    private Card _playingNow;
    private GameObject widget;
    
    private void Awake()
    {
        instance = this;
    }

    public bool CanAffordCurrentCard => _playingNow.cost <= PlayerStats.instance.energy;


    public void SetPlayingNow(Card c)
    {        
        _playingNow = c;
        if (widget != null)
        {
            Destroy(widget);
        }

        if (c != null)
        {
            widget = Instantiate(c.GetWidget(), Vector3.zero, Quaternion.identity);
            widget.SetActive(false);
        }
                               
    }

    public Card PlayingNow => _playingNow;
    
    public void playCard(Tile tile)
    {        
        if (_playingNow == null)
            return;

        if (!CanAffordCurrentCard)
            return;        

        if (!_playingNow.playableOn(tile))
        {
            return;
        }

        
        if (_playingNow is BuildingCard)
        {
            ((BuildingCard) _playingNow).PlayOn(tile);            
        }
        else if(_playingNow is UpgradeCard)
        {
            ((UpgradeCard) _playingNow).PlayOn(tile);
        }
        hand.Play(_playingNow);
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
        if (widget == null)
            return;

        widget.transform.position = t.transform.position;
        if (!widget.activeSelf)
        {
            widget.SetActive(true);            
        }

        if (_playingNow.playableOn(t) && _playingNow.CanAfford)
        {
            colorize(widget,_playingNow.buildableMaterial);
        }
        else
        {
            colorize(widget,_playingNow.nonBuildableMaterial);
        }
        
    }
    public void placeholderOff(Tile t)
    {        
        if (_playingNow == null)
            return;

        if (widget != null)
        {
            widget.SetActive(false);            
        }                        
    }
    
    protected void colorize(GameObject o, Material mat)
    {
        MeshRenderer[] componentsInChildren = o.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in componentsInChildren)
        {
            renderer.material = mat;
        }
    }
}
