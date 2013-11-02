using UnityEngine;
using System.Collections;

/// <summary>
/// Game controlling script provides functionalities which are persistent while playing.
/// HUD, lifes counter, score etc.
/// </summary>

public class gameControllingScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//Sets time scale
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
		//Creates "Restart" button
		if (GUI.Button(new Rect(Screen.width - 110, 10, 100, 100), "Restart"))
		{
   	  		Application.LoadLevel(Application.loadedLevelName); //Reloads currently loaded level
		}
	}
	

}
