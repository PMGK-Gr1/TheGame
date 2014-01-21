using UnityEngine;
using System.Collections;

public class Pursuit : MonoBehaviour {

    //public variables
	//public float PursuitSpeed = 30.0f;
	public float CatchDistance = 60.0f;
	public float PursuitDelay = 2.0f;
	public float pursuitSpeed;
	public NetShooter netShooter;
    public bool DonutCatchable = true;
    //private variables
	private float startTime = 0.0f;
	private Donut donut;
	private float velocity;

	public float targetAltitude = 0.0f;


	// Use this for initialization
	void Start() {
		startTime = Time.time;
		donut = GameController.instance.donut;
		pursuitSpeed = donut.TargetSpeed;
        PlayerPrefs.SetInt("ChosenUpgrade", 5);
	}

	// Update is called once per frame
	void FixedUpdate() {

		Ray ray = new Ray();
		RaycastHit hit;
		targetAltitude = 0;
		int hitCount = 0;
		for (int i = 0, rayCount = 8; i < rayCount; ++i) {
			ray.origin = transform.position + new Vector3(16, 16);
			float angle = (1f - Mathf.Cos(i * 3.14f / rayCount)) / 2 * 3.14f - 0.1f;
			ray.direction = new Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0);

			if (Physics.SphereCast(ray, 5.0f, out hit, float.PositiveInfinity, 1 << 10 | 1 << 11)) {
				Debug.DrawLine(ray.origin, hit.point);
				float delta = Mathf.Max(hit.point.y - transform.position.y + 15, 0) * Mathf.Max(100 - hit.distance, 0) * 0.015f;
				if (delta > 0) {
					++hitCount;
					targetAltitude += delta;
				}
			}
			else {
				Debug.DrawRay(ray.origin, ray.direction * 500.0f);
			}
		}
		if (hitCount > 0) {
			targetAltitude /= hitCount;
			targetAltitude *= (1 + donut.rigidbody.velocity.magnitude / 50) / 2;
		}
		pursuitSpeed = donut.TargetSpeed * Mathf.Min(1, (Time.time - startTime) / PursuitDelay);
		Vector3 tmpDelta = donut.transform.position + new Vector3(0, targetAltitude) - transform.position;
        //this.light.intensity = 5.0f / tmpDelta.magnitude;
		float tmpX = tmpDelta.magnitude / CatchDistance;
		tmpX -= 2;
		float currentSpeed = tmpX * tmpX * tmpX * 0.2f + 1;
		currentSpeed *= pursuitSpeed;
		Vector3 tmpVelocity = currentSpeed * Time.fixedDeltaTime * tmpDelta.normalized * 1.1f;
		velocity = 0.95f * velocity + 0.05f * donut.rigidbody.velocity.magnitude;
		transform.rotation = Quaternion.Euler(0, 0, -0.4f * velocity + 20);

		if (((donut.transform.position - transform.position).magnitude < CatchDistance) && (DonutCatchable)) {
			GameController.instance.donut.Death("Cops");
		}

		transform.position += tmpVelocity;
		
	}
}
