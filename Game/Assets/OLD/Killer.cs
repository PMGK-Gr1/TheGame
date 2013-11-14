using UnityEngine;
using System.Collections;

/// <summary>
/// Obstacles don't kill donuts.
/// I do.
/// </summary>

public class Killer : MonoBehaviour {
	
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
			SaveSystem.Save();
            Debug.Log(Localization.getText("DEAD"));
            Application.LoadLevel(0);
        }

    }
}
