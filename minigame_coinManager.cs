using UnityEngine;
using System.Collections;

public class minigame_coinManager : MonoBehaviour {

    // this script handles hiding and showing the coins 

    public static bool pickedUpC1, pickedUpC2, pickedUpC3, pickedUpC4;
    public static bool unhideC1, unhideC2, unhideC3, unhideC4;
    public GameObject[] coins;

    void Awake () {
        pickedUpC1 = false;
        pickedUpC2 = false;
        pickedUpC3 = false;
        pickedUpC4 = false;

        unhideC1 = false;
        unhideC2 = false;
        unhideC3 = false;
        unhideC4 = false;
    }
	
	
	void Update () {
        hideCoins();

        //showCoins();
	}

    void hideCoins()
    {
        if(pickedUpC1)
        {
            //coins[0].SetActive(false);
            coins[0].transform.localPosition = new Vector3(-50f, 20f, 0.2f);
            pickedUpC1 = false;
        }

        if (pickedUpC2)
        {
            //coins[1].SetActive(false);
            coins[1].transform.localPosition = new Vector3(-50f, 20f, 0.2f);
            pickedUpC2 = false;
        }

        if (pickedUpC3)
        {
            //coins[2].SetActive(false);
            coins[2].transform.localPosition = new Vector3(-50f, 20f, 0.2f);
            pickedUpC3 = false;
        }

        if (pickedUpC4)
        {
            //coins[3].SetActive(false);
            coins[3].transform.localPosition = new Vector3(-50f, 20f, 0.2f);
            pickedUpC4 = false;
        }
    }

    void showCoins()
    {
        if(unhideC1)
        {
            coins[0].SetActive(true);
            unhideC1 = false;
        }

        if (unhideC2)
        {
            coins[1].SetActive(true);
            unhideC2 = false;
        }

        if (unhideC3)
        {
            coins[2].SetActive(true);
            unhideC3 = false;
        }

        if (unhideC4)
        {
            coins[3].SetActive(true);
            unhideC4 = false;
        }
    }
}
