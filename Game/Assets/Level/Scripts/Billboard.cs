using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject particlesOnHit;

	void Load()
	{

	}

	void Update()
	{
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}

    void OnTriggerEnter(Collider other)
    {
        RigidDonut donut;


        if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null)
        {
            donut.BillboardHit();
			particlesOnHit.transform.position = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
			particlesOnHit.particleSystem.Emit(100);
            this.enabled = false;
        }
    }

}
