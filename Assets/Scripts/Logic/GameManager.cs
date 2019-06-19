using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
                while (counter < 3) {
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
        }

        StartRound();

    }

    private void StartRound() {
        foreach (Player p in Player.Players) {
            Settings.Instance.Deck.DrawACard(p.Hand, !p.AIPlayer);
        }

        Command.CommandExecutionComplete();
        new StartATurnCommand(Player.Players[firstPlayer]).AddToQueue();
    }


    public void EndTurn() {
        // send all commands in the end of current player`s turn
        whoseTurn.OnTurnEnd();

        List<Player> AlivePlayers = new List<Player>();

        foreach (Player p in Player.Players) {
            if(!p.Eliminated) {
                AlivePlayers.Add(p);
            }
        }

        if (AlivePlayers.Count > 1) {
            //get next player in list
            new StartATurnCommand(NextPlayer()).AddToQueue();
        } else {
            AlivePlayers[0].WonRound();
            NewRound();
        }
    }

    public Player NextPlayer() {

        if(whoseTurn.PlayerID >= Player.Players.Length -1 && !Player.Players[0].Eliminated) {
            return Player.Players[0];
        } else {
            for (int i = whoseTurn.PlayerID + 1; i < Player.Players.Length - 1; i++) {
                if(!Player.Players[i].Eliminated) {
                    return Player.Players[i];
                }
            }
        }

        return Player.Players[0];
    }

    private void NewRound() {
        CardManager[] allCards = UnityEngine.Object.FindObjectsOfType<CardManager>();

        foreach (CardManager c in allCards) {
            Destroy(c.gameObject);
        }
        Settings.Instance.Deck.ResetDeck();
        foreach (Player p in Player.Players) {
            CardArea hand = p.Hand.GetComponent<CardArea>();
            hand.ResetArea();
            CardArea discard = p.Discard.GetComponent<CardArea>();
            discard.ResetArea();
        }

        StartRound();
        // also need to remove event listeners from player buttons
        // easiest way may be to add script in button with a 
        // reference to the listener added and then remove instance of reference
        // UnityAction action
        // 

    }

    private void EliminatePlayerHandler(bool newVal) {
        //is this even needed? what to do with it?
    }

}
