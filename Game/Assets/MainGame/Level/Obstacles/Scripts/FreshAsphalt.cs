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
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut> ()) != null) {
			if(!donut.FreshAsphalt()) {
				Destroy(this);
			}
			else {
				other.rigidbody.drag = 3.0f;
			}
		}
        donut.slippyCount++;
	}

	void OnTriggerExit(Collider other) {
		Donut donut = other.gameObject.GetComponent<Donut>();
		if (donut != null) {
			other.rigidbody.drag = 0.0f;
		}
	}
}
