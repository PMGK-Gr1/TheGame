using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class SoftDonutMover : MonoBehaviour {

	//public variables
	public GameObject Cylinder;
	public float ForceMultiplier = 1.0f;
    //private variables
    private InteractiveCloth cloth;
	private float cooldown = 0;

	// Use this for initialization
	void Start() {
		cloth = this.GetComponent<InteractiveCloth>();
	}

	// Update is called once per frame
	void FixedUpdate() {
		//float force = Input.GetAxis("Horizontal");
		float tmpForce = Input.acceleration.x + Input.GetAxis("Horizontal");
		cloth.AddForceAtPosition(new Vector3(tmpForce * ForceMultiplier, 0, 0), Cylinder.transform.position + new Vector3(0, 1f, 0), 1f);

		if ((Input.touchCount != 0 || Input.GetKeyDown(KeyCode.Space)) && cooldown <= 0) {
			cloth.AddForceAtPosition(new Vector3(0, 4000, 0), Cylinder.transform.position + new Vector3(0, -1f, 0), 1f);
			cloth.AddForceAtPosition(new Vector3(0, 8000, 0), Cylinder.transform.position, 4f);
			cooldown = 0.5f;
		}
		cooldown -= Time.fixedDeltaTime;
	}
}
