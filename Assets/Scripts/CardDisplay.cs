using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CardDisplay : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer cardImage;
    [SerializeField]
    Sprite cardBack;
    [SerializeField]
    TextMeshProUGUI cardName;
    [SerializeField]
    Card card;

    bool isFaceUp = false;
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (cardBack != null)
        {
            cardImage.sprite = cardBack;
            ShowName(false);
        }
        if (card == null)
        {
            Debug.LogWarning("No card data set!");
            return;
        }
        UpdateCard();
    }

    IEnumerator FlipCardAnimation()
    {
        animator.Play("CardFlip");
        yield return new WaitForSeconds(.25f);
        isFaceUp = !isFaceUp;
        cardImage.sprite = (isFaceUp) ? card.image : cardBack;
        if (!isFaceUp)
        {
            ShowName(false);
        }
    }

    public void SetCardBack(Sprite cardBack)
    {
        this.cardBack = cardBack;
        if (!isFaceUp)
        {
            UpdateCard();
        }
    }

    // Updates the card's visuals
    void UpdateCard()
    {
        cardName.text = GetName();
        if (!isFaceUp)
        {
            cardImage.sprite = cardBack;
        }
        else
        {
            cardImage.sprite = card.image;
        }
    }

    // flips card
    public void FlipCard()
    {
        if (card == null)
        {
            Debug.LogWarning("Cannot flip without card data!");
            return;
        }
        StartCoroutine(FlipCardAnimation());
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
    void ShowName(bool enable)
    {
        cardName.enabled = enable;
    }

    public void ToggleName()
    {
        if (isFaceUp)
        {
            cardName.enabled = !cardName.enabled;
        }
    }

    // Translate card data to name (E.g., AS = Ace of Spades)
    public string GetName()
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
