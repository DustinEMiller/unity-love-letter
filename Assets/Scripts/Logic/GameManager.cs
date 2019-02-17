using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private int firstPlayer;

    private Player _whoseTurn;
    public Player whoseTurn
    {
        get
        {
            return _whoseTurn;
        }

        set
        {
            _whoseTurn = value;
            TurnMaker tm = _whoseTurn.GetComponent<TurnMaker>();
            // player`s method OnTurnStart() will be called in tm.OnTurnStart();
            tm.OnTurnStart();

        }
    }

    // Use this for initialization
    void Start () {
        Player.Players = GameObject.FindObjectsOfType<Player>();
        OnGameStart();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            EndTurn();
        }
    }

    private void Awake() {
        Instance = this;
    }

    public void OnGameStart() {
        // Set up players starting hands, tokens they have and number of tokens to win
        int tokensToWin = 0;

        Settings.Instance.Deck.DrawACard(Settings.Instance.FaceDownDiscard, false);

        switch (Player.Players.Length) {
            case 2:
                tokensToWin = 7;

                int counter = 0;
                while (counter <= 3) {
                    Settings.Instance.Deck.DrawACard(Settings.Instance.TwoPlayerDiscard, true);
                    counter++;
                }
                break;
            case 3:
                tokensToWin = 5;
                break;
            case 4:
                tokensToWin = 4;
                break;
        }

        firstPlayer = 1; // Random.Range(0, Player.Players.Length);

        foreach (Player p in Player.Players) {
            p.TokenVisuals.TokensNeededForWin = tokensToWin;
            p.TokenVisuals.CurrentTokens = 0;
            p.OnEliminatedChange += EliminatePlayerHandler;
            Settings.Instance.Deck.DrawACard(p.Hand, !p.AIPlayer);
        }
        Command.CommandExecutionComplete();

        new StartATurnCommand(Player.Players[firstPlayer]).AddToQueue();

    }

    public void EndTurn() {
        // send all commands in the end of current player`s turn
        whoseTurn.OnTurnEnd();

        //get next player in list
        new StartATurnCommand(NextPlayer()).AddToQueue();
    }

    public Player NextPlayer() {
        if(whoseTurn.PlayerID >= Player.Players.Length -1) {
            return Player.Players[0];
        } else {
            return Player.Players[whoseTurn.PlayerID++];
        }
    }


    private void EliminatePlayerHandler(bool newVal) {
        //do whatever
    }

}
