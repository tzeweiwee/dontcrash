using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource music;
	public AudioSource sound;
	public AudioSource coin;
	// Use this for initialization
	void Start () {
		string musicEnable = PlayerPrefs.GetString("Music");
		string soundEnable = PlayerPrefs.GetString("Sound");
		if (musicEnable == "no") {
			music.mute = true;
		} 

		if (soundEnable == "no") {
			sound.mute = true;
			coin.mute = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
