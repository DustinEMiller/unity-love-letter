using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompareHandsCommand : Command
{

    private int PlayerID;
    private List<Button> Buttons = new List<Button>();

    public CompareHandsCommand(int playerID) {
        this.PlayerID = playerID;
    }

    public override void StartCommandExecution() {
        foreach (Player p in Player.Players) {
            if (p.PlayerID != this.PlayerID) {
                p.PlayerName.ToggleActive();
                p.PlayerName.PlayerButton.onClick.AddListener(() => { CompareHands(p.PlayerID); });
            }
        }
    }

    public void CompareHands(int PlayerToCompare) {
        int opponentScore = Player.Players[PlayerToCompare].ActiveCard.cardAsset.Value;
        int playerScore = Player.Players[PlayerID].ActiveCard.cardAsset.Value;

        if (opponentScore > playerScore) {
            Debug.Log("You have been eliminated. Your card: " + playerScore + " Their score: " + opponentScore);
            new EliminatePlayerCommand(PlayerID).AddToQueue();
        } else if (opponentScore < playerScore) {
            Debug.Log("They have been eliminated. Your card: " + playerScore + " Their score: " + opponentScore);
            new EliminatePlayerCommand(PlayerToCompare).AddToQueue();
        } else {
            Debug.Log("Tied");
        }

        CommandExecutionComplete();
        foreach (Player p in Player.Players) {
            if (p.PlayerID != this.PlayerID) {
                p.PlayerName.ToggleActive();
                p.PlayerName.PlayerButton.onClick.RemoveListener(() => { CompareHands(p.PlayerID); });
            }
        }
    }

}