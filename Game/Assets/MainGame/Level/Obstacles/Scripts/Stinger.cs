using UnityEngine;
using System.Collections;

public class Stinger : MonoBehaviour {

	Donut donut;


	void OnTriggerEnter(Collider other) {
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut>()) != null) {
			if(GameController.instance.chocolateRain) {
				Destroy (this);
				return;
			}
			donut.StingerHit();
			this.enabled = false;
		}
	}
}
