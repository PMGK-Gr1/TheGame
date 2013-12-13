using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    public Texture PauseButton;
    public GameObject Light;

    private RigidDonut donut;

    void Start()
    {
        donut = RigidDonut.instance;
    }

    bool pausebuttons = false;
    void OnGUI()
    {
       
        Rect button = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.1f);

        if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), "menu")))
        {
            Application.LoadLevel(0);
            donut.SaveAll();
        }

        if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "sound"))) { }
        if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.1f), "music"))) { }
    


        if(GUI.Button(button, PauseButton))
        {
            if (Time.timeScale == 0)
            {
                Light.GetComponent<Light>().intensity = 1.1f;
                pausebuttons = false;

                Time.timeScale = 1;
            }

            else
            {
           
                Light.GetComponent<Light>().intensity = 0.0f;

                pausebuttons = true;
                Time.timeScale = 0;
            }
        }
}
}
