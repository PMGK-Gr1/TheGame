using UnityEngine;
using System.Collections;

public class DoubleFrosting : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.FrostDonut();
			// TODO nice pickup particle effect or some other spectacular thingy
			Destroy(gameObject);
		}
	}
}
