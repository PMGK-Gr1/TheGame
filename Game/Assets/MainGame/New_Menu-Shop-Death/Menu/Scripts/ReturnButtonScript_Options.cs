using UnityEngine;
using System.Collections;

public class ReturnButtonScript_Options : MonoBehaviour {

    public Controller control;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
             Screen.width * 0.3f,
             Screen.height * 0.1f,
             Screen.width * 0.4f,
               Screen.height * 0.2f);

	}

    void OnMouseUp()
    {
        control.FromOptions();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
