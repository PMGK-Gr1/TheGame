using UnityEngine;
using System.Collections;

public class SetUp : MonoBehaviour {


	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.5f - 0.5f * (Screen.height * 16.0f / 9.0f),
            -3.0f,
            Screen.height * 16.0f / 9.0f,
            Screen.height);
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
