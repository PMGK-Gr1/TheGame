using UnityEngine;
using System.Collections;

public class ReturnButton_Pause : MonoBehaviour {

    public PauseButton pause;
	// Use this for initialization
	void Start () {

        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.35f,
            Screen.height * 0.2f,
            Screen.width * 0.3f,
            Screen.height * 0.2f);

	}

    void OnMouseUp() {
		FlurryManager.instance.Button("PauseReturn");
        pause.paused = false;
        pause.Pause();
    }
}
