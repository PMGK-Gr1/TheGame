using UnityEngine;
using System.Collections;

public class CandyPicker : MonoBehaviour {

    public GUIText score;
    int candiesEaten = 0;
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.tag == "Candy") {
            candiesEaten++;
            Debug.Log("I Ate Candy!");
            score.fontSize = (Screen.height)/15;
            score.text = "Candies: " + candiesEaten.ToString();
			Destroy(other.gameObject);
		}
	}
}
