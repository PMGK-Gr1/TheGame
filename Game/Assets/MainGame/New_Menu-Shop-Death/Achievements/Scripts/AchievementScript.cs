using UnityEngine;
using System.Collections;

public class AchievementScript : MonoBehaviour {


    public int id;

    public Texture locked, unlocked;

 

    void Awake()
    {
        if (PlayerPrefs.GetInt("Achievement" + id) == 0) this.guiTexture.texture = locked;
        else this.guiTexture.texture = unlocked;
    }

}
