using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    void OnGUI()
    {
        Rect menuButton = new Rect();
        menuButton.x = Screen.width * 0.85f;
        menuButton.y = Screen.height * 0.85f;
        menuButton.width = Screen.width * 0.1f;
        menuButton.height = Screen.height * 0.1f;
        if (GUI.Button(menuButton, "Menu"))
        {
			FlurryManager.instance.Button ("Menu");
            Application.LoadLevel(0);
        }

        Rect againButton = new Rect();
        againButton.x = Screen.width * 0.55f;
        againButton.y = Screen.height * 0.85f;
        againButton.width = Screen.width * 0.2f;
        againButton.height = Screen.height * 0.1f;
        if (GUI.Button(againButton, "Play Again"))
		{
			FlurryManager.instance.Button ("Play Again");
            Application.LoadLevel(1);
        }

        Rect shopButton = new Rect();
        shopButton.x = Screen.width * 0.35f;
        shopButton.y = Screen.height * 0.85f;
        shopButton.width = Screen.width * 0.1f;
        shopButton.height = Screen.height * 0.1f;
        if (GUI.Button(shopButton, "Shop"))
		{
			FlurryManager.instance.Button ("Shop");
            Application.LoadLevel(3);
        }

    }
}