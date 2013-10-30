using UnityEngine;
using System.Collections;

public class Turlanie : MonoBehaviour {

	InteractiveCloth cloth;
	public GameObject cylinder;
	public float forceMultiplier = 1.0f;
	public float torqueMultiplier = 1.0f;
	float cooldown = 0;
	
	// Use this for initialization
	void Start () {
		cloth = this.GetComponent<InteractiveCloth>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float force = Input.GetAxis("Horizontal");
		float force = Input.acceleration.x + Input.GetAxis("Horizontal");
		cloth.AddForceAtPosition(new Vector3 (force * forceMultiplier, 0, 0), cylinder.transform.position + new Vector3(0, 0.2f, 0), 0.2f);

		if ((Input.touchCount != 0 || Input.GetKeyDown(KeyCode.Space)) && cooldown <= 0) {
			cloth.AddForceAtPosition(new Vector3(0, 2000, 0), cylinder.transform.position + new Vector3(0, -0.5f, 0), 0.5f);
			cloth.AddForceAtPosition(new Vector3(0, 1000, 0), cylinder.transform.position + new Vector3(0, -0.5f, 0), 4f);
			cooldown = 0.5f;
		}
		cooldown -= Time.fixedDeltaTime;
	}
}
