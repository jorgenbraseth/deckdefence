using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] public Card[] cardsInDeck;

    private List<Card> deck;

    private void Awake()
    {
        BuildDeck();
    }

    private void BuildDeck()
    {
        List<Card> built = new List<Card>();        
        for (int i = 0; i < 10; i++)
        {
            int toPick = Random.Range(0, cardsInDeck.Length);
            built.Add(cardsInDeck[toPick]);            
        }

        deck = built;
    }

    public List<Card> Draw(int i)
    {
        List<Card> drawn = new List<Card>(i);
        for (int j = 0; j < i; j++)
        {
            drawn.Add(Draw());
        }

        return drawn;
    }

    private Card Draw()
    {
        if (deck.Count == 0)
        {
            BuildDeck();
        }

        Card drawn = deck[0];
        deck.Remove(drawn);
        return drawn;
    }
}