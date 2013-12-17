using UnityEngine;
using System.Collections;

public class Viaduct : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut> ()) != null) {
			donut.Viaduct();
		}
	}
}
