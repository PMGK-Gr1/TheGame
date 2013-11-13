using UnityEngine;
using System.Collections;

/// <summary>
/// Donut on drugz
/// </summary>

public class Booster : MonoBehaviour {

    //public variables
    public GameObject Donut;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boost")
        {
            Debug.Log(Localization.getText("BOOST"));
            Donut.rigidbody.AddForce(Vector3.right * 10000, ForceMode.Impulse);
            Destroy(other.gameObject);
            
        }

    }
	
}
