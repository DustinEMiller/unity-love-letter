using UnityEngine;
using System.Collections;

public class DrawACardCommand : Command
{
    private CardAsset card;
    private GameObject area;

    public DrawACardCommand(CardAsset card, GameObject area, bool show) {
        this.card = card;
        this.card.Visible = show;
        this.area = area;
    }

    public override void StartCommandExecution() {
        area.GetComponent<CardArea>().ReceiveACard(this.card);
    }
}
