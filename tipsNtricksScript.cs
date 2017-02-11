using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tipsNtricksScript : MonoBehaviour {

    public Text textbox;

    public TextAsset listOfTexts;
    public string[] textLines;


	void Start () {
	    if(listOfTexts != null)
        {
            textLines = listOfTexts.text.Split('\n');
        }
        
        int i = Random.Range(0, textLines.Length);

        textbox.text = textLines[i];
	}
	

}
