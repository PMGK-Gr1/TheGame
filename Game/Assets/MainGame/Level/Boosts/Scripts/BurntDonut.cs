using UnityEngine;
using System.Collections;

public class BurntDonut : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut>()) != null) {
			donut.BurntDonut();
            gameObject.SetActive(false);
		}
	}
}
