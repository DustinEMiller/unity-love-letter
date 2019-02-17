using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// place first and last elements in children array manually
// others will be placed automatically with equal distances between first and last elements
public class CardCollection : MonoBehaviour
{

    public List<CardAsset> cards = new List<CardAsset>();

    void Awake() {
        cards.Shuffle();
    }
}