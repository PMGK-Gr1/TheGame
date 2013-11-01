using UnityEngine;
using System.Collections;

public class gameControllingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI()
	{
		if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 100), "Restart"))
		{
   	  		Application.LoadLevel(Application.loadedLevelName);
		}
	}
	

}
