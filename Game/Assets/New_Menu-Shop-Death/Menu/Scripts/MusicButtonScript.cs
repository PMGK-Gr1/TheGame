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
            Screen.width * 0.51f,
            Screen.height * 0.65f,
            Screen.height * 0.3f,
            Screen.height * 0.3f);
	

	}

    void OnMouseUp()
    {
        int music = PlayerPrefs.GetInt("music");
        PlayerPrefs.SetInt("music", music * (-1));  

    }
	// Update is called once per frame
	void Update () {
	
	}
}
