using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardRank
{
    ACE, // 0
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    JACK,   // 10
    QUEEN,
    KING,
    RANK_MAX
}

public enum CardSuit
{
    CLUBS,
    DIAMONDS,
    HEARTS,
    SPADES,
    SUIT_MAX
}

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
public class Card : ScriptableObject
{
    public Sprite image;
    public Texture texture;
    public CardSuit suit;
    public CardRank rank;

    public int GetValue()   // For Simple BlackJack
    {
        int num = (int)rank;
        if (num < 9)    // If 9 or lower
        {
            return num + 1;
        }
        else   // If 10 or higher
        {
            return 10;
        }
    }
}
