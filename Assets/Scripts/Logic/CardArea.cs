using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardArea : MonoBehaviour {
    public enum AreaType { Hand, Discard };

    private Player player;
    private Transform DeckTransform;
    private List<GameObject> CardsInArea = new List<GameObject>();

    public SameDistanceChildrens slots;
    public AreaType areaType;


    // Use this for initialization
    void Awake () {
        player = this.transform.parent.gameObject.GetComponent<Player>();
        DeckTransform = GameObject.FindObjectOfType<Deck>().transform;
    }

    GameObject CreateACardAtPosition(CardAsset cardAsset, Vector3 position, Vector3 eulerAngles) {
        GameObject card;
        card = GameObject.Instantiate(Settings.Instance.CardPrefab, position, Quaternion.Euler(eulerAngles)) as GameObject;

        CardManager manager = card.GetComponent<CardManager>();
        manager.cardAsset = cardAsset;
        manager.ReadCardFromAsset();

        return card;
    }

    // shift all cards to their new slots
    void PlaceCardsOnNewSlots() {
        foreach (GameObject g in CardsInArea) {
            // tween this card to a new Slot
            g.transform.DOLocalMoveX(slots.Children[CardsInArea.IndexOf(g)].transform.localPosition.x, 0.3f);

            // apply correct sorting order and HandSlot value for later 
            //WhereIsTheCardOrCreature w = g.GetComponent<WhereIsTheCardOrCreature>();
            //w.Slot = CardsInHand.IndexOf(g);
            //w.SetHandSortingOrder();
        }
    }

    // move Slots GameObject according to the number of cards in hand
    void UpdatePlacementOfSlots() {
        float posX;

        if (CardsInArea.Count > 0) {
            posX = (slots.Children[0].transform.localPosition.x - slots.Children[CardsInArea.Count - 1].transform.localPosition.x) / 2f;
        }   
        else {
            posX = 0f;
        }

        // tween Slots GameObject to new position in 0.3 seconds
        //slots.gameObject.transform.DOLocalMoveX(posX, 0.3f);
    }

    // remove a card GameObject from hand
    public void RemoveCard(GameObject card) {
        // remove a card from the list
        CardsInArea.Remove(card);

        // re-calculate the position of the hand
        PlaceCardsOnNewSlots();
        UpdatePlacementOfSlots();
    }

    public void ReceiveACard(CardAsset cardAsset) {
        //Card not a child of discard area? have to set transform of card to setParent card.transform.SetParent(slots.transform);
        GameObject card = CreateACardAtPosition(cardAsset, DeckTransform.position, new Vector3(0f, 0, 0f));

        CardsInArea.Insert(0, card);
        card.transform.SetParent(slots.transform);

        CardManager manager = card.GetComponent<CardManager>();
        manager.SlotParent = slots.transform;
        manager.SlotIndex = CardsInArea.Count - 1;

        PlaceCardsOnNewSlots();
        UpdatePlacementOfSlots();

        Sequence s = DOTween.Sequence();

        s.Append(card.transform.DOLocalMove(slots.Children[0].transform.localPosition, 0));
    }

    public void ReceiveACard(GameObject card) {

        CardManager manager = card.GetComponent<CardManager>();
        manager.RemoveFromList();
        CardsInArea.Add(card);
        manager.SlotParent = slots.transform;
        manager.SlotIndex = CardsInArea.Count - 1;

        //card.transform.parent.gameObject.GetComponent<CardArea>().RemoveCard(card);
        card.transform.SetParent(slots.transform);

        UpdatePlacementOfSlots();
        PlaceCardsOnNewSlots();

        Sequence s = DOTween.Sequence();
        s.Append(card.transform.DOLocalMove(slots.Children[0].transform.localPosition, 0));
    }

    public int GetPlayerId() {
        return player.PlayerID;
    }
}
