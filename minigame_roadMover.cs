using UnityEngine;
using System.Collections;

public class minigame_roadMover : MonoBehaviour {
    public GameObject[] roads;
    public static bool miniroad1repos, miniroad2repos, miniroad3repos;
    float movespeed;
    float roadlength = 0.94f;
    Vector3 test;

    // Use this for initialization
    void Awake () {

        roadlength = 0.94f;

        miniroad1repos = false;
        miniroad2repos = false;
        miniroad3repos = false;

        
        movespeed = -0.015f;
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
                Vector3 test = new Vector3(0f, movespeed, 0f);
                roads[i].transform.localPosition += test;
            }
        }
    }

    void repositionRoad()
    {
        if (miniroad1repos)
        {
            // if road1 is triggered, then reposition it to the end of road 2
            //roads[0].transform.position = new Vector3(0f, 0f, (roads[1].transform.position.z + roadLength));  // for 2 roads
            roads[0].transform.localPosition = new Vector3(0.026f, (roads[2].transform.localPosition.y + roadlength), 0.1f);    // for 3 roads
            //Debug.Log("Repositioned road 1! @ " + roads[0].transform.localPosition);
            miniroad1repos = false;
        }

        if (miniroad2repos)
        {
            // if road2 is triggered, then reposition it to the end of road 1
            roads[1].transform.localPosition = new Vector3(0.026f, (roads[0].transform.localPosition.y + roadlength), 0.1f);
            //Debug.Log("Repositioned road 2! @ " + roads[1].transform.position);
            miniroad2repos = false;
        }

        if (miniroad3repos)
        {
            // if road3 is triggered, then reposition it to the end of road 1
            roads[2].transform.localPosition = new Vector3(0.026f, (roads[1].transform.localPosition.y + roadlength), 0.1f);
            //Debug.Log("Repositioned road 3! @ " + roads[2].transform.position);
            miniroad3repos = false;
        }
    }
}
