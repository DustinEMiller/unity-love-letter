using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TargetingOptions
{
    NoTarget,
    AllCreatures,
    EnemyCreatures,
    YourCreatures,
    AllCharacters,
    EnemyCharacters,
    YourCharacters
}

public class CardAsset : ScriptableObject
{
    // this object will hold the info about the most general card
    [Header("General info")]
    public int Value;
    public string Name;
    public Sprite CardImage;
    [TextArea(2, 3)]
    public string Description;
    public string ScriptName;
    public int NumberInDeck;
    public bool Visible;
    public TargetingOptions Targets;

    private CardAsset[] _cardAsset;
    public CardAsset(CardAsset[] cArray) {
        _cardAsset = new CardAsset[cArray.Length];

        for (int i = 0; i < cArray.Length; i++) {
            _cardAsset[i] = cArray[i];
        }
    }

}

