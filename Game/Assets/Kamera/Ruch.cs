using UnityEngine;
using System.Collections;

public class Ruch : MonoBehaviour {

	public GameObject cylinder;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) Application.Quit();
		if(Input.GetKeyDown(KeyCode.Menu)) Application.LoadLevel(0);

		this.transform.position = cylinder.transform.position + new Vector3(1, 0.5f, -3.5f);
	}


}
