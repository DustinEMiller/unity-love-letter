using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatePlayerCommand : Command {

    private int PlayerID;

    public EliminatePlayerCommand(int playerID) {
        this.PlayerID = playerID;
    }

    public override void StartCommandExecution() {
        Player.Players[this.PlayerID].Eliminated = true;  
    }
}
