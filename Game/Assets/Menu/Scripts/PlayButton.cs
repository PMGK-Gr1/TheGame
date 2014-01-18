using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

    void OnMouseUp()
    {

		FlurryManager.instance.Button ("Play");
        Time.timeScale = 1.0f;
        LoadingScreen.LoadLevel(1);
    }
}
