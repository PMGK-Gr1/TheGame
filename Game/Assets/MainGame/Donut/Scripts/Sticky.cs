using UnityEngine;
using System.Collections;

public class Sticky : MonoBehaviour {

    public float Radius = 60.0f;
    public float Speed = 2.0f;
    private RigidDonut donut;
    

	void Start() {
        this.GetComponent<SphereCollider>().radius = Radius;
		donut = RigidDonut.instance;
	}
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Sugar")
        {
            other.transform.position = Vector3.MoveTowards(other.transform.position, donut.transform.position, Speed);
        }
    }
}
