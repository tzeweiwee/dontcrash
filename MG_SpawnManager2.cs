using UnityEngine;
using System.Collections;


public class MG_SpawnManager2 : MonoBehaviour
{
    public GameObject[] obstacles;

    public GameObject leftSP, rightSP;

    int spawnSide = 1; // this will determine which side the obstacle will spawn on (1 = Left, 2 = Right)

    float minDistance = 12f;
    int obstacleNumber = 0;
	int timesOnLeft = 0, timesOnRight = 0;
	int limitOnOneSide = 3;

    public static bool respawnC1, respawnC2, respawnC3, respawnC4, respawnC5;

    void Awake()
    {
        respawnC1 = false;
        respawnC2 = false;
        respawnC3 = false;
        respawnC4 = false;
        respawnC5 = false;

		timesOnLeft = 0;
		timesOnRight = 0;

		if (PlayerPrefs.GetString ("Tutorial") == "no") {
			Debug.Log ("tutorial disabled");
			tutorialScript.showTutorial = false;
		} else {
			Debug.Log ("tutorial enabled");
			tutorialScript.showTutorial = true;
		}

        awakeSpawn();
    }


    void Update()
    {
        if(!tutorialScript.showTutorial)
        {
            for(int i = 0; i < obstacles.Length; i++)
            {
                obstacles[i].SetActive(true);
            }
        }
        // reset the obstacle's position bila dah hit collider for respawn
        if(respawnC1)
        {
            respawnC1 = false;

            spawnSide = Random.Range(1, 3);


			balancingSides ();

            switch(spawnSide)
            {
                case 1:
                    // spawn on left side
					timesOnLeft++;
                    obstacles[0].transform.position = new Vector3(leftSP.transform.position.x, obstacles[0].transform.position.y, leftSP.transform.position.z);
                    break;

                case 2:
                    // spawn on right side
					timesOnRight++;
                    obstacles[0].transform.position = new Vector3(rightSP.transform.position.x, obstacles[0].transform.position.y, rightSP.transform.position.z);
                    break;
            }
            //Debug.Log("RESPAWNED CAR1");
        }

        if (respawnC2)
        {
            respawnC2 = false;

            spawnSide = Random.Range(1, 3);

			balancingSides ();

            switch (spawnSide)
            {
                case 1:
                    // spawn on left side
					timesOnLeft++;
                    obstacles[1].transform.position = new Vector3(leftSP.transform.position.x, obstacles[1].transform.position.y, leftSP.transform.position.z);
                    break;

                case 2:
                    // spawn on right side
					timesOnRight++;
                    obstacles[1].transform.position = new Vector3(rightSP.transform.position.x, obstacles[1].transform.position.y, rightSP.transform.position.z);
                    break;
            }
            //Debug.Log("RESPAWNED CAR2");
        }

        if (respawnC3)
        {
            respawnC3 = false;

            spawnSide = Random.Range(1, 3);

			balancingSides ();

            switch (spawnSide)
            {
                case 1:
                    // spawn on left side
					timesOnLeft++;
                    obstacles[2].transform.position = new Vector3(leftSP.transform.position.x, obstacles[2].transform.position.y, leftSP.transform.position.z);
                    break;

                case 2:
                    // spawn on right side
					timesOnRight++;
                    obstacles[2].transform.position = new Vector3(rightSP.transform.position.x, obstacles[2].transform.position.y, rightSP.transform.position.z);
                    break;
            }
            //Debug.Log("RESPAWNED CAR3");
        }

        if (respawnC4)
        {
            respawnC4 = false;

            spawnSide = Random.Range(1, 3);

			balancingSides ();


            switch (spawnSide)
            {
                case 1:
                    // spawn on left side
					timesOnLeft++;
                    obstacles[3].transform.position = new Vector3(leftSP.transform.position.x, obstacles[3].transform.position.y, leftSP.transform.position.z);
                    break;

                case 2:
                    // spawn on right side
					timesOnRight++;
                    obstacles[3].transform.position = new Vector3(rightSP.transform.position.x, obstacles[3].transform.position.y, rightSP.transform.position.z);
                    break;
            }
            //Debug.Log("RESPAWNED CAR4");
        }

        if (respawnC5)
        {
            respawnC5 = false;

            spawnSide = Random.Range(1, 3);

			balancingSides ();


            switch (spawnSide)
            {
                case 1:
                    // spawn on left side
					timesOnLeft++;
                    obstacles[4].transform.position = new Vector3(leftSP.transform.position.x, obstacles[4].transform.position.y, leftSP.transform.position.z);
                    break;

                case 2:
                    // spawn on right side
					timesOnRight++;
                    obstacles[4].transform.position = new Vector3(rightSP.transform.position.x, obstacles[4].transform.position.y, rightSP.transform.position.z);
                    break;
            }
            //Debug.Log("RESPAWNED CAR5");
        }
    }

    void awakeSpawn()
    {
        // Set the distance of each obstacles
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (obstacles[i].name == "car1" || obstacles[i].name == "car2" || obstacles[i].name == "car3")
            {
                minDistance = Random.Range(15, 20);
                //minDistance = 12f;
            }
            else if (obstacles[i].name == "car4" || obstacles[i].name == "car5")
            {
                minDistance = Random.Range(20, 25);
                //minDistance = 18f;
            }
            // randomize left / right position
            spawnSide = Random.Range(1, 3);

            switch (spawnSide)
            {
                case 1:
                    if (i == 0)
                    {
                        obstacles[i].transform.position = new Vector3(leftSP.transform.position.x, obstacles[i].transform.position.y, obstacles[i].transform.position.z);
                    }
                    else
                    {
                        obstacles[i].transform.position = new Vector3(leftSP.transform.position.x, obstacles[i].transform.position.y, obstacles[(i - 1)].transform.position.z + minDistance);
                    }
                    break;

                case 2:
                    if (i == 0)
                    {
                        obstacles[i].transform.position = new Vector3(rightSP.transform.position.x, obstacles[i].transform.position.y, obstacles[i].transform.position.z);
                    }
                    else
                    {
                        obstacles[i].transform.position = new Vector3(rightSP.transform.position.x, obstacles[i].transform.position.y, obstacles[(i - 1)].transform.position.z + minDistance);
                    }
                    break;
            }

            obstacles[i].SetActive(false);
        }
    }

	void balancingSides()
	{
		if (timesOnLeft >= limitOnOneSide) {
			spawnSide = 2;
			timesOnLeft = 0;
		}

		if (timesOnRight >= limitOnOneSide) {
			spawnSide = 1;
			timesOnRight = 0;
		}
	}
   
}
