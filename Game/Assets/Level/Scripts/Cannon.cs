using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

    public float ShootingTime;
    public float WaitingTime;
    void Start()
    {
        StartCoroutine("ShootAndWait");
    }


    IEnumerator ShootAndWait()
    {
        while (true)
        {
            this.particleSystem.enableEmission = true;
            yield return new WaitForSeconds(ShootingTime * Random.Range(0.5f,1.5f));
            this.particleSystem.enableEmission = false;
            yield return new WaitForSeconds(WaitingTime * Random.Range(0.5f, 1.5f));
        }
    }
}
