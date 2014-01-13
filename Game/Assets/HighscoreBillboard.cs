using UnityEngine;
using System.Collections;

public class HighscoreBillboard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = PlayerPrefs.GetInt("HighestScore").ToString();
	}
}
