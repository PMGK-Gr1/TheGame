using UnityEngine;
using System.Collections;

public class Sugar : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.SugarPickup(1);
			Destroy(gameObject);
		}
	}
}