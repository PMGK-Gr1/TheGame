using UnityEngine;
using System.Collections;

public class Sugar : MonoBehaviour {
	private float rotationSpeed = 5;
	private float rotation;
	private Vector3 rotationAxis;

	void Start() {
		rotation = Random.Range(0.0f, 100.0f);
		rotationAxis = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
	}


	void FixedUpdate() {
		rotation += rotationSpeed;
		transform.rotation = Quaternion.AngleAxis(rotation, rotationAxis);
	}

	void OnTriggerEnter(Collider other) {
		RigidDonut donut;
		if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
			donut.SugarPickup(1);
			Destroy(gameObject);
		}
	}
}