using UnityEngine;
using System.Collections;

public class SoundButton_Pause : MonoBehaviour {

	// Use this for initialization
    public Camera camera;
    public float vol;
    
	void Start () {


        this.guiTexture.pixelInset = new Rect(
          Screen.width * 0.55f,
          Screen.height * 0.45f,
          Screen.width * 0.1f,
          Screen.width * 0.1f);
	}


    void OnMouseUp()
    {
        int sound = PlayerPrefs.GetInt("sound");
        sound *= -1;
        PlayerPrefs.SetInt("sound", sound);
        if (sound > 0) AudioListener.volume = 0.0f;
        else AudioListener.volume = 1.0f;


    }
	// Update is called once per frame
	void Update () {
        vol = AudioListener.volume;

	}
}
