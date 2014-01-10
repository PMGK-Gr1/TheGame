using UnityEngine;
using System.Collections;

public class ReturnButtonScript_Options : MonoBehaviour {

    public Controller control;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
             Screen.width * 0.3f,
             Screen.height * 0.05f,
             Screen.height * 0.655f,
               Screen.height * 0.25f);

	}

    void OnMouseUp()
    {
        control.FromOptions();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
