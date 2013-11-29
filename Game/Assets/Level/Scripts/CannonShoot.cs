using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour {


	void OnTriggerStay(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.MilkCannonHit();
			this.enabled = false;
		}
	}



}
