using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour {

	public GameObject cylinder;
	Vector3 startVector;
	
	// Use this for initialization
	void Start () {
		startVector = this.transform.position - cylinder.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		if(Input.GetKeyDown(KeyCode.Menu)) Application.LoadLevel(0);     
        this.transform.position = cylinder.transform.position + startVector;
	}


}
