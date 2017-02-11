using UnityEngine;
using System.Collections;

public class audioManager : MonoBehaviour {

	public AudioSource music;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("Music", "yes");
		PlayerPrefs.SetString ("Sound", "yes");
	}
	
	// Update is called once per frame
	void Update () {
		string musicEnable = PlayerPrefs.GetString ("Music");
		if (musicEnable == "no") {
			music.mute = true;
		} else {
			music.mute = false;
		}
	}
}
