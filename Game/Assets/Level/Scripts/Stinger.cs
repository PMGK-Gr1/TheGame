using UnityEngine;
using System.Collections;

public class Stinger : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.StingerHit();
			this.enabled = false;
		}
	}
}
