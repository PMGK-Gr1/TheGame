using UnityEngine;
using System.Collections;

public class SecondLife : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.BurntDonut();
			Destroy(gameObject);
		}
	}
}
