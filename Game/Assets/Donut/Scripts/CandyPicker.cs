﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Picking candies.
/// </summary>
public class CandyPicker : MonoBehaviour {

    //public variables
    public GUIText Score;
    //private
    private int candiesEaten = 0;
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if (other.tag == "Candy") {
            candiesEaten++;
            Debug.Log(Localization.getText("CANDY_EATEN"));
            Score.fontSize = (Screen.height)/15;
            Score.text = "Candies: " + candiesEaten.ToString();
			Destroy(other.gameObject);
		}
	}
	
	public int GetCandies()
	{
		return candiesEaten;
	}
}
