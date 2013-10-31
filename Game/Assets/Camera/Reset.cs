using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        Rect rectButton = new Rect();
        rectButton.x = Screen.width * 0.85f;
        rectButton.y = Screen.height * 0.85f;
        rectButton.width = Screen.width * 0.1f;
        rectButton.height = Screen.height * 0.1f;        
        if(GUI.Button(rectButton, "Reset")){
            Application.LoadLevel(0);
        }

    }

}
