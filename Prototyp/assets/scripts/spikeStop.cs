using UnityEngine;
using System.Collections;

/// <summary>
/// Provides functions of a spike stop.
/// </summary>

public class spikeStop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	void OnTriggerEnter (Collider other)
	{
		//When object taged "Player" inserts the trigger
		//current level reloads.
		if (other.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
