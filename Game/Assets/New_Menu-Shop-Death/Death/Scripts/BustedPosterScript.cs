using UnityEngine;
using System.Collections;

public class BustedPosterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect((float)Screen.width * 0.5f - 0.5f * ((710.0f * 9.0f) / (914.0f * 16.0f)) * (float)Screen.width, 
            0,
            ((710.0f * 9.0f) / (914.0f * 16.0f)) * (float)Screen.width,
            Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
