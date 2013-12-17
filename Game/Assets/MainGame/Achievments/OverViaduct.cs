using UnityEngine;
using System.Collections;

public class OverViaduct : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Donut donut;
        if ((donut = other.gameObject.GetComponent<Donut>()) != null)
        {
            donut.achieve.over = true;
        }
    }
}
