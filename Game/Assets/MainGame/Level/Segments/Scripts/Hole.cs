using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Donut donut;
        if ((donut = other.gameObject.GetComponent<Donut>()) != null)
        {
            donut.Fall();
            PlayerPrefs.SetInt("FallIntoHole", PlayerPrefs.GetInt("FallIntoHole") + 1);
            if (PlayerPrefs.GetInt("FallIntoHole") == 10) donut.achieve.Fall10();
        }
    }
}
