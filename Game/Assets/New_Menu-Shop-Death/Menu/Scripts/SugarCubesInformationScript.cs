using UnityEngine;
using System.Collections;

public class SugarCubesInformationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(0.8f * (float)Screen.width,
              0.45f * (float)Screen.height - (219.0f / 1013.0f) * (float)Screen.height,
              (381.0f / 1676.0f) * (float)Screen.width,
              (219.0f / 1013.0f) * (float)Screen.height);


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
