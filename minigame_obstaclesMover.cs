using UnityEngine;

using System.Collections;

public class minigame_obstaclesMover : MonoBehaviour {

    public GameObject[] obstacles;
    public GameObject[] coins;
    public float moveSpeed;

    public int[] limits;
	int limit;

    int prevLimit, currentLimit, nextLimit;

    void Awake () {
        obstacles = GameObject.FindGameObjectsWithTag("miniGame_Obstacles");
        coins = GameObject.FindGameObjectsWithTag("miniGame_pickup");

        //moveSpeed = Random.Range(-0.009f, -0.011f);
		moveSpeed = -0.01f;    // minigame constant speed
		//moveSpeed = -0.2f;

		limit = 40;

    }
	
	
	void Update () {
        moveMiniGameObstacles();
    }

	void increaseSpeed()
	{
		if (MG_GameManager.totalScore >= limit) {
			if (limit >= 200) {
				// makes 150 to be the max limit
				limit = 200;
				//Debug.Log ("limit 150!");
			} else {
				//Debug.Log ("increased movespeed for MINIGAME!");
				// 5 times increase so max speed is -0.035
				moveSpeed -= 0.005f;
				limit += 40;

				// Show the players that speed is increased
				MG_GameManager.minigameSpeedUp = true;
			}
		}
	}

    void modifySpeed()
    {
        if(MG_GameManager.totalScore <= limits[0]) // less than 40
        {
            moveSpeed = -0.01f;
        }
        else if(MG_GameManager.totalScore > limits[0] && MG_GameManager.totalScore <= limits[1]) // between 40 - 80
        {
            moveSpeed = -0.015f;
        }
        else if (MG_GameManager.totalScore > limits[1] && MG_GameManager.totalScore <= limits[2]) // between 80 - 120
        {
            moveSpeed = -0.02f;
        }
        else if (MG_GameManager.totalScore > limits[2] && MG_GameManager.totalScore <= limits[3]) // between 120 - 160
        {
            moveSpeed = -0.025f;
        }
        else if (MG_GameManager.totalScore > limits[3] && MG_GameManager.totalScore <= limits[4]) // between 160 - 200
        {
            moveSpeed = -0.03f;
        }
        else if(MG_GameManager.totalScore >= limits[4]) // 200 points or more
        {
            moveSpeed = -0.035f;
        }


    }

    void moveMiniGameObstacles()
    {
        //increaseSpeed();
        modifySpeed();

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (!MG_GameManager.gameOver && !MG_GameManager.paused && !tutorialScript.showTutorial)
            {
                Vector3 test = new Vector3(0f, moveSpeed, 0f);
                obstacles[i].transform.localPosition += test;

                // move the coins too
                coins[i].transform.localPosition += test;
            }
        }
    }
}
