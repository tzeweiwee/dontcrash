using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorialScript : MonoBehaviour
{

    public GameObject smartphone, phonePos, dialogueBox;
    public Text scoreText, minigameScoreText, dialogue, minigameMultiplierText;
    public GameObject boundingBoxLeft, boundingBoxRight;

    public static int dialogueNum = 0;
    string[] texts;

    public static bool showTutorial, testMoveCar = false, testMoveGame = false, getInput = true;
    bool animatePhone = false;
    int counter = 0;
    
    void Awake()
    {
        texts = new string[10];

        texts[0] = "Tap on the left side of the screen to change your car's lane.";
        texts[1] = "\"Let's try tapping on the left side to change lanes. Must... Not.. CRASH!\"";
        texts[2] = "\"Phew... That was easy... but why didn't the steering wheel move? This must be a new kind of car that is controlled by your mind.\"";
        texts[3] = "\"Anyway, driving alone is so boring! Let's play that awesome game everyone's been crazy about! I heard the developers are really handsome.\"";
        texts[4] = "\"So I just have to tap on the right side to change the lanes for the game. Let's try that.\"";
        texts[5] = "\"They said that I only have to collect the coins and avoid the other cars.. How hard can that be?\"";
        texts[6] = "\"Pick up coins and I'll get points. Hit another car will reduce my points. Oh? There's also multipliers in this game.\"";
        texts[7] = "\"Pick up coins consecutively without crashing & my score will be multiplied! The higher my score, the faster the car will move.\"";
		texts [8] = "\"If I crash consecutively onto obstacle cars, the penalty will be multiplied too? Whew. Better avoid them all!\"";
		texts [9] = "\"The text on the top left shows my current score multiplier. Alright, let's start!\"";

        dialogueNum = 0;
        dialogue.text = texts[0];
        dialogue.fontStyle = FontStyle.Italic;

        testMoveCar = false;
        testMoveGame = false;
        getInput = true;

        scoreText.gameObject.SetActive(false);
        minigameScoreText.gameObject.SetActive(false);
        minigameMultiplierText.gameObject.SetActive(false);

        boundingBoxLeft.SetActive(false);
        boundingBoxRight.SetActive(false);

		if (PlayerPrefs.GetString ("Tutorial") == "no") {
			showTutorial = false;
			dialogueBox.SetActive (false);
			minigameMultiplierText.gameObject.SetActive(true);
			scoreText.gameObject.SetActive(true);
			minigameScoreText.gameObject.SetActive(true);
			animatePhone = true;
			slidePhoneIn ();
		}
    }


    void Update()
    {
        if(dialogueNum > 0)
        {
            dialogue.fontStyle = FontStyle.Normal;
        }


        if (showTutorial)
        {
            tutorial();
        }
    }

    void tutorial()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (dialogueNum == 1)
                    {
                        testMoveCar = true;
                        getInput = false;
                    }

                    else if (dialogueNum == 4)
                    {
                        testMoveGame = true;
                    }
                    else
                    {
                        if (dialogueNum < 9)
                        {
                            if (dialogueNum == 2 && counter == 0)
                            {
                                // do nothing
                                counter++;
                            }
                            else if (dialogueNum == 5 && counter == 1)
                            {
                                // do nothing
                                counter++;
                            }
                            else
                            {
                                dialogueNum++;
                            }
                        }
                        else
                        {
                            // END OF THE TUTORIAL

                            showTutorial = false;
                            dialogueBox.gameObject.SetActive(false);

                            scoreText.gameObject.SetActive(true);
                            minigameScoreText.gameObject.SetActive(true);
//                            minigameMultiplierText.gameObject.SetActive(true);
                        }
                    }
                    dialogue.text = texts[dialogueNum];


                }
            }
        }

        // show bounding boxes
        // left bounding boxes
        if(dialogueNum == 1)
        {
            boundingBoxLeft.SetActive(true);
        }
        else
        {
            boundingBoxLeft.SetActive(false);
        }

        // right bounding box
        if(dialogueNum == 5)
        {
            boundingBoxRight.SetActive(true);
        }
        else
        {
            boundingBoxRight.SetActive(false);
        }

        if (dialogueNum == 4)
        {
            animatePhone = true;
        }

        if (animatePhone)
        {
            slidePhoneIn();
        }

		if (dialogueNum == 8) {
			minigameMultiplierText.gameObject.SetActive(true);
		}
    }

    void slidePhoneIn()
    {
        smartphone.transform.localPosition = Vector3.Lerp(smartphone.transform.localPosition, phonePos.transform.localPosition, Time.deltaTime * 5f);
    }
}

