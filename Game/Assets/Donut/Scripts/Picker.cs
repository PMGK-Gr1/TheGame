using UnityEngine;
using System.Collections;


/// <summary>
/// Picking candies.
/// </summary>
public class Picker : MonoBehaviour {

    //public variables
    //public GUIText Score;
    //private
    //private int candiesEaten = 0;
	// Update is called once per frame
	private RigidDonut donut;

	void Start() {
		donut = RigidDonut.instance;
	}


	void OnTriggerEnter(Collider other){
		if (other.tag == "Sugar") {
			Debug.Log("Picked sugar");
            //candiesEaten++;
            //Debug.Log(Localization.getText("CANDY_EATEN"));
            //Score.fontSize = (Screen.height)/15;
            //Score.text = "Candies: " + candiesEaten.ToString();
			Destroy(other.gameObject);
			// TODO implement some number popup, animation or something
			return;
		}

		if (other.tag == "Boost") {
			Debug.Log("Picked boost");
			donut.BoostPickup("Some type got from the boost gameobject");
			Destroy(other.gameObject);
			// TODO implement different boost types
			return;
		}

		if (other.tag == "Obstacle") {
			Debug.Log("Picked obstacle?!?");
			donut.Death("Some cause got from the obstacle gameobject");
			other.collider.enabled = false;			// disable the obstacle so that it doesn't damage us multiple times
			return;
		}
	}
}
