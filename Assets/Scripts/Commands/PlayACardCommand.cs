using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayACardCommand : Command {

    private Deck deck;
    private GameObject discardArea;

	public PlayACardCommand(Deck deck, GameObject discardArea) {
        this.deck = deck;
        this.discardArea = discardArea;
    }

    public override void StartCommandExecution() {
       //deck. 
    }
}
