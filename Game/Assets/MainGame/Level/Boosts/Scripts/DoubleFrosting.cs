using UnityEngine;
using System.Collections;

public class DoubleFrosting : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut>()) != null) {
			donut.FrostDonut();
			// TODO nice pickup particle effect or some other spectacular thingy
			Destroy(gameObject);
		}
	}
}
