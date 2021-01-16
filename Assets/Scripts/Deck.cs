using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [SerializeField] int maxSize = 52;

    List<Card> deck;

    void Awake()
    {
        deck = new List<Card>();
    }

    public int GetSize()
    {
        return deck.Count;
    }

    public void InitializeDeck(List<Card> cards)
    {
        if (deck.Count != 0) {  // If deck isn't empty
            Debug.LogWarning("Deck not empty!");
            return;
        }
        if (cards.Count > maxSize)  // If trying to initalize more cards than maxSize
        {
            Debug.LogWarning("Initializing too many cards!");
            return;
        }
        for (int i = 0; i < cards.Count; ++i)   // Add the cards
        {
            deck.Add(cards[i]);
        }
    }

    public void Clear()
    {
        deck.Clear();
    }

    public void Shuffle()
    {
        for (int i = 0; i < deck.Count; ++i)    // swap each index with a random index
        {
            int randomIndex = Random.Range(0, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public Card Draw()
    {
        if (deck.Count <= 0)
        {
            Debug.LogWarning("Deck is Empty!");
            return null;
        }
        Card result = deck[0];
        deck.Remove(result);
        return result;
    }

    //public void DebugCards()
    //{
    //    foreach (Card c in deck)
    //    {
    //        Debug.Log(c);
    //    }
    //}

}
