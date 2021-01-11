using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardRank
{
    ACE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT,
    NINE,
    TEN,
    JACK,
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
    public CardSuit suit;
    public CardRank rank;
}
