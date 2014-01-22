using UnityEngine;
using System.Collections;

public class AchievementsBackgroundScript : MonoBehaviour {

    void Start()
    {
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.2f,
            0,
            Screen.width * 0.6f,
            Screen.height);
    }
	
}
