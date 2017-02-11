using UnityEngine;
using System.Collections;

public class CarScript : MonoBehaviour {

    public Camera mainCamera;
    public GameObject leftPos, rightPos;
    string headingTowards;
    Vector3 leftPosVec, rightPosVec;


    private RaycastHit hit;

    bool lerpNow = false;
    public float smoothChange = 3f;

	float timer = 0;
    minigame_carScript mncs;

    void Awake () {

        // Initialize the left & right positions
        leftPosVec = new Vector3(leftPos.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rightPosVec = new Vector3(rightPos.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        // make sure the car starts on the right side
        gameObject.transform.position = rightPosVec;

        lerpNow = false;
        smoothChange = 3f;

        headingTowards = "right";

		if (PlayerPrefs.GetString ("Tutorial") == "no") {
			tutorialScript.showTutorial = false;
		}

        
    }
	

	void Update () {

        if(tutorialScript.showTutorial && tutorialScript.testMoveCar)
        {
            tutorialMoveCar();
        }

        if (tutorialScript.showTutorial && tutorialScript.testMoveGame)
        {
            tutorialMoveGame();
        }

        if (!MG_GameManager.gameOver && !tutorialScript.showTutorial)
        {
            touchInput();
        }

     if(lerpNow)
        {
            moveCar();
        }

        gameOverView();
    }

    void tutorialMoveCar()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit) && touch.phase == TouchPhase.Began)
                {
                    if (hit.collider.tag == "moveCar")
                    {
                        getDirection();
                        tutorialScript.testMoveCar = false;
                        tutorialScript.dialogueNum = 2;
                    }
                }
            }
        }
    }

    void tutorialMoveGame()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit) && touch.phase == TouchPhase.Began)
                {
                    if (hit.collider.tag == "moveGame")
                    {
                        minigame_getDirection();
                        tutorialScript.testMoveGame = false;
                        tutorialScript.dialogueNum = 5;
                    }
                }
            }
        }
    }

    void touchInput()
    {

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(ray, out hit) && touch.phase == TouchPhase.Began)
                {
                    if (hit.collider.tag == "moveCar")
                    {
                        getDirection();
                    }

                    if (hit.collider.tag == "moveGame")
                    {
                        minigame_getDirection();
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "roadCol")
        {
            // When this is triggered, tell RoadMover script to remove that road & place at the front

            switch(col.transform.parent.gameObject.name)
            {
                case "Road":
                    RoadMover.road1Repos = true;
                    break;
                case "Road2":
                    RoadMover.road2Repos = true;
                    break;
                case "Road3":
                    RoadMover.road3Repos = true;
                    break;
            }
        }

        if(col.tag == "crashCollider")
        {
            //Debug.Log("Game Over!");
            MG_GameManager.gameOver = true;
            MG_GameManager.gameoverSound = true;
        }

    }

//	void OnCollisionEnter(Collision col)
//	{
//		if(col.collider.tag == "crashCollider")
//		{
//			//Debug.Log("Game Over!");
//			MG_GameManager.gameOver = true;
//			MG_GameManager.gameoverSound = true;
//		}
//	}

    void getDirection()
    {
        lerpNow = true;

        if (headingTowards == "left")
        {
            /* the car is on the right
            * the car is heading towards the left side */

            // reset the direction
            headingTowards = "right";
        }

        else if (headingTowards == "right")
        {
            /* the car is on the left
            * the car is heading towards the right side */

            // reset the direction
            headingTowards = "left";
        }
    }

    void moveCar()
    {
        // This function will move the car to the next lane
        // get the car's current position

        if (headingTowards == "left")
        {

            // move the car to the left
            gameObject.transform.position = Vector3.Lerp(transform.position, leftPosVec, Time.deltaTime * smoothChange);

           
        }

        else if (headingTowards == "right")
        {
           
            // move the car to the right
            gameObject.transform.position = Vector3.Lerp(transform.position, rightPosVec, Time.deltaTime * smoothChange);
        }

        
    }

    void minigame_getDirection()
    {
        minigame_carScript.changeDir = true;

        if (minigame_carScript.gameCarOnLane == "left")
        {
            minigame_carScript.gameCarOnLane = "right";    // changed lanes to the right lane
        }

        else if (minigame_carScript.gameCarOnLane == "right")
        {
            minigame_carScript.gameCarOnLane = "left";     // changed lanes to the left lane
        }
    }

    void gameOverView()
    {
        if (MG_GameManager.gameOver)
        {
			
//			timer += Time.deltaTime * 1f;
//			Debug.Log (timer);

            gameObject.transform.position = new Vector3(-50f, 50f, 0f);

			// crashing stuff to make it look crazy after crashing. 
			// If wanna enable this, remember to disable all obstacles' collider box's isTrigger
			// & uncomment the OnCollisionEnter code block
//			if (timer >= 1f) 
//			{
//				// Stop rotation
//				gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z,1f);
//			}
        }
    }
}
