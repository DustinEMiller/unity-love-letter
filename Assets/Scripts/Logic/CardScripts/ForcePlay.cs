using System.Collections.Generic;
using UnityEngine;

public class ForcePlay: CardScript
{
    public override void ActivateEffect(int PlayerID) {
        new CompareHandsCommand(PlayerID).AddToQueue();
    }
}
