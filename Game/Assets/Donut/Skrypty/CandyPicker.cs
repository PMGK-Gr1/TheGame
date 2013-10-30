using UnityEngine;
using System.Collections;

public class CandyPicker : MonoBehaviour {

	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.tag == "Candy") {
			Debug.Log("I Ate Candy");
			Destroy(other.gameObject);
		}
	}
}
