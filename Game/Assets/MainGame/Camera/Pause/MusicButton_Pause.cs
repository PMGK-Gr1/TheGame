using UnityEngine;
using System.Collections;

public class MusicButton_Pause : MonoBehaviour {

	// Use this for initialization

    public Camera camera;
	void Start () {

        this.guiTexture.pixelInset = new Rect(
           Screen.width * 0.35f,
           Screen.height * 0.45f,
           Screen.width * 0.1f,
           Screen.width * 0.1f);

	}

    void OnMouseUp()
    {
        int music = PlayerPrefs.GetInt("music");
        PlayerPrefs.SetInt("music", (music * (-1)));
        camera.GetComponent<AudioSource>().enabled = !camera.GetComponent<AudioSource>().enabled;
        if (camera.GetComponent<AudioSource>().enabled) camera.GetComponent<AudioSource>().Play();

    }

	// Update is called once per frame
	void Update () {
	
	}
}
