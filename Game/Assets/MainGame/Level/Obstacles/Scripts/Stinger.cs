using UnityEngine;
using System.Collections;

public class Stinger : MonoBehaviour {

	RigidDonut donut;


	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			if(GameController.instance.chocolateRain) {
				Destroy (this);
				return;
			}
			donut.StingerHit();
			this.enabled = false;
		}
	}
}
