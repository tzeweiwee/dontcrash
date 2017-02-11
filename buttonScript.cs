using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class buttonScript : MonoBehaviour {
	public GameObject instruction;
	public GameObject option;

	public void playButton(int num)
    {
        //SceneManager.LoadScene("main_game", LoadSceneMode.Single);

        LoadingScreenManager.LoadScene(num);
    }

    public void optionsButton()
    {
		option.SetActive (true);
    }

    public void creditsButton()
    {
		instruction.SetActive (true);
    }

    public void exitButton()
    {
        Application.Quit();
    }
}
