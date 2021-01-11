using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    Image cardImage;
    [SerializeField]
    TextMeshProUGUI cardName;
    [SerializeField]
    Card card;

    private void Start()
    {
        if (card == null)
        {
            Debug.LogWarning("No card data set!");
            return;
        }
        UpdateCard();
    }

    // Updates the card's visuals
    void UpdateCard()
    {
        cardImage.sprite = card.image;
        cardName.text = GetName();
    }

    // Sets Card data and updates card's display / if card is null, do nothing
    public void SetCardData(Card card)
    {
        if (card == null)
        {
            Debug.LogWarning("No card data!");
            return;
        }
        this.card = card;
        UpdateCard();
    }

    // toggle visibility of name text
    public void ShowName(bool enable)
    {
        cardName.enabled = enable;
    }

    // Translate card data to name (E.g., AS = Ace of Spades)
    string GetName()
    {
        string result = "";
        switch(card.rank)
        {
            default:
            case CardRank.ACE:
                result += "Ace";
                break;
            case CardRank.TWO:
                result += "Two";
                break;
            case CardRank.THREE:
                result += "Three";
                break;
            case CardRank.FOUR:
                result += "Four";
                break;
            case CardRank.FIVE:
                result += "Five";
                break;
            case CardRank.SIX:
                result += "Six";
                break;
            case CardRank.SEVEN:
                result += "Seven";
                break;
            case CardRank.EIGHT:
                result += "Eight";
                break;
            case CardRank.NINE:
                result += "Nine";
                break;
            case CardRank.TEN:
                result += "Ten";
                break;
            case CardRank.JACK:
                result += "Jack";
                break;
            case CardRank.QUEEN:
                result += "Queen";
                break;
            case CardRank.KING:
                result += "King";
                break;
        }

        result += " of ";

        switch(card.suit)
        {
            default:
            case CardSuit.CLUBS:
                result += "Clubs";
                break;
            case CardSuit.DIAMONDS:
                result += "Diamonds";
                break;
            case CardSuit.HEARTS:
                result += "Hearts";
                break;
            case CardSuit.SPADES:
                result += "Spades";
                break;
        }
        return result;
    }
}
