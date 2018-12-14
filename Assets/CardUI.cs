using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Card card;
    public Image cardImage;
    public Text costText;
    private TurretBuilder builder;

    private void Awake()
    {
        builder = TurretBuilder.instance;
        cardImage.sprite = card.icon;
        costText.text = card.cost.ToString();
    }

    private void OnMouseDown()
    {
        Debug.Log(card);
    }

    public void Use()
    {
        builder.playingNow = card;
    }
}
