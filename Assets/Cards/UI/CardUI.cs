using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Card card;
    public Image cardImage;
    public Text costText;
    private CardPlayer builder;

    private void Awake()
    {
        builder = CardPlayer.instance;        
    }

    public void SetCard(Card c)
    {
        card = c;
        if (c == null)
        {
            return;
        }

        cardImage.sprite = card.icon;
        costText.text = card.cost.ToString();
    }

    public void Use()
    {
        builder.SetPlayingNow(card);
    }
}
