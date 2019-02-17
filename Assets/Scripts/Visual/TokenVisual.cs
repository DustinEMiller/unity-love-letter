using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TokenVisual : MonoBehaviour {

    public Image[] Tokens;
    public Text ProgressText;

    private int tokensNeededForWin;
    public int TokensNeededForWin
    {
        get { return tokensNeededForWin; }

        set
        {
            if (value > Tokens.Length)
                tokensNeededForWin = Tokens.Length;
            else if (value < 0)
                tokensNeededForWin = 0;
            else
                tokensNeededForWin = value;

            for (int i = 0; i < Tokens.Length; i++) {
                if (i < tokensNeededForWin) {
                    if (Tokens[i].color == Color.clear)
                        Tokens[i].color = Color.gray;
                }
                else
                    Tokens[i].color = Color.clear;
            }

            // update the text
            tokensNeededForWin = value;
            ProgressText.text = string.Format("{0}/{1}", currentTokens.ToString(), tokensNeededForWin.ToString());
        }
    }

    private int currentTokens;
    public int CurrentTokens
    {
        get { return currentTokens; }

        set
        {
            if (value > tokensNeededForWin)
                currentTokens = tokensNeededForWin;
            else if (value < 0)
                currentTokens = 0;
            else
                currentTokens = value;

            for (int i = 0; i < tokensNeededForWin; i++) {
                if (i < currentTokens)
                    Tokens[i].color = Color.white;
                else
                    Tokens[i].color = Color.gray;
            }

            // update the text
            ProgressText.text = string.Format("{0}/{1}", currentTokens.ToString(), tokensNeededForWin.ToString());

        }
    }
	
	// Update is called once per frame
	void Update () {
        //TokensNeededForWin = 5;
        //CurrentTokens = 3;
    }
}
