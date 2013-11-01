using UnityEngine;
using System.Collections;

public class kolczatka : MonoBehaviour {

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
		if (other.tag == "Player")
		{
			Application.LoadLevel(Application.loadedLevelName);
		}
	}
}
