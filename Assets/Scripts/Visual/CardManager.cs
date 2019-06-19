using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {

    public CardAsset cardAsset;
    public RectTransform CardFront;
    public RectTransform CardBack;

    private bool visible;
    [Header("Text Component References")]
    public Text Description;
    public Text Name;
    public Text Value;
    [Header("Image References")]
    public Image CardGraphic;
    public Image Background;

    public int Id;
    public int AreaIndex;
    public int SlotIndex;
    public CardScript Script;

    void Awake() {
        if (cardAsset != null) {
            ReadCardFromAsset();
        }


    }

    //TODO: Make use cases
    private bool canBePlayedNow = true;
    public bool CanBePlayedNow
    {
        get
        {
            return canBePlayedNow;
        }

        set
        {
            canBePlayedNow = value;
        }
    }

    public void ReadCardFromAsset() {
        Name.text = cardAsset.Name;
        Description.text = cardAsset.Description;
        CardGraphic.sprite = cardAsset.CardImage;
        Visible = cardAsset.Visible;
        Value.text = cardAsset.Value.ToString();
        Script = System.Activator.CreateInstance(System.Type.GetType(cardAsset.ScriptName)) as CardScript;
}

    public bool Visible
    {
        get { return visible; }
        set
        {
            visible = value;
            if (visible) {
                CardFront.gameObject.SetActive(true);
                CardBack.gameObject.SetActive(false);
            }
            else {
                CardFront.gameObject.SetActive(false);
                CardBack.gameObject.SetActive(true);
            }
        }
    }

    private CardArea slotParent;
    public CardArea SlotParent
    {
        get
        {
            return slotParent;
        }

        set
        {
            slotParent = value;
        }
    }

    public void RemoveFromList() {
        slotParent.RemoveCard(gameObject);
    }
}


