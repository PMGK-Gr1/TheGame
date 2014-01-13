using UnityEngine;
using System.Collections;

public class AnotherPlayButton : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        /*this.guiTexture.pixelInset = new Rect(
            0.5f * (float)Screen.width + 0.5f * (634.0f / 1676.0f) * (float)Screen.width,
            0.15f * (float)Screen.height,
            (634.0f / 1676.0f) * 0.8f * (float)Screen.width,
            (304.0f / 1013.0f) * 0.8f * (float)Screen.height);
        */
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.65f,
            Screen.height * 0.1f,
            Screen.width * 0.3f,
            Screen.width * 0.1f);
    }

    void OnMouseUp() {
		FlurryManager.instance.Button("ShopPlay");
		FlurryManager.instance.CandiesSpent();
        Application.LoadLevel("MainScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
