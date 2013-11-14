using UnityEngine;
using System.Collections;

public class ObjectPlacing : MonoBehaviour {

    public GameObject[] ObjectsToPlace;
    public float LifeTime = 70.0f;

    public void Placing()
    {

        var Obj = Instantiate(ObjectsToPlace[Random.Range(0, ObjectsToPlace.GetLength(0))], this.transform.position, Quaternion.identity) as GameObject;
        Destroy(Obj, LifeTime);
    }
}
