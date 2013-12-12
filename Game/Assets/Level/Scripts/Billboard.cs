using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject particlesOnHit;

	void Start()
	{
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
	}

	void Update()
	{
		if (GameController.instance.chocolateRain) {
			//TODO destroying billboards
			//foreach(Transform child in transform){
				//child.gameObject.rigidbody.WakeUp(); 
			//}
		}
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
