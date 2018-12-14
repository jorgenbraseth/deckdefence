using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    [SerializeField] private Deck deck;    

    public CardUI cardUIPrefab;
    // Start is called before the first frame update

    private readonly Dictionary<Card, CardUI> cardsInHand = new Dictionary<Card, CardUI>();
    void Start()
    {
        DrawHand();        
    }

    private void DrawHand()
    {
        List<Card> drawn = deck.Draw(5);
        foreach (Card c in drawn)
        {
            Card card = Instantiate(c);
            var cardUI = Instantiate(cardUIPrefab, transform);            
            cardUI.SetCard(card);
            cardsInHand[card] = cardUI;
        }
    }

    private void Update()
    {
        if (cardsInHand.Keys.Count == 0)
        {
            DrawHand();
        }
    }

    public void Play(Card card)
    {        
        var cardUi = cardsInHand[card];
        cardsInHand.Remove(card);     
        Destroy(card);
        Destroy(cardUi.gameObject);
    }

}
