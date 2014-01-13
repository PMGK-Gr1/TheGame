using UnityEngine;
using System.Collections;

public class FacebookButtonScript : MonoBehaviour {
    public Controller control;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.73f,
            Screen.height * 0.1f,
            Screen.width * 0.1f,
            Screen.width * 0.1f);

	}
	
	// Update is called once per frame
    void OnMouseUp()
    {
        if (!control.optionsOn) Application.OpenURL("http://www.facebook.com/pages/Donut-Madness/343761999100579");
    }
}
