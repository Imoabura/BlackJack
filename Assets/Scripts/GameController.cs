using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    List<Card> deck;
    List<Card> playerHand;
    List<Card> dealerHand;

    [SerializeField] GameObject deckDisplay; // visual representation of deck

    void Awake()
    {
        deck = new List<Card>();
        playerHand = new List<Card>();
        dealerHand = new List<Card>();
        Card[] cardSOs = Resources.LoadAll<Card>("ScriptableObjects/CardSOs");
        foreach (Card c in cardSOs)
        {
            deck.Add(c);
        }
        ShuffleDeck();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; ++i)    // swap each index with a random index
        {
            int randomIndex = Random.Range(0, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }
}
