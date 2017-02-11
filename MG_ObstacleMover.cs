using UnityEngine;
using System.Collections;

public class MG_ObstacleMover : MonoBehaviour {
    public GameObject[] obstacles;
    public float moveSpeed;

    public static bool gameOver = false, paused = false;
	int limit = 30;
    // Use this for initialization
    void Awake () {
        gameOver = false;
        paused = false;
		limit = 30;
        obstacles = GameObject.FindGameObjectsWithTag("MG_Obstacles");

        //moveSpeed[0] = Random.Range(-0.3f,-0.5f);     // mid range car
        //moveSpeed[1] = Random.Range(-0.2f, -0.5f);    // slowest car
        //moveSpeed[2] = Random.Range(-0.3f, -0.8f);    // fastest car
        //moveSpeed[3] = Random.Range(-0.1f, -0.3f);    // lorry slower than all the cars
        //moveSpeed[4] = Random.Range(-0.1f, -0.6f);    // bus slightly faster than lorry

        //moveSpeed[0] = Random.Range(-0.3f, -0.5f);
        //moveSpeed = Random.Range(-0.5f, -0.7f);

		moveSpeed = -0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        moveObstacles();
    }

	void increaseSpeed()
	{
		if (MG_GameManager.totalScore >= limit)
		{
			if (limit >= 150)
			{
				//Debug.Log("MG MAX LIMIT");
				// makes 150 to be the max limit
				limit = 150;
			}
			else
			{
				//Debug.Log("increased movespeed for MAIN!");
				// 5 times increase so max speed is -0.075
				moveSpeed -= 0.05f;
				limit += 30;

				// Show the players that speed is increased
				MG_GameManager.mainGameSpeedUp = true;
			}
		}
	}

    void moveObstacles()
    {
		//increaseSpeed();

        for (int i = 0; i < obstacles.Length; i++)
        {
            if (!MG_GameManager.gameOver && !MG_GameManager.paused && !tutorialScript.showTutorial)
            {
                Vector3 test = new Vector3(0f, 0f, moveSpeed);
                obstacles[i].transform.position += test;
            }
        }
    }
}
