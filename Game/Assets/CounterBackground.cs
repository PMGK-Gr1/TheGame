using UnityEngine;
using System.Collections;

public class CounterBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.305f, 0,
            Screen.width * 0.1f,
            Screen.height * 0.1f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
