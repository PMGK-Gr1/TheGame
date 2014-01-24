using UnityEngine;
using System.Collections;

public class AchievementsReturnButton : MonoBehaviour
{

    public Controller control;
    public bool active = false;

    public UpgradesSwipe swipe;

    // Use this for initialization
    void Start()
    {
        this.guiTexture.pixelInset = new Rect(
                Screen.width * 0.75f,
                Screen.height * 0.075f,
                Screen.width * 0.2f,
                Screen.width * 0.1f);
    }


    void OnMouseDown()
    {
        swipe.canSwipe = false;
    }

    void OnMouseEnter()
    {
        swipe.canSwipe = false;
    }

    void OnMouseExit()
    {
        swipe.canSwipe = true;
    }

    void OnMouseUp()
    {
        
        if (active)
        {
            active = false;
            control.FromAchievements();
        }
        swipe.canSwipe = true;
    }
}
