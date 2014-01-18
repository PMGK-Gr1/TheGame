using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

    void OnGUI()
    {
        Rect rectButton = new Rect();
        rectButton.x = Screen.width * 0.85f;
        rectButton.y = Screen.height * 0.9f;
        rectButton.width = Screen.width * 0.1f;
        rectButton.height = Screen.height * 0.1f;        
        if(GUI.Button(rectButton, "Reset")){
			FlurryManager.instance.Button ("Reset");
            Time.timeScale = 1;
            LoadingScreen.LoadLevel(0);
        }

    }

}
