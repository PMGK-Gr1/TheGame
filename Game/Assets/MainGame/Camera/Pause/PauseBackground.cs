using UnityEngine;
using System.Collections;

public class PauseBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.3f,
            Screen.height * 0.1f,
            Screen.width * 0.4f,
            Screen.height * 0.8f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
