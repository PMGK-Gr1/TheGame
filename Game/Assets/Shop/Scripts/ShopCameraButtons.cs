using UnityEngine;
using System.Collections;

public class ShopCameraButtons : MonoBehaviour {


    void OnGUI()
    {
        Rect menuButton = new Rect();
        menuButton.x = Screen.width * 0.85f;
        menuButton.y = Screen.height * 0.85f;
        menuButton.width = Screen.width * 0.1f;
        menuButton.height = Screen.height * 0.1f;
        if (GUI.Button(menuButton, "Menu"))
        {
			FlurryManager.instance.CandiesSpent();
			FlurryManager.instance.Button ("Menu");
            LoadingScreen.LoadLevel(0);
        }

        Rect againButton = new Rect();
        againButton.x = Screen.width * 0.55f;
        againButton.y = Screen.height * 0.85f;
        againButton.width = Screen.width * 0.2f;
        againButton.height = Screen.height * 0.1f;
        if (GUI.Button(againButton, "Play"))
		{
			FlurryManager.instance.CandiesSpent();
			FlurryManager.instance.Button ("Play");
            LoadingScreen.LoadLevel(1);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadingScreen.LoadLevel(0);
        if (Input.GetKeyDown(KeyCode.Menu)) LoadingScreen.LoadLevel(0);
    }
}
