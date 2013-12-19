using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public GameObject Light;
    public bool paused;
    public GameObject pauseoptions;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        FindObjectOfType<Jumper>().canjump = false;
        if (Time.timeScale == 0)
        {
            Light.GetComponent<Light>().intensity = 1.1f;
            paused = false;

            Time.timeScale = 1;
            pauseoptions.active = false;

        }

        else
        {

            Light.GetComponent<Light>().intensity = 0.0f;

            paused = true;
            Time.timeScale = 0;
            pauseoptions.active = true;
        }
    }

    void OnMouseUp()
    {
        FindObjectOfType<Jumper>().canjump = true;
    }
    
}
