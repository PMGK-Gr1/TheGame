using UnityEngine;
using System.Collections;

public class ResetButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
        this.guiTexture.pixelInset = new Rect(
             Screen.width * 0.3f,
             Screen.height * 0.35f,
             Screen.height * 0.655f,
               Screen.height * 0.25f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
