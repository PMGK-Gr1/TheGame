using UnityEngine;
using System.Collections;

public class MusicButtonScript : MonoBehaviour {

   
	// Use this for initialization

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
	

	}

    void OnMouseUp() {
		FlurryManager.instance.Button("Music");
        int music = PlayerPrefs.GetInt("music");
        PlayerPrefs.SetInt("music", music * (-1));  

    }
}
