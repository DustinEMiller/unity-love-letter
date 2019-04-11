using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [Header("Transform References")]
    public static Transform DeckTransform;
    public SameDistanceChildrens slots;

    private List<GameObject> CardsInHand = new List<GameObject>();

    private void Start() {
        DeckTransform = GameObject.FindObjectOfType<Deck>().transform;
    }

    public void AddCard(GameObject card) {
        CardsInHand.Insert(0, card);
        card.transform.SetParent(slots.transform);

        //re-calculate the position of the hand
        //PlaceCardsOnNewSlots();
        //UpdatePlacementOfSlots();
    }

    GameObject CreateACardAtPosition(CardAsset cardAsset, Vector3 position, Vector3 eulerAngles) {

        GameObject card;
        card = GameObject.Instantiate(Settings.Instance.CardPrefab, position, Quaternion.Euler(eulerAngles)) as GameObject;

        CardManager manager = card.GetComponent<CardManager>();
        manager.cardAsset = cardAsset;
        manager.ReadCardFromAsset();

        return card;

    }

    public void GivePlayerACard(CardAsset cardAsset, int UniqueId, bool fast = false) {
        GameObject card = CreateACardAtPosition(cardAsset, DeckTransform.position, new Vector3(0f, -179f, 0f));
    }
}
