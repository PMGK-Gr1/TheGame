using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour
{
    public Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {
        Rect menuButton = new Rect();
        menuButton.x = Screen.width * 0.85f;
        menuButton.y = Screen.height * 0.85f;
        menuButton.width = Screen.width * 0.1f;
        menuButton.height = Screen.height * 0.1f;
        if (GUI.Button(menuButton, "Menu"))
        {
            LoadingScreen.LoadLevel(0);
        }

        Rect againButton = new Rect();
        againButton.x = Screen.width * 0.55f;
        againButton.y = Screen.height * 0.85f;
        againButton.width = Screen.width * 0.2f;
        againButton.height = Screen.height * 0.1f;
        if (GUI.Button(againButton, "Play Again"))
        {
            LoadingScreen.LoadLevel(1);
        }

        Rect shopButton = new Rect();
        shopButton.x = Screen.width * 0.35f;
        shopButton.y = Screen.height * 0.85f;
        shopButton.width = Screen.width * 0.1f;
        shopButton.height = Screen.height * 0.1f;
        if (GUI.Button(shopButton, "Shop"))
        {
            LoadingScreen.LoadLevel(3);
        }
        GUI.BeginScrollView(new Rect(100, 3000, 100, 1000), scrollPosition, new Rect(0, 0, 220, 200));
        GUI.Button(new Rect(0, 0, 100, 20), "Top-left");
        GUI.Button(new Rect(120, 0, 100, 20), "Top-right");
        GUI.Button(new Rect(0, 180, 100, 20), "Bottom-left");
        GUI.Button(new Rect(120, 180, 100, 20), "Bottom-right");
        GUI.EndScrollView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) LoadingScreen.LoadLevel(0);
        if (Input.GetKeyDown(KeyCode.Menu)) LoadingScreen.LoadLevel(0);
    }
}