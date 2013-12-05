using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        RigidDonut donut;
        if ((donut = other.gameObject.GetComponent<RigidDonut>()) != null)
        {
            donut.BillboardHit();
            this.enabled = false;
        }
    }

}
