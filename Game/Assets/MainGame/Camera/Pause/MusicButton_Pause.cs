using UnityEngine;
using System.Collections;

public class MusicButton_Pause : MonoBehaviour {

	public Texture2D musicOnTexture;
	public Texture2D musicOffTexture;

	void Start () {
        this.guiTexture.pixelInset = new Rect(
           Screen.width * 0.35f,
           Screen.height * 0.45f,
           Screen.width * 0.1f,
           Screen.width * 0.1f);
		
		if( PlayerPrefs.GetInt("music", 1) == 1)
		{
			guiTexture.texture = musicOnTexture;
		}
		else
		{
			guiTexture.texture = musicOffTexture;
		}
	}

    void OnMouseUp()
    {
		FlurryManager.instance.Button("PauseMusic");
        int music = PlayerPrefs.GetInt("music", 1);

		if (music == 0)
		{
			Camera.main.GetComponent<AudioSource>().Play();
			guiTexture.texture = musicOnTexture;
			music = 1;
		}
		else
		{
			music = 0;
			guiTexture.texture = musicOffTexture;
			Camera.main.GetComponent<AudioSource>().Pause();
		}

		PlayerPrefs.SetInt("music", music);
    }
}
