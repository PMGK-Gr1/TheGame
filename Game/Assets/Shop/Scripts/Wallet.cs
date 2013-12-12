using UnityEngine;
using System.Collections;

public class Wallet : MonoBehaviour {


	void Update () {
        this.guiText.text = "You have " +  PlayerPrefs.GetInt("Sugar").ToString() + "  sugar cube(s)";

	}
}
