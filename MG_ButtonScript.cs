using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MG_ButtonScript : MonoBehaviour {

    public void replay()
    {
        SceneManager.LoadScene("main_game", LoadSceneMode.Single);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("main_menu", LoadSceneMode.Single);
    }
}
