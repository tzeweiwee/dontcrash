using UnityEngine;
using System.Collections;

public class minigame_respawnScript : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "miniGame_resetObstacles")
        {
            switch (col.transform.parent.gameObject.name)
            {
                case "Colliders_minicar1":
                    minigame_spawnManager.respawnC1 = true;
                    break;

                case "Colliders_minicar2":
                    minigame_spawnManager.respawnC2 = true;
                    break;

                case "Colliders_minicar3":
                    minigame_spawnManager.respawnC3 = true;
                    break;

                case "Colliders_minicar4":
                    minigame_spawnManager.respawnC4 = true;
                    break;
            }
        }

        if(col.tag == "miniGame_pickup")
        {
            // if coin is not picked up before it reaches the bottom, respawn it later
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
				
            //MG_GameManager.gameOver = true;
        }
    }
}
