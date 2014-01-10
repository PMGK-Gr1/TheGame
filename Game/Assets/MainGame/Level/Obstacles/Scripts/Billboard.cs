using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject particlesOnHit;
	public Material[] materials;

	void Start()
	{
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;
		Material mat = materials[Random.Range(0, 5)];
		for (int i = 0; i < 8; ++i) {
			transform.GetChild(i).gameObject.renderer.material = mat;
		}
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
			gameObject.GetComponent<AudioSource>().Play();
			particlesOnHit.transform.position = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
			particlesOnHit.particleSystem.Emit(100);
            this.enabled = false;
        }
    }

}
