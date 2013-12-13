using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    void OnMouseUp()
    {
        Time.timeScale = 1.0f;
        Application.LoadLevel(1);
    }
}
