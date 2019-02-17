using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public GameObject CardPrefab;
    public Deck Deck;
    public GameObject TwoPlayerDiscard;
    public GameObject FaceDownDiscard;

    public static Settings Instance;

    // Use this for initialization
    void Awake () {
        Instance = this;	
	}

    public bool CanPlayerDrag(Player player, CardArea area) {
        bool PlayersTurn = (GameManager.Instance.whoseTurn == player);
        Debug.Log(" Area: " + area.areaType + " PlayersTurn: " + PlayersTurn);
        bool IsHand = (area.areaType == CardArea.AreaType.Hand);
        Debug.Log("IsHand: " + IsHand + " Area: " + area.areaType + " PlayersTurn: " + PlayersTurn);
        return PlayersTurn && IsHand;
    }



}
