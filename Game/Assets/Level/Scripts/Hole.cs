using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        RigidDonut donut;
        if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null)
        {
            Debug.Log("Fallen one");
            donut.Fall();
        }
    }
}
