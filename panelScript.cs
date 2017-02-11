using UnityEngine;
using System.Collections;

public class panelScript : MonoBehaviour {

	public GameObject instruction;
	public GameObject option;


	public void hideInstruc(){
		instruction.SetActive (false);
		
	}

    public void hideOption()
    {
        option.SetActive(false);
    }


}
