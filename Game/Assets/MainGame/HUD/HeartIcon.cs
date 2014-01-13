using UnityEngine;
using System.Collections;

public class HeartIcon : MonoBehaviour {


	// Use this for initialization
	void Start () {
		this.guiTexture.pixelInset = new Rect(Screen.width * 0.475f, Screen.height * 0.83f, Screen.height * 0.1f, Screen.height * 0.1f);
		guiTexture.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Enable()
	{
		guiTexture.enabled = true;
	}

	public void Disable()
	{
		guiTexture.enabled = false;
	}
}
