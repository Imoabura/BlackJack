using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField] int maxSize = 11;  // 11 for BlackJack (4 + 8 + 9 = 21)

    [SerializeField] Deck deck;

    List<Card> hand;

    HandDisplay handDisplay;

    public delegate void OnCardAdded(Hand target, Card data);
    public static OnCardAdded OnCardAddedCallback;

    void Awake()
    {
        hand = new List<Card>();
        handDisplay = GetComponent<HandDisplay>();
    }

    public int GetSize()
    {
        return hand.Count;
    }

    public int GetValue()
    {
        int total = 0;
        foreach (Card c in hand)
        {
            total += c.GetValue();
        }
        return total;
    }

    public void FillHand()
    {
        if (hand.Count < maxSize)
        {
            DrawCards(maxSize - hand.Count);
        }
    }

    public void DrawCards(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            if (hand.Count >= maxSize)  // if hand has reached maxSize
            {
                Debug.LogWarning("Can't hold any more cards!");
                continue; // To-Do: burn the cards
            }
            Card data = deck.Draw();
            hand.Add(data);  // draw card from deck and put it into hand
            OnCardAddedCallback.Invoke(this, data);
        }
    }

    public void Reveal()
    {
        handDisplay.RevealAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
