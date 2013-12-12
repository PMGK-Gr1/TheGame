using UnityEngine;
using System.Collections;

public class OverViaduct : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        RigidDonut donut;
        if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null)
        {
            donut.achieve.over = true;
        }
    }
}
