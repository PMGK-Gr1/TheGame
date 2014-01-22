using UnityEngine;
using System.Collections;

public class AchievementsButtonScript : MonoBehaviour {

    public Controller control;

    public bool active = true;
  
    void Start()
    {

        this.guiTexture.pixelInset = new Rect(0.025f * (float)Screen.width,
            0.3f * (float)Screen.height,
            (178.0f / 1676.0f) * (float)Screen.width,
            (178.0f / 1013.0f) * (float)Screen.height);


    }


    void OnMouseUp()
    {
        if (active)
        {
            FlurryManager.instance.Button("Achievements ");
            control.ToAchievements();
        }
    }
}
