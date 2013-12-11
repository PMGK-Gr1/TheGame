using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {
    private RigidDonut donut;

    void Start()
    {
        donut = RigidDonut.instance;
    }
    void OnGUI()
    {
        Rect button1 = new Rect();
       // Rect button2 = new Rect();
       // Rect button3 = new Rect();

        button1.x = Screen.width * 0.25f;
        button1.y = Screen.height * 0.8f;
       // button2.x = Screen.width * 0.45f;
      //  button2.y = Screen.height * 0.8f;
      //  button3.x = Screen.width * 0.65f;
      //  button3.y = Screen.height * 0.8f;
        button1.height =/* button2.height = button3.height =*/ Screen.height * 0.1f;
        button1.width =/* button2.width = button3.width = */Screen.width * 0.2f;

        if(GUI.Button(button1, "Uprgade"))  {
            donut.SticykDonut(10);
        };
       // if (GUI.Button(button2, "Uprgade 2")) { };
       // if (GUI.Button(button3, "Uprgade 3")) { };

    }
}
