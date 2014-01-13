using UnityEngine;
using System.Collections;

public class OptionsBackgroundScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.2f,
            0,
            Screen.width * 0.6f,
            Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
