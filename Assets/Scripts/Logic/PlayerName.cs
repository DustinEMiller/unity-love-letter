using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{

    public Button PlayerButton;
    public delegate void OnAddButtonListener(bool eliminated);
    private bool activeToggle = false;

    public void ToggleActive() {
        activeToggle = !activeToggle;
        this.gameObject.SetActive(activeToggle);
    }

}