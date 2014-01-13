using UnityEngine;
using System.Collections;

public class SoundButtonScript : MonoBehaviour {


    public Texture2D sfxOnTexture;
    public Texture2D sfxOffTexture;
	// Use this for initialization
    void Awake()
    {
        if (!PlayerPrefs.HasKey("sound")) PlayerPrefs.SetInt("sound", 1);
    }

	void Start () {
        this.guiTexture.pixelInset = new Rect(
               Screen.width * 0.55f,
               Screen.height * 0.55f,
               Screen.width * 0.15f,
               Screen.height * 0.25f);


        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {
            guiTexture.texture = sfxOnTexture;
        }
        else
        {
            guiTexture.texture = sfxOffTexture;
        }
	}

    void OnMouseUp() {
		FlurryManager.instance.Button("Sound");
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
}
