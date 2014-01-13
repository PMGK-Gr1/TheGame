using UnityEngine;
using System.Collections;

public class MusicButton_Pause : MonoBehaviour {

	void Start () {
        this.guiTexture.pixelInset = new Rect(
           Screen.width * 0.35f,
           Screen.height * 0.45f,
           Screen.width * 0.1f,
           Screen.width * 0.1f);
	}

    void OnMouseUp()
    {
		FlurryManager.instance.Button("PauseMusic");
        int music = PlayerPrefs.GetInt("music");
        PlayerPrefs.SetInt("music", (music * (-1)));
		Camera.main.GetComponent<AudioSource>().enabled = !Camera.main.GetComponent<AudioSource>().enabled;
		if (Camera.main.GetComponent<AudioSource>().enabled) Camera.main.GetComponent<AudioSource>().Play();
    }
}
