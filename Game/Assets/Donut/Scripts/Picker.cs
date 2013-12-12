using UnityEngine;
using System.Collections;


/// <summary>
/// Picking candies.
/// </summary>
public class Picker : MonoBehaviour {

	private RigidDonut donut;

	void Start() {
		donut = RigidDonut.instance;
	}

	void FixedUpdate() {
		donut.IsTouchingGround = false;
	}


	void OnTriggerEnter(Collider other) {
		if (collider.tag == "Ground") donut.IsTouchingGround = true;
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Ground") donut.IsTouchingGround = true;
	}
}
