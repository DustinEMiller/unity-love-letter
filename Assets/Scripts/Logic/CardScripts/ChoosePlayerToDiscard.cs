using System.Collections.Generic;
using UnityEngine;

public class ChoosePlayerToDiscard : CardScript
{
    public override void ActivateEffect(int PlayerID) {
        new CompareHandsCommand(PlayerID).AddToQueue();
    }
}
