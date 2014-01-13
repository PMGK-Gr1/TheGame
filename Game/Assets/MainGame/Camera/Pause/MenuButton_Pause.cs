using UnityEngine;
using System.Collections;

public class MenuButton_Pause : MonoBehaviour {

	// Use this for initialization
    private Donut donut;
	void Start () {
        donut = GameController.instance.donut;
        this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.45f,
            Screen.height * 0.65f,
            Screen.width * 0.1f,
            Screen.width * 0.1f);

	}

    void OnMouseUp()
    {
		FlurryManager.instance.Button("RetToMenu");
        Time.timeScale = 1.0f;
        donut.Save();
        Application.LoadLevel(0);
    }
}
