using UnityEngine;
using System.Collections;

public class DistanceReachedScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.guiText.fontSize = (int)(Screen.height * 0.1f);
        this.guiText.text = PlayerPrefs.GetInt("LastDistance").ToString();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
