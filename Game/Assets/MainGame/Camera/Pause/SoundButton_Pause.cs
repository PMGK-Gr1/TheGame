using UnityEngine;
using System.Collections;

public class SoundButton_Pause : MonoBehaviour {

	public Texture2D sfxOnTexture;
	public Texture2D sfxOffTexture;

	// Use this for initialization
    //public float soundVolume; 
  
	void Start () {
        this.guiTexture.pixelInset = new Rect(
          Screen.width * 0.55f,
          Screen.height * 0.45f,
          Screen.width * 0.1f,
          Screen.width * 0.1f);

		if( PlayerPrefs.GetInt("sound", 1) == 1)
		{
			guiTexture.texture = sfxOnTexture;
		}
		else
		{
			guiTexture.texture = sfxOffTexture;
		}
	}


    void OnMouseUp()
    {
		int sound = PlayerPrefs.GetInt("sound");
		
		if (sound == 0)
		{
			sound = 1;
			guiTexture.texture = sfxOnTexture;
		}
		else
		{
			sound = 0;
			guiTexture.texture = sfxOffTexture;
		}
		
		PlayerPrefs.SetInt("sound", sound);
    }
	// Update is called once per frame
	/*void Update () {
        soundVolume = AudioListener.volume;
	}*/
}
