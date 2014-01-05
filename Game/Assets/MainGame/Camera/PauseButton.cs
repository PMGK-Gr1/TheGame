using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public GameObject Light;
    public bool paused;
    public GameObject pauseoptions;
    private Donut donut;
	// Use this for initialization
	void Start () {
        donut = GameController.instance.donut;
        this.guiTexture.pixelInset = new Rect(0, 0, Screen.height * 0.15f, Screen.height * 0.15f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        FindObjectOfType<Jumper>().canjump = false;
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
        FindObjectOfType<Jumper>().canjump = true;
    }


    public void Pause()
    {
        Light.GetComponent<Light>().intensity = 1.1f;
        Time.timeScale = 1;
        pauseoptions.SetActive(false);
        donut.GetComponentInChildren<Jumper>().enabled = true;   
    }

    public void Unpause()
    {
        Light.GetComponent<Light>().intensity = 0.0f;
        
        Time.timeScale = 0;
        pauseoptions.SetActive(true);
        donut.GetComponentInChildren<Jumper>().enabled = false; 
    }
}
