using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CardStack))]


public class CardStackView : MonoBehaviour {


    CardStack deck;
    Dictionary<int, GameObject> fetchedCards;
    int lastCount;
    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;
    public bool faceUp = false;
    public bool reverseLayerOrder = false;
  

    void Start()
    {

        fetchedCards = new Dictionary<int, GameObject>();
        deck = GetComponent<CardStack>();
        ShowCards();
        lastCount = deck.CardCount;
        deck.CardRemoved += deck_CardRemoved;

    }

    void deck_CardRemoved(object sender, CardRemovedEventArgs e)
    {
        if (fetchedCards.ContainsKey(e.CardIndex))
        {
            Destroy(fetchedCards[e.CardIndex]);
            fetchedCards.Remove(e.CardIndex);
        }
    }
    void Update()
    {
        if (lastCount != deck.CardCount)
        {
            lastCount = deck.CardCount;
            ShowCards();
        }
    }

    void ShowCards()
    {
        int cardCount = 0;

      if (deck.HasCards)
       {
            foreach (int i in deck.GetCards())
            {
                float co = cardOffset * cardCount; 
                Vector3 temp = start + new Vector3(co, 0f);
                AddCard(temp, i, cardCount);
                cardCount++;
            }
        }
    }
    void AddCard(Vector3 position, int cardIndex, int positionalIndex)
    {
        if (fetchedCards.ContainsKey(cardIndex))
        {
            return;
        }

        GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
        cardCopy.name = ("Card" + GameObject.Find("StartGame").GetComponent<StartGameDebug>().numerc++);
     
       cardCopy.transform.position = position;

        CardModel cardModel = cardCopy.GetComponent<CardModel>();
        cardModel.cardIndex = cardIndex;
        cardModel.ToggleFace(faceUp);

        if (GameObject.Find("StartGame").GetComponent<StartGameDebug>().parentenemy)
        {
            cardModel.transform.SetParent(GameObject.Find("EnemyPanel").transform);
            
        }

        if (GameObject.Find("StartGame").GetComponent<StartGameDebug>().parentplayer)
        {
            cardModel.transform.SetParent(GameObject.Find("PlayerPanel").transform);
        }
        if (GameObject.Find("StartGame").GetComponent<StartGameDebug>().parentplayer != true && GameObject.Find("StartGame").GetComponent<StartGameDebug>().parentenemy != true)
        {
            cardModel.transform.SetParent(this.transform.parent);
        }
        SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
        if (reverseLayerOrder)
        {
            spriteRenderer.sortingOrder = 35 - positionalIndex;
        }
        else
        {
            spriteRenderer.sortingOrder = positionalIndex;
        }

        fetchedCards.Add(cardIndex, cardCopy);
    }
}