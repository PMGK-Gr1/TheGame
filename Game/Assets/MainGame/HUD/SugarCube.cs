using UnityEngine;
using System.Collections;

public class SugarCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.guiTexture.pixelInset = new Rect(Screen.width * 0.01f, Screen.height * 0.835f, Screen.height * 0.05f, Screen.height * 0.05f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
