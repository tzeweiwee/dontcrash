using UnityEngine;
using System.Collections;

public class MG_RespawnObstacles : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MG_resetObstacles")
        {
            switch (col.transform.parent.gameObject.name)
            {
                case "Colliders_car1":
                    MG_SpawnManager2.respawnC1 = true;
                    //MG_GameManager.MG_Score += 1;
                    break;

                case "Colliders_car2":
                    MG_SpawnManager2.respawnC2 = true;
                    //MG_GameManager.MG_Score += 1;
                    break;

                case "Colliders_car3":
                    MG_SpawnManager2.respawnC3 = true;
                    //MG_GameManager.MG_Score += 1;
                    break;

                case "Colliders_car4":
                    MG_SpawnManager2.respawnC4 = true;
                    //MG_GameManager.MG_Score += 1;
                    break;

                case "Colliders_car5":
                    MG_SpawnManager2.respawnC5 = true;
                    //MG_GameManager.MG_Score += 1;
                    break;
            }
        }
    }
}
