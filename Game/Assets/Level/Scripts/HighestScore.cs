using UnityEngine;
using System.Collections;

public class HighestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<TextMesh>().text= "Record: " + PlayerPrefs.GetInt("HighestScore").ToString() + " m";
        Destroy(this.gameObject, 10.0f);
    	}
	
	
}
