using UnityEngine;
using System.Collections;

public class TwitterButtonScript : MonoBehaviour {
    public Controller control;
	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(
              Screen.width * 0.87f,
              Screen.height * 0.1f,
              Screen.width * 0.1f,
              Screen.width * 0.1f);

	}
	
	// Update is called once per frame
    void OnMouseUp() {
		FlurryManager.instance.Button("Twitter");
        if (!control.optionsOn) Application.OpenURL("http://www.twitter.com/donutmadness");
    }
}
