using UnityEngine;
using System.Collections;

public class minigame_tutorial : MonoBehaviour {

    public GameObject smartphone, phonePos;
    public static bool showTutorial = true;
    bool animatePhone = false;

	void Awake () {
        showTutorial = true;
	}
	
	
	void Update () {
	
        if(showTutorial)
        {
            if(Input.GetKeyDown(KeyCode.A)) // change this to a touch if dialogbox is on
            {
                animatePhone = true;
            }

            if(animatePhone)
            {
                smartphone.transform.localPosition = Vector3.Lerp(smartphone.transform.localPosition, phonePos.transform.localPosition, Time.deltaTime * 5f);
            }
        }
	}
}
