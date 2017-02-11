using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MG_SpawnManager : MonoBehaviour {
    public GameObject[] obstacles;

    public GameObject leftSP, rightSP;

    int spawnSide = 1; // this will determine which side the obstacle will spawn on (1 = Left, 2 = Right)
    float spawnTimer = 0.5f; // this is the spawn cooldown. A new obstacle will spawn every spawnTimer seconds
    public float ticker = 0f; // acts as a clock

    public int obstaclesOnRoad = 0;    // current number of obstacles on the road
    public int maxObstOnRoad = 4;   // maximum number of obstacles to spawn on the road

    float minDistance = 12f;
    int obstacleNumber = 0;


    private int totalCars = 4;
    public List<int> obstaclesList;
    public List<int> spawnedObstacles;

    void Awake()
    {


        spawnSide = 1;
        spawnTimer = 0.5f;
        ticker = 0f;

        obstaclesOnRoad = 0;

        obstacles = GameObject.FindGameObjectsWithTag("MG_Obstacles");

        // Set the distance of each obstacles
        for (int i = 1; i < obstacles.Length; i++)
        {
            if (obstacles[i].name == "car1" || obstacles[i].name == "car2" || obstacles[i].name == "car3")
            {
                minDistance = 12f;
            }
            else if (obstacles[i].name == "car4" || obstacles[i].name == "car5")
            {
                minDistance = 18f;
            }
            // randomize left / right position
            //if(Random.Range(1, 3) == 1)
            //{
                
            //    obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y, obstacles[(i - 1)].transform.position.z + minDistance);
            //}
            obstacles[i].transform.position = new Vector3(obstacles[i].transform.position.x, obstacles[i].transform.position.y, obstacles[(i - 1)].transform.position.z + minDistance);


            // Unique Random List Numbers
            totalCars = obstacles.Length;
            obstaclesList = new List<int>();
            spawnedObstacles = new List<int>();

            // Continue here tomorrow.
            // Camana nak suruh dia decide who to spawn using random unique numbers
            // Bila dah siap tu, make sure that obstacles respawn back to their original place, remove obstaclesOnRoad by 1, and add back its number in the obstaclesList

            //GenerateRandomList();
            //chooseRandomCar();
        }
    }


    void Update() {
        ticker += Time.deltaTime * 0.1f;

        if (ticker >= spawnTimer && obstaclesOnRoad < maxObstOnRoad)
        {
            // choose an obstacle to spawn. Must make sure that the obstacle is not already spawned!
            int randomNum = obstaclesList[Random.Range(0, obstaclesList.Count)];
            //obstaclesList.Remove(randomNum);    // this works, but needs some tweaking. Make sure this process is infinite.

            Debug.Log("Spawned Car " + randomNum);

            // randomize which side the obstacle will spawn on
            spawnSide = Random.Range(1, 3);

            switch (spawnSide)
            {
                case 1:
                    // spawn on left side
                    obstacles[randomNum].transform.position = new Vector3(leftSP.transform.position.x, obstacles[randomNum].transform.position.y, leftSP.transform.position.z);
                    break;
                case 2:
                    // spawn on right side
                    obstacles[randomNum].transform.position = new Vector3(rightSP.transform.position.x, obstacles[randomNum].transform.position.y, rightSP.transform.position.z);
                    break;
            }

            // increase carsOnRoad
            obstaclesOnRoad += 1;

            ticker = 0f;
        }
      

    }

    public void GenerateRandomList()
    {
        for (int i = 0; i < totalCars; i++)
        {
            obstaclesList.Add(i);
        }        
    }

    void chooseRandomCar()
    {
        for (int i = 0; i < totalCars; i++)
        {
            int ranNum = obstaclesList[Random.Range(0, obstaclesList.Count)];   // chooses a unique number from the list of obstacles

            spawnedObstacles.Add(ranNum);   // adds the obstacle into this list (list of all obstacles on the road currently)
            obstaclesList.Remove(ranNum);   // removes it from list of possible obstacles to spawn. (Add them later when triggerBox respawn)

            Debug.Log(ranNum);
        }

    }
}
