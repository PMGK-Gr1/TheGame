using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	public GameObject particlesOnHit;


    private Rigidbody[] parts = new Rigidbody[9];
    public Vector3[] partspositions;
    public Quaternion[] partsrotations;


    void Awake()
    {
        parts = GetComponentsInChildren<Rigidbody>();

        partspositions = new Vector3[parts.Length];
        partsrotations = new Quaternion[parts.Length];
        for (int i = 0; i < parts.Length; i++)
        {

            partspositions[i] = parts[i].transform.localPosition;
            partsrotations[i] = parts[i].transform.localRotation;
        }
    }
    public void reset()
    {
        for (int i = 0; i < parts.Length; i++)
        {
           // parts[i].gameObject.SetActive(true);
            parts[i].transform.localPosition = partspositions[i];
            parts[i].transform.localRotation = partsrotations[i];
            parts[i].constraints = RigidbodyConstraints.FreezeAll;
            parts[i].velocity = Vector3.zero;
            parts[i].angularVelocity = Vector3.zero;
            parts[i].Sleep();
        }
        
    }

 

    /*
    void Awake()
    {
        parts = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < parts.Length; i++)
        {
   
            partspositions[i] = parts[i].transform.localPosition;
        }
    }

	void Start()
	{
        
		this.GetComponentInChildren<ParticleSystem>().enableEmission = false;

	}

    */
    
	void FixedUpdate()
	{
		if (GameController.instance.chocolateRain) {
			foreach(Transform child in this.transform){
				if(child.rigidbody != null)
					child.rigidbody.WakeUp(); 
			}
			//Destroy(this);
		}
	}
    
    void OnEnable()
    {
        reset();
    }
    void OnTriggerEnter(Collider other)
    {
        Donut donut;


        if ((donut = other.gameObject.GetComponent<Donut>()) != null)
        {
            donut.BillboardHit();
            var parts = GetComponentsInChildren<Rigidbody>();
           foreach (var part in parts) if(part.name!="Pales")  {part.constraints = RigidbodyConstraints.None; part.Sleep(); }
			particlesOnHit.transform.position = new Vector3(transform.position.x, other.transform.position.y, other.transform.position.z);
			particlesOnHit.particleSystem.Emit(100);
            //this.enabled = false;
        }
    }

}
