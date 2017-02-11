using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class optionScript : MonoBehaviour {

	public Toggle toggle1; //music
	public Toggle toggle2; //sound
	public Toggle toggle3; //tutorial

	void Start(){
		if (PlayerPrefs.GetString ("Tutorial") == "no") {

			Debug.Log ("Tutorial disabled");
	
		}
	}
	// Update is called once per frame
	void Update () {
		if (!toggle1.isOn) {
			PlayerPrefs.SetString ("Music", "no");
		} else {
			PlayerPrefs.SetString ("Music", "yes");
		}
		if (!toggle2.isOn) {
			PlayerPrefs.SetString ("Sound", "no");
		} else {
			PlayerPrefs.SetString ("Sound", "yes");
		}
		if (!toggle3.isOn) {
			PlayerPrefs.SetString ("Tutorial", "no");
		} else {
			PlayerPrefs.SetString ("Tutorial", "yes");
		}
	}
}
