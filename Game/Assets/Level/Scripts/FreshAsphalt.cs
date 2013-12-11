using UnityEngine;
using System.Collections;

public class FreshAsphalt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut> ()) != null) {
			donut.FreshAsphalt();
		}
	}
}
