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
			if(!donut.FreshAsphalt()) {
				Destroy(this);
			}
			else {
				other.rigidbody.drag = 10.0f;
			}
		}
        donut.slippyCount++;
	}

	void OnTriggerExit(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut> ()) != null) {
			other.rigidbody.drag = 0.0f;
		}
	}
}
