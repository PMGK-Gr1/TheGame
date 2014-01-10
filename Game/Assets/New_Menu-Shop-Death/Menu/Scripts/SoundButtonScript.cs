using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(
               Screen.width * 0.3f,
               Screen.height * 0.65f,
               Screen.height * 0.3f,
               Screen.height * 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
