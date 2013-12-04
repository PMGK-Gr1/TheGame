using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

    public Texture PauseButton;
    public GameObject Light;

    void OnGUI()
    {
        Rect button = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.1f);
        if(GUI.Button(button, PauseButton))
        {
            if (Time.timeScale == 0)
            {
                Light.GetComponent<Light>().intensity = 0.5f;
                Time.timeScale = 1;
            }

            else
            {
                Time.timeScale = 0;
                Light.GetComponent<Light>().intensity = 0.0f;
            }
        }
}
}
