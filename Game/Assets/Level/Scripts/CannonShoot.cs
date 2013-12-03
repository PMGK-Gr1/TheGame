using UnityEngine;
using System.Collections;

public class CannonShoot : MonoBehaviour {

	public GameObject Particles;

	public float ShootingTime;
	public float WaitingTime;

	void Start()
	{
		StartCoroutine("ShootAndWait");
	}

	void OnTriggerStay(Collider other) {
		RigidDonut donut;
		if (Particles.particleSystem.enableEmission)
		{
			if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null) {
				donut.MilkCannonHit(new Vector3(-1.5f, 0, 0));
				this.enabled = false;
			}
		}
	}

	IEnumerator ShootAndWait()
	{
		while (true)
		{
			Particles.particleSystem.enableEmission = true;
			yield return new WaitForSeconds(ShootingTime);
			Particles.particleSystem.enableEmission = false;
			yield return new WaitForSeconds(WaitingTime);
		}

	}
}