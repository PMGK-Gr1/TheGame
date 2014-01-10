using UnityEngine;
using System.Collections;

public class NetShooter : MonoBehaviour {
	float time = -1000;
	public GameObject donut;
	public Mesh mesh;

	// Use this for initialization
	void Start () {
		time = Time.time + 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (time < Time.time) {
			Shoot(donut.transform);
			time = float.PositiveInfinity;
		}
	}

	void Shoot(Transform target) {
		transform.LookAt(target.position, Vector3.up);
		transform.rotation = Quaternion.AngleAxis(90, Vector3.forward) * transform.rotation;
		InteractiveCloth net = gameObject.AddComponent<InteractiveCloth>();
		net.friction = 1;
		net.mesh = mesh;
		//net.useGravity = false;
		gameObject.AddComponent<ClothRenderer>();
		net.AddForceAtPosition((target.position - transform.position).normalized * 50, transform.position, 10000, ForceMode.VelocityChange);
	}
}
