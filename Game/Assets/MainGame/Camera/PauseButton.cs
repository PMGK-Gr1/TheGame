using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public GameObject Light;
    public bool paused;
    public GameObject pauseoptions;
    private Donut donut;
	public Texture2D normalPause;
	public Texture2D normalPlay;
	public GameObject PausePlane;

	private float timeScale;
	// Use this for initialization
	void Start () {
		paused = false;
        donut = GameController.instance.donut;
		this.guiTexture.pixelInset = new Rect(Screen.width * 0.8f, Screen.height * 0.05f, Screen.height * 0.15f, Screen.height * 0.15f);
		PausePlane.renderer.enabled = false;
		timeScale = Time.timeScale;
	}


    void OnMouseDown()
    {
        FindObjectOfType<Jumper>().canjump = false;
        if (Time.timeScale == 0)
        {
            paused = false;
			guiTexture.texture = normalPause;
            Pause();
        }

        else
        {
            paused = true;
			guiTexture.texture = normalPlay;
            Unpause();
        }

		PausePlane.renderer.enabled = paused;
    }

    void OnMouseUp()
    {
        FindObjectOfType<Jumper>().canjump = true;
    }


    public void Pause()
    {
        //Light.GetComponent<Light>().intensity = 1.1f;
		Time.timeScale = timeScale;
        pauseoptions.SetActive(false);
        donut.GetComponentInChildren<Jumper>().enabled = true;   
    }

    public void Unpause()
    {
        //Light.GetComponent<Light>().intensity = 0.0f;        
        Time.timeScale = 0;
        pauseoptions.SetActive(true);
        donut.GetComponentInChildren<Jumper>().enabled = false; 
    }
}
