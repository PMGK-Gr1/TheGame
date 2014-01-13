using UnityEngine;
using System.Collections;

public class MusicButtonScript : MonoBehaviour {

   
	// Use this for initialization
    public Texture2D musicOnTexture;
    public Texture2D musicOffTexture;


    void Awake()
    {
        if (!PlayerPrefs.HasKey("music")) PlayerPrefs.SetInt("music", 1);
    }

	void Start () {
	
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.3f,
            Screen.height * 0.55f,
            Screen.width * 0.15f,
            Screen.height * 0.25f);

        if (PlayerPrefs.GetInt("music", 1) == 1)
        {
            guiTexture.texture = musicOnTexture;
        }
        else
        {
            guiTexture.texture = musicOffTexture;
        }
	}

    void OnMouseUp() {
		FlurryManager.instance.Button("Music");
        int music = PlayerPrefs.GetInt("music", 1);

        if (music == 0)
        {
        
            guiTexture.texture = musicOnTexture;
            music = 1;
        }
        else
        {
            music = 0;
            guiTexture.texture = musicOffTexture;
          
        }

        PlayerPrefs.SetInt("music", music);

    }
}
