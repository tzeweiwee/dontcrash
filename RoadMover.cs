using UnityEngine;
using System.Collections;

public class RoadMover : MonoBehaviour {

    public GameObject[] roads;
    public static bool road1Repos, road2Repos, road3Repos;
    public float moveSpeed;
    float roadLength = 30f;
	// Use this for initialization

	void Awake () {
        road1Repos = false;
        road2Repos = false;
        road3Repos = false;
        moveSpeed = -0.25f;
	}
	
	// Update is called once per frame
	void Update () {

        moveRoad();

        repositionRoad();
    }

    void moveRoad()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            if (!MG_GameManager.gameOver && !MG_GameManager.paused)
            {
                Vector3 test = new Vector3(0f, 0f, moveSpeed);
                roads[i].transform.position += test;
            }
        }
    }

    void repositionRoad()
    {
        if (road1Repos)
        {
            // if road1 is triggered, then reposition it to the end of road 2
            //roads[0].transform.position = new Vector3(0f, 0f, (roads[1].transform.position.z + roadLength));  // for 2 roads
            roads[0].transform.position = new Vector3(0f, 0f, (roads[2].transform.position.z + roadLength));    // for 3 roads
            //Debug.Log("Repositioned road 1!");
            road1Repos = false;
        }

        if (road2Repos)
        {
            // if road2 is triggered, then reposition it to the end of road 1
            roads[1].transform.position = new Vector3(0f, 0f, (roads[0].transform.position.z + roadLength));
            //Debug.Log("Repositioned road 2!");
            road2Repos = false;
        }

        if (road3Repos)
        {
            // if road2 is triggered, then reposition it to the end of road 1
            roads[2].transform.position = new Vector3(0f, 0f, (roads[1].transform.position.z + roadLength));
            //Debug.Log("Repositioned road 2!");
            road3Repos = false;
        }
    }
}
