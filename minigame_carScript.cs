using UnityEngine;
using System.Collections;

public class minigame_carScript : MonoBehaviour
{
    public static minigame_carScript _minigame_CS;

    public static bool changeDir = false;
    public static bool brokeCoinStreak = false;
    public static string gameCarOnLane = "right";
    
    public GameObject leftPos, rightPos;

	public AudioSource coin;

    Vector3 leftPosVec, rightPosVec;
    float curve = 5f;

    int penaltyMultiplier = 0;
    int coinStreak = 0;
    public static int scoreMultiplier = 1;

    void Awake()
    {
        if (_minigame_CS != null)
        {
            _minigame_CS = this;
        }

        changeDir = false;
        brokeCoinStreak = false;
        gameCarOnLane = "right";

        leftPosVec = new Vector3(leftPos.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
        rightPosVec = new Vector3(rightPos.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);

        penaltyMultiplier = 0;
        coinStreak = 0;
        scoreMultiplier = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(changeDir)
        {
            changeLane();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "miniGame_roadCol")
        {
            // When this is triggered, tell RoadMover script to remove that road & place at the front

            switch (col.transform.parent.gameObject.name)
            {
                case "Road1":
                    minigame_roadMover.miniroad1repos = true;
                    break;
                case "Road2":
                    minigame_roadMover.miniroad2repos = true;
                    break;
                case "Road3":
                    minigame_roadMover.miniroad3repos = true;
                    break;
            }
        }

        // check trigger against crash collider in obstacles
        if(col.tag == "miniGame_crashCollider")
        {
            /*****************************
             *  THIS IS EZ MODE FOR NUBZ *
             *****************************/
            // If crash with other car, minus 2 points
            penaltyMultiplier++;

            // break coin streak if crashed to another car
            if (coinStreak > 0)
            {
                brokeCoinStreak = true;
                coinStreak = 0; // reset coinStreak to 0
            }


            // but if crashed with 3 cars in a row, multiply penalty by 4
            if (penaltyMultiplier == 3)
            {
                minigame_Manager.minigamePenalty += (2 * (penaltyMultiplier + 1));    // kalau langgar 3 cars consecutively, total penalty = 12 points
                                                                            // as opposed to kalau takde multiplier for penalty, langgar 3 kereta penalty = 6 points je total.
                                                                            // so 3 collisions in a row = 2x penalty for colliding 3 separate times
                penaltyMultiplier = 0;  // reset to 0
            }
            else
            {
                minigame_Manager.minigamePenalty += 2;
            }
                // play blinking animation

                /*****************************
                 * ^ THIS IS EZ MODE FOR NUBZ *
                 *****************************/
            
            // maybe do game over terus if tak collect coin for EXTREME game mode / difficulty

            //Debug.Log("Game Over!");
            //MG_GameManager.gameOver = true;
        }

        // check if triggered against coins
        if (col.tag == "miniGame_pickup")
        {
            // check if was crashing with cars consecutively
            if(penaltyMultiplier > 0 && penaltyMultiplier < 3)
            {
                // kalau before pickup coin ni dia tengah on crashing streak,
                // reset that streak
                penaltyMultiplier = 0;
            }

            // add to streak if did not crash into a car yet since last pickup
            if (!brokeCoinStreak)
            {
                coinStreak++;
            }
            else
            {
                // reset brokeCoinStreak to false
                brokeCoinStreak = false;
            }

            // actually add the score now
            if (coinStreak < 5)
            {
                scoreMultiplier = 1;
                //Debug.Log("1x!");
            }

            else if (coinStreak >= 5 && coinStreak < 9)
            {
                // after first 4 coins consecutively, multiply score by 2
                scoreMultiplier = 2;
                //Debug.Log("2x!");
            }

            else if (coinStreak >= 9 && coinStreak < 13)
            {
                scoreMultiplier = 3;
                //Debug.Log("3x!");
            }

            else if (coinStreak >= 13)
            {
                scoreMultiplier = 4;
                //Debug.Log("4x!");
            }

            
            minigame_Manager.minigameScore += 1 * scoreMultiplier;
			coin.Play ();

            // hides the coin
            switch(col.gameObject.name)
            {
                case "Coin1":
                    minigame_coinManager.pickedUpC1 = true;
                    break;

                case "Coin2":
                    minigame_coinManager.pickedUpC2 = true;
                    break;

                case "Coin3":
                    minigame_coinManager.pickedUpC3 = true;
                    break;

                case "Coin4":
                    minigame_coinManager.pickedUpC4 = true;
                    break;
            }

            
        }
    }

    void changeLane()
    {
        if(gameCarOnLane == "left")
        {
            gameObject.transform.localPosition = Vector3.Lerp(transform.localPosition, rightPosVec, Time.deltaTime * curve);
            //gameObject.transform.localPosition = rightPosVec;
        }

        else if(gameCarOnLane == "right")
        {
            gameObject.transform.localPosition = Vector3.Lerp(transform.localPosition, leftPosVec, Time.deltaTime * curve);
            //gameObject.transform.localPosition = leftPosVec;

        }

        //changeDir = false;
    }
}
