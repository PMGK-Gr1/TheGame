using UnityEngine;
using System.Collections;

public class AchievementsReturnButton : MonoBehaviour
{

    public Controller control;
    public bool active = false;

    // Use this for initialization
    void Start()
    {
        this.guiTexture.pixelInset = new Rect(
                Screen.width * 0.65f,
                Screen.height * 0.3f,
                Screen.width * 0.3f,
                Screen.width * 0.1f);
    }

    void OnMouseUp()
    {
        if (active)
        {
            active = false;
            control.FromAchievements();
        }
    }
}
