using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public GameObject Light;
    public bool paused;
    public GameObject pauseoptions;
	public FlurryManager flurry;
    private Donut donut;
	// Use this for initialization
	void Start () {
        donut = GameController.instance.donut;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
		flurry.SendMessage ("Button", "Pause");
        FindObjectOfType<Jumper>().canjump = false;
        if (Time.timeScale == 0)
        {
            Light.GetComponent<Light>().intensity = 1.1f;
            paused = false;

            Time.timeScale = 1;
            pauseoptions.active = false;
            donut.GetComponentInChildren<Jumper>().enabled = true;       


        }

        else
        {

            Light.GetComponent<Light>().intensity = 0.0f;

            paused = true;
            Time.timeScale = 0;
            pauseoptions.active = true;
            donut.GetComponentInChildren<Jumper>().enabled = false;       
        }
    }

    void OnMouseUp()
    {
        FindObjectOfType<Jumper>().canjump = true;
    }
    
}
