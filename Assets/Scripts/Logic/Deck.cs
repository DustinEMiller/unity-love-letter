using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public CardAsset[] cardAssets;
    public GameObject faceDownDiscard;
    public GameObject twoPlayerDiscard;
    [SerializeField]
    private CardCollection cardCollection = new CardCollection();
    [SerializeField]
    private List<CardAsset> cards;


    void Awake() {

        cardCollection = GameObject.FindObjectOfType<CardCollection>();
        ResetDeck();
    }

    public void DrawACard(GameObject area, bool show) {

        if (cards.Count > 0) {
            new DrawACardCommand(cards[0], area, show).AddToQueue();
            cards.RemoveAt(0);
        } else {
            //No Cards, what happens?
        }
    }

    public void ResetDeck() {
        cards = new List<CardAsset>();
        IDFactory.ResetIDs();

        foreach (var ca in cardCollection.cards) {
            for (int i = 0; i < ca.NumberInDeck; i++) {
                CardAsset card = Object.Instantiate(ca);
                card.Id = IDFactory.GetUniqueID();
                cards.Add(card);
            }
        }

        cards.Shuffle();
    }
}