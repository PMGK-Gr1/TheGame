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
	void FixedUpdate () {
		Vector3 moveDirection = cylinder.transform.position + startVector - transform.position;
        this.transform.position += moveDirection * 0.2f;
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		if (Input.GetKeyDown(KeyCode.Menu)) Application.LoadLevel(0);
	}


}
