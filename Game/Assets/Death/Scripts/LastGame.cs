using UnityEngine;
using System.Collections;

public class LastGame : MonoBehaviour
{

    void Start()
    {
        this.guiText.fontSize = (int)(Screen.height * 0.075f);
        this.guiText.text = "You've managed to reach " + PlayerPrefs.GetInt("LastDistance").ToString()
            + " m  \n and collect " + PlayerPrefs.GetInt("LastSugar").ToString() + " sugar cube(s)." 
            + " \n \n Really? That's it? \n Even a rocket can do better.";
    }

}
