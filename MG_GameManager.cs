using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MG_GameManager : MonoBehaviour {
    public static bool gameOver = false;
    public static bool paused = false;
    public static int MG_Score = 0, MiniG_Score = 0, penalty = 0,totalScore = 0;
    public static int highScore;
	public static bool gameoverSound;
	public static bool minigameSpeedUp = false, mainGameSpeedUp = false;

	public AudioSource carcrash;
	public AudioSource backgroundmusic;

	float time, hideNow;


    public Text gameOverText, scoreText, notificationText;
    public Button replayButton, backToMenuButton;
    

	void Awake () {
        MG_Score = 0;
        MiniG_Score = minigame_Manager.minigameScore;
        totalScore = 0;
        penalty = 0;



        time = 0f;
		hideNow = 0.08f;

		minigameSpeedUp = false;
		mainGameSpeedUp = false;

        // get high score
        if (PlayerPrefs.HasKey("highscore"))
        {
            highScore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            // if no high score yet, set it to 0
            highScore = 0;
        }

		if (PlayerPrefs.GetString ("Tutorial") == "no") {
			tutorialScript.showTutorial = false;
		}

        gameOverText.enabled = false;
        replayButton.gameObject.SetActive(false);
        backToMenuButton.gameObject.SetActive(false);

		notificationText.text = "";

        gameOverText = gameOverText.GetComponent<Text>();
        scoreText = scoreText.GetComponent<Text>();

        scoreText.text = "Score : 0";

        gameOver = false;
        paused = false;
		gameoverSound = false;
}
	

	void Update () {

        updateScore();

        checkGameOver();

		notifySpeedIncrease ();
	}

	void notifySpeedIncrease()
	{

		if (minigameSpeedUp && mainGameSpeedUp)
		{
			time += Time.deltaTime * 0.1f;
			notificationText.text = "Gotta go faster!!";
			//Debug.Log("Speed up!");

			if(time > hideNow)
			{
				notificationText.text = "";
				minigameSpeedUp = false;
				mainGameSpeedUp = false;
			}
		}
		else
		{
			time = 0f;
		}

	}

    void checkGameOver()
    {
        if (gameOver)
        {

            backgroundmusic.Stop();
            if (gameoverSound)
            {
                carcrash.Play();
                gameoverSound = false;
            }
            if (totalScore > highScore)
            {
                gameOverText.text = "New highscore!\nYour Score: " + totalScore;
                PlayerPrefs.SetInt("highscore", totalScore);
            }
            else
            {
                gameOverText.text = "Game Over!\nYour Score: " + totalScore;
            }

            gameOverText.enabled = true;
			PlayerPrefs.SetString ("Tutorial", "no");
            replayButton.gameObject.SetActive(true);
            backToMenuButton.gameObject.SetActive(true);
        }
    }

    void updateScore()
    {
        //// get the score from the minigame
        //MiniG_Score = minigame_Manager.minigameScore;
        //penalty = minigame_Manager.minigamePenalty;

        ////totalScore = (MG_Score * MiniG_Score) - penalty;

        //totalScore = MiniG_Score - penalty;

        //if(totalScore < 0)
        //{
        //    totalScore = 0;
        //    penalty = 0;
        //    MiniG_Score = 0;
        //}

        // since the top score is the same as the minigame's score, just show the minigame's score
        totalScore = minigame_Manager.totalScore;

        // show the score
        scoreText.text = "Score: " + totalScore.ToString();
    }
}
