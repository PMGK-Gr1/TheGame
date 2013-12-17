using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject particlesOnHit;

	void Start()
	{
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}

	void FixedUpdate()
	{
		if (GameController.instance.chocolateRain) {
			foreach(Transform child in this.transform){
				if(child.rigidbody != null)
					child.rigidbody.WakeUp(); 
			}
			Destroy(this);
		}
	}

    void OnTriggerEnter(Collider other)
    {
        Donut donut;


        if ((donut = other.gameObject.GetComponent<Donut>()) != null)
        {
            donut.BillboardHit();
			particlesOnHit.transform.position = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
			particlesOnHit.particleSystem.Emit(100);
            this.enabled = false;
        }
    }

}
