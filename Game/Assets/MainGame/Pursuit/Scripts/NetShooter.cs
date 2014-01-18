using UnityEngine;
using System.Collections;

public class NetShooter : MonoBehaviour {
	public GameObject donut;
	public Mesh mesh;
	public Material material;

	public void Shoot(GameObject target) {
		transform.LookAt(target.transform.position, Vector3.up);
		transform.rotation = Quaternion.AngleAxis(90, Vector3.forward) * transform.rotation;
		InteractiveCloth net = gameObject.AddComponent<InteractiveCloth>();
		net.density = 0.1f;
		net.friction = 1;
		net.thickness = 0.9f;
		net.mesh = mesh;
		net.collisionResponse = 1.0f;
		net.useGravity = false;
		net.externalAcceleration = new Vector3(0.0f, -300.0f, 0.0f);
		gameObject.AddComponent<ClothRenderer>().material = material;
		net.AddForceAtPosition((target.transform.position - transform.position).normalized * 50 + target.rigidbody.velocity, transform.transform.position, 10000, ForceMode.VelocityChange);
	}
}
