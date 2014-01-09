using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {
	
	public FlurryManager flurry;

    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Play");
        Time.timeScale = 1.0f;
        Application.LoadLevel(1);
    }
}
