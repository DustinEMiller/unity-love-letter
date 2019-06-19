using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public TokenVisual TokenVisuals;
	// TODO: Change to Hand Type
	public GameObject Hand;
    public GameObject Discard;

    public PlayerName PlayerName;

    private int CurrentTokens;
    public int PlayerID;
    public bool AIPlayer = false;

    public static Player[] Players;
    public static int IDCounter = 0;

    private bool m_Eliminated = false;
    private CardManager m_ActiveCard;

    public bool Eliminated
    {
        get { return m_Eliminated; }
        set
        {
            if (m_Eliminated == value) return;
            m_Eliminated = value;
            if (m_Eliminated) {

            }
        }
    }

    public void WonRound() {
        CurrentTokens++;
        TokenVisuals.CurrentTokens = CurrentTokens;
    }

    public delegate void OnEliminatedDelegate(bool eliminated);
    public event OnEliminatedDelegate OnEliminatedChange;

    // Use this for initialization
    void Start () {
        
	}

    void Awake() {
        PlayerID = IDCounter;
        IDCounter++;
    }

    public void OnTurnStart() {

    }

    public void OnTurnEnd() {
        GetComponent<TurnMaker>().StopAllCoroutines();
    }

    public CardManager ActiveCard
    {
        get { return m_ActiveCard; }
        set
        {
            if (m_ActiveCard == value) return;
            m_ActiveCard = value;
        }
    }
}
