using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Deck deck;

    [SerializeField] Hand playerHand;
    [SerializeField] Hand dealerHand;

    [SerializeField] GameObject deckDisplay; // visual representation of deck

    enum GameState
    {
        setup,
        playerTurn,
        dealerTurn,
        gameOver,
        resultsPage,
    }

    GameState state = GameState.setup;

    void Awake()
    {
        Card[] cardSOs = Resources.LoadAll<Card>("ScriptableObjects/CardSOs");
        List<Card> cards = new List<Card>();
        foreach (Card c in cardSOs)
        {
            cards.Add(c);
        }
        deck.InitializeDeck(cards);
        deck.Shuffle();
    }

    private void SetupGame()
    {
        dealerHand.DrawCards(1);
        playerHand.DrawCards(1);
        dealerHand.DrawCards(1);
        playerHand.DrawCards(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (state == GameState.setup)
        {
            Debug.Log("You have: " + playerHand.GetValue());
            state = GameState.playerTurn;
        }
        if (state == GameState.playerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                state = GameState.dealerTurn;    // End turn (stay)
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerHand.DrawCards(1);
                Debug.Log("You have: " + playerHand.GetValue());
                if (playerHand.GetValue() > 21)
                {
                    state = GameState.gameOver;
                    Debug.Log("You lose. Dealer Wins!");
                }
            }
        }
        if (state == GameState.dealerTurn)
        {
            if(dealerHand.GetValue() < 17)
            {
                dealerHand.DrawCards(1);
                if (playerHand.GetValue() > 21)
                {
                    state = GameState.gameOver;
                    Debug.Log("You Win!");
                }
            }
            state = GameState.gameOver;
            if (playerHand.GetValue() > dealerHand.GetValue())
            {
                Debug.Log("You Win!");
            }
            else
            {
                Debug.Log("Dealer Wins!");
            }
        }
        if (state == GameState.gameOver)
        {
            dealerHand.Reveal();
            state = GameState.resultsPage;
        }
    }
}
