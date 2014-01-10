using UnityEngine;
using System.Collections;

public class SoundButton_Pause : MonoBehaviour {

	// Use this for initialization
    public Camera camera;

	void Start () {


        this.guiTexture.pixelInset = new Rect(
          Screen.width * 0.55f,
          Screen.height * 0.45f,
          Screen.width * 0.1f,
          Screen.width * 0.1f);
	}


    void OnMouseUp()
    {
        int music = PlayerPrefs.GetInt("sound");
        PlayerPrefs.SetInt("sound", music * (-1));
        camera.GetComponent<AudioListener>().enabled = !camera.GetComponent<AudioListener>().enabled;


    }
	// Update is called once per frame
	void Update () {
	
	}
}
