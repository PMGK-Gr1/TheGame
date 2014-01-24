using UnityEngine;
using System.Collections;

public class AchievementScript : MonoBehaviour {


    public int id;

    public Texture locked, unlocked;

 

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Achievement" + id)) PlayerPrefs.SetInt("Achievement" + id, 0);

        if (PlayerPrefs.GetInt("Achievement" + id) == 0) this.guiTexture.texture = locked;
        else this.guiTexture.texture = unlocked;


        this.guiTexture.pixelInset = new Rect(
            0.0f,
            0.0f,
            Screen.width * 0.6f,
            Screen.height * 0.3f
            );

        this.transform.position = new Vector3 (
           4.0f + 0.05f,
           0.6f - 2.5f * (float)id / 10.0f,
            this.transform.position.z);
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Achievement" + id) == 0) this.guiTexture.texture = locked;
        else this.guiTexture.texture = unlocked;
    }

}
