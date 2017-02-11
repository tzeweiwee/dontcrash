using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class highScoreScript : MonoBehaviour {

    public Text highscoreText;
    int highscore;

	void Awake () {
        if (PlayerPrefs.HasKey("highscore"))
        {
            highscore = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            highscore = 0;
        }

        highscoreText.text = "High Score: " + highscore.ToString();

		PlayerPrefs.SetString ("Music", "yes");
		PlayerPrefs.SetString ("Sound", "yes");
		PlayerPrefs.SetString ("Tutorial", "yes");
	}
	
}
