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
		net.friction = 1;
		net.thickness = 0.9f;
		net.mesh = mesh;
		//net.useGravity = false;
		gameObject.AddComponent<ClothRenderer>().material = material;
		net.AddForceAtPosition((target.transform.position - transform.position).normalized * 50 + target.rigidbody.velocity, transform.transform.position, 10000, ForceMode.VelocityChange);
	}
}
