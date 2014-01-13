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
		this.guiTexture.pixelInset = new Rect(Screen.width * 0.85f, Screen.height * 0.75f, Screen.height * 0.15f, Screen.height * 0.15f);
		PausePlane.renderer.enabled = false;
		timeScale = Time.timeScale;
	}


    void OnMouseDown()
    {
		FlurryManager.instance.Button ("Pause");
        //FindObjectOfType<Jumper>().canjump = false;
        if (Time.timeScale == 0)
        {
            paused = false;
			
            Pause();
        }

        else
        {
            paused = true;
			
            Unpause();
        }

		
    }

    void OnMouseUp()
    {
        //FindObjectOfType<Jumper>().canjump = true;
    }


    public void Pause()
    {
        //Light.GetComponent<Light>().intensity = 1.1f;
		Time.timeScale = timeScale;
        pauseoptions.SetActive(false);
        donut.GetComponentInChildren<Jumper>().enabled = true;
        guiTexture.texture = normalPause;

		Color colorT = guiTexture.color;
		colorT.a = 0.4f;
		guiTexture.color = colorT;

        PausePlane.renderer.enabled = paused;
    }

    public void Unpause()
    {
        //Light.GetComponent<Light>().intensity = 0.0f;        
        Time.timeScale = 0;
        pauseoptions.SetActive(true);
        donut.GetComponentInChildren<Jumper>().enabled = false;
        guiTexture.texture = normalPlay;
		guiTexture.color = new Color(guiTexture.color.r, guiTexture.color.g, guiTexture.color.b, 1.0f);

        PausePlane.renderer.enabled = paused;
    }
}
