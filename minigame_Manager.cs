using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class minigame_Manager : MonoBehaviour {

    public Text minigameScoreText, miniGameOverText, multiplierText;
    public static int minigameScore = 0, minigamePenalty = 0, totalScore = 0;

    

	void Awake () {
        minigameScore = 0;
        minigamePenalty = 0;
        totalScore = 0;
        miniGameOverText.gameObject.SetActive(false);
	}
	
	
	void Update () {
        totalScore = minigameScore - minigamePenalty;

        if(totalScore < 0)
        {
            totalScore = 0;
            minigameScore = 0;
            minigamePenalty = 0;
        }

        minigameScoreText.text = totalScore.ToString();

        multiplierText.text = "Multiplier:\n" + minigame_carScript.scoreMultiplier.ToString() + "x";

        if (MG_GameManager.gameOver)
        {
            miniGameOverText.gameObject.SetActive(true);
        }
	}
}
