using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public CardAsset[] cardAssets;
    public GameObject faceDownDiscard;
    public GameObject twoPlayerDiscard;
    public List<CardAsset> cards = new List<CardAsset>();
    [SerializeField]
  
    private CardCollection cardCollection = new CardCollection();

    void Awake() {

        cardCollection = GameObject.FindObjectOfType<CardCollection>();

        foreach (var ca in cardCollection.cards) {
            for (int i = 0; i < ca.NumberInDeck; i++) {
                CardAsset card = Object.Instantiate(ca);
                cards.Add(card);
            }
        }

        cards.Shuffle();
    }

    public void DrawACard(GameObject area, bool show) {

        if (cards.Count > 0) {
            new DrawACardCommand(cards[0], area, show).AddToQueue();
            cards.RemoveAt(0);
        } else {
            //No Cards, what happens?
        }
    }
}