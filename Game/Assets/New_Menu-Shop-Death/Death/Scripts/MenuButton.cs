using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public Controller control;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.05f,
            Screen.height * 0.60f,
            Screen.width * 0.2f,
            Screen.width * 0.2f);

	}


    void OnMouseUp()
    {
        control.DeathToMenu();
        control.deathscreen = false;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
