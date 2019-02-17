using System.Collections;
using System.Collections.Generic;

public class StartATurnCommand : Command
{

    private Player p;

    public StartATurnCommand(Player p) {
        this.p = p;
    }

    public override void StartCommandExecution() {
        GameManager.Instance.whoseTurn = p;
        // this command is completed instantly
        CommandExecutionComplete();
    }
}
