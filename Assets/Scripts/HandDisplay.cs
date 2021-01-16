using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour
{
    [SerializeField] float spacing;

    [SerializeField] GameObject cardPrefab;

    Hand hand;

    // Start is called before the first frame update
    void Start()
    {
        Hand.OnCardAddedCallback += AddCard;
        hand = GetComponent<Hand>();
    }

    public void AddCard(Hand target, Card data)
    {
        if (target.gameObject == this.gameObject)
        {
            CardDisplay newCard = Instantiate(cardPrefab, this.transform).GetComponent<CardDisplay>();
            newCard.SetCardData(data);
            if (target.gameObject.tag == "Player")
            {
                newCard.FlipCard();
            }
            FitCards();
        }
    }

    private void FitCards()
    {
        if (hand.GetSize() <= 0)
        {
            Debug.Log("No Cards in hand");
            return;
        }
        int childCount = this.transform.childCount;
        float startPosX = (childCount - 1) * spacing / 2 * -1;
        for (int i = 0; i < childCount; ++i)
        {
            transform.GetChild(i).localPosition = new Vector3(startPosX + (spacing * i), 0, .1f * i);
        }
    }

    public void RevealAll()
    {
        int childCount = transform.childCount;
        for (int i = 0; i < childCount; ++i)
        {
            CardDisplay childDisplay = transform.GetChild(i).GetComponent<CardDisplay>();
            if (!childDisplay.IsFaceUp())
            {
                childDisplay.FlipCard();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
