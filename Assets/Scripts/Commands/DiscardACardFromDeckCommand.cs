using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardACardFromDeckCommand : Command {

    private Deck deck;
    private GameObject discardArea;

	public DiscardACardFromDeckCommand(Deck deck, GameObject discardArea) {
        this.deck = deck;
        this.discardArea = discardArea;
    }

    public override void StartCommandExecution() {
       //deck. 
    }
}
