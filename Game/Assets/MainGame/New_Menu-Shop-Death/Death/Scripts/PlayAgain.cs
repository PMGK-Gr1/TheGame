using UnityEngine;
using System.Collections;

public class PlayAgain : MonoBehaviour {

	// Use this for initialization
    public Controller control;
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.725f,
            Screen.height * 0.45f,
            Screen.height * 0.4f,
            Screen.height * 0.2f);

	}
	
    void OnMouseUp()
    {
        LoadingScreen.LoadLevel("MainScene");
        control.deathscreen = false;

    }

	// Update is called once per frame
	void Update () {
	
	}
}
