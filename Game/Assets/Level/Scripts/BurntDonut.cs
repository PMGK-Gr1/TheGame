using UnityEngine;
using System.Collections;

public class BurntDonut : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.BurntDonut();
			Destroy(gameObject);
		}
	}
}
