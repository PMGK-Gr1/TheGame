using UnityEngine;
using System.Collections;

public class LastGame : MonoBehaviour
{

    void Start()
    {
        this.guiText.text = "You've managed to reach " + PlayerPrefs.GetInt("LastDistance").ToString()
            + " m and collect " + PlayerPrefs.GetInt("LastSugar").ToString() + " sugar cube(s).";
    }

}
