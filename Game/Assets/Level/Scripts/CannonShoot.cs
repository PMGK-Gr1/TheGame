using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.MilkCannonHit();
			this.enabled = false;
		}
	}
}
