using UnityEngine;
using System.Collections;

public class AchievementUnlockedScript : MonoBehaviour {

    void Awake()
    {
        this.guiTexture.pixelInset = new Rect(
            -0.5f * Screen.width * 0.3f,
            0.0f,
            Screen.width * 0.3f,
            Screen.height * 0.1f);
    }

}
