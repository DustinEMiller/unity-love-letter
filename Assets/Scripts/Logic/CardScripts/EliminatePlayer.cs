using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatePlayer : CardScript {
    public override void ActivateEffect(int PlayerID) {
        //new EliminatePlayerCommand(PlayerID);
        new CompareHandsCommand(PlayerID).AddToQueue();
    }
}
