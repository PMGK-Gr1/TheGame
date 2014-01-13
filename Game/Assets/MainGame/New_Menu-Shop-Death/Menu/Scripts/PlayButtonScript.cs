using UnityEngine;
using System.Collections;

public class PlayButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(0.5f * (float)Screen.width - 0.5f * (634.0f / 1676.0f) * (float)Screen.width,
            0.15f * (float)Screen.height,
            (634.0f / 1676.0f) * (float)Screen.width,
            (304.0f / 1013.0f) * (float)Screen.height);

	}

    void OnMouseUp()
    {
		FlurryManager.instance.Button("Play");
        Application.LoadLevel("MainScene");
    }

	// Update is called once per frame
	void Update () {
	
	}
}
