using UnityEngine;
using System.Collections;

public class minigame_spawnManager : MonoBehaviour {
    public GameObject[] obstacles;
    public GameObject[] coins;

    public GameObject leftSP, rightSP;

    int spawnSide = 1; // this will determine which side the obstacle will spawn on (1 = Left, 2 = Right)
    int coinSpawnSide = 1;  // spawnside for the coins

    float minDistance;
    float offset;

    public static bool respawnC1, respawnC2, respawnC3, respawnC4;
    public static bool respawnCoin1, respawnCoin2, respawnCoin3, respawnCoin4;

    void Awake () {
        respawnC1 = false;
        respawnC2 = false;
        respawnC3 = false;
        respawnC4 = false;

        respawnCoin1 = false;
        respawnCoin2 = false;
        respawnCoin3 = false;
        respawnCoin4 = false;

        offset = -0.2f;

        minigame_AwakeSpawn();
        coin_awakeSpawn();
    }


    void Update()
    {
        respawnInGame();
        coin_respawnInGame();
    }

    void minigame_AwakeSpawn()
    {
        // Set the distance of each obstacles
        for (int i = 0; i < obstacles.Length; i++)
        {
           
            minDistance = Random.Range(0.5f, 0.7f);
            
            // randomize left / right position
            spawnSide = Random.Range(1, 3);

            switch (spawnSide)
            {
                case 1: // spawn on the left
                    if (i == 0)
                    {
                        obstacles[i].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[i].transform.localPosition.y, obstacles[i].transform.localPosition.z);
                    }
                    else
                    {
                        obstacles[i].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[(i - 1)].transform.localPosition.y + minDistance, obstacles[i].transform.localPosition.z);
                    }
                    break;

                case 2: // spawn on the right
                    if (i == 0)
                    {
                        obstacles[i].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[i].transform.localPosition.y, obstacles[i].transform.localPosition.z);
                    }
                    else
                    {
                        obstacles[i].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[(i - 1)].transform.localPosition.y + minDistance, obstacles[i].transform.localPosition.z);
                    }
                    break;
            }
        }
    }

    void respawnInGame()
    {
        //minDistance = Random.Range(-0.2f, 0.2f);

        // reset the obstacle's position bila dah hit collider for respawn
        if (respawnC1)
        {
            respawnC1 = false;
            //minigame_coinManager.unhideC1 = true;
            respawnCoin1 = true;

            spawnSide = Random.Range(1, 3);
            switch (spawnSide)
            {
                case 1: // spawn on the left
                    obstacles[0].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, leftSP.transform.localPosition.y /*+ minDistance*/, obstacles[0].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    obstacles[0].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, rightSP.transform.localPosition.y /*+ minDistance*/, obstacles[0].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED MINICAR1");
        }

        if (respawnC2)
        {
            respawnC2 = false;
            //minigame_coinManager.unhideC2 = true;
            respawnCoin2 = true;

            //minDistance = Random.Range(0.5f, 0.7f);

            spawnSide = Random.Range(1, 3);
            switch (spawnSide)
            {
                case 1: // spawn on the left
                    obstacles[1].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, leftSP.transform.localPosition.y /*+ minDistance*/, obstacles[1].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    obstacles[1].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, rightSP.transform.localPosition.y /*+ minDistance*/, obstacles[1].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED MINICAR2");
        }

        if (respawnC3)
        {
            respawnC3 = false;
            //minigame_coinManager.unhideC3 = true;
            respawnCoin3 = true;

            //minDistance = Random.Range(0.5f, 0.7f);

            spawnSide = Random.Range(1, 3);
            switch (spawnSide)
            {
                case 1: // spawn on the left
                    obstacles[2].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, leftSP.transform.localPosition.y /*+ minDistance*/, obstacles[2].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    obstacles[2].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, rightSP.transform.localPosition.y /*+ minDistance*/, obstacles[2].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED MINICAR3");
        }

        if (respawnC4)
        {
            respawnC4 = false;
            //minigame_coinManager.unhideC4 = true;
            respawnCoin4 = true;

            //minDistance = Random.Range(0.5f, 0.7f);

            spawnSide = Random.Range(1, 3);
            switch (spawnSide)
            {
                case 1: // spawn on the left
                    obstacles[3].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, leftSP.transform.localPosition.y /*+ minDistance*/, obstacles[3].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    obstacles[3].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, rightSP.transform.localPosition.y /*+ minDistance*/, obstacles[3].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED MINICAR4");
        }
    }

    void coin_awakeSpawn()
    {
        for(int i = 0; i < coins.Length; i++)
        {
            coinSpawnSide = Random.Range(1, 3);

            switch(coinSpawnSide)
            {
                case 1:
                    coins[i].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[i].transform.localPosition.y + offset, obstacles[i].transform.localPosition.z);
                    break;

                case 2:
                    coins[i].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[i].transform.localPosition.y + offset, obstacles[i].transform.localPosition.z);
                    break;
            }
        }
    }

    void coin_respawnInGame()
    {
        if (respawnCoin1)
        {
            respawnCoin1 = false;
            
            spawnSide = Random.Range(1, 3);

            // randomize offset a little
            offset = Random.Range(-0.2f,-0.3f);

            switch (spawnSide)
            {
                case 1: // spawn on the left
                    coins[0].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[0].transform.localPosition.y + offset, obstacles[0].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    coins[0].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[0].transform.localPosition.y + offset, obstacles[0].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED COIN1");
        }

        if (respawnCoin2)
        {
            respawnCoin2 = false;


            spawnSide = Random.Range(1, 3);

            // randomize offset a little
            offset = Random.Range(-0.2f, -0.3f);

            switch (spawnSide)
            {
                case 1: // spawn on the left
                    coins[1].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[1].transform.localPosition.y + offset, obstacles[1].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    coins[1].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[1].transform.localPosition.y + offset, obstacles[1].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED COIN2");
        }

        if (respawnCoin3)
        {
            respawnCoin3 = false;


            spawnSide = Random.Range(1, 3);

            // randomize offset a little
            offset = Random.Range(-0.2f, -0.3f);

            switch (spawnSide)
            {
                case 1: // spawn on the left
                    coins[2].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[2].transform.localPosition.y + offset, obstacles[2].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    coins[2].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[2].transform.localPosition.y + offset, obstacles[2].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED COIN3");
        }

        if (respawnCoin4)
        {
            respawnCoin4 = false;


            spawnSide = Random.Range(1, 3);

            // randomize offset a little
            offset = Random.Range(-0.2f, -0.3f);

            switch (spawnSide)
            {
                case 1: // spawn on the left
                    coins[3].transform.localPosition = new Vector3(leftSP.transform.localPosition.x, obstacles[3].transform.localPosition.y + offset, obstacles[3].transform.localPosition.z);
                    break;

                case 2: // spawn on the right
                    coins[3].transform.localPosition = new Vector3(rightSP.transform.localPosition.x, obstacles[3].transform.localPosition.y + offset, obstacles[3].transform.localPosition.z);
                    break;
            }
            //Debug.Log("RESPAWNED COIN4");
        }
    }
}
