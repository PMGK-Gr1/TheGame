using UnityEngine;
using System.Collections;

public class SecondLife : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut>()) != null) {
			donut.GiveSecondLife();
			Destroy(gameObject);
		}
	}
}
