using UnityEngine;
using System.Collections;

public class Viaduct : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Donut donut;
		if ((donut = other.gameObject.GetComponent<Donut> ()) != null) {
			donut.Viaduct();
		}
	}
}
