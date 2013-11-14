using UnityEngine;
using System.Collections;

public class ObjectPlacing : MonoBehaviour {

    public GameObject[] ObjectsToPlace;
    public float LifeTime = 70.0f;

    void Start()
    {
        Destroy(this.gameObject);
    }

    public void Placing()
    {
        var Obj = Instantiate(ObjectsToPlace[Random.Range(0, ObjectsToPlace.GetLength(0))], this.transform.position, Quaternion.identity) as GameObject;
        Destroy(Obj, LifeTime);
    }
    public void CPlacing()
    {
        Placing();
    }
    public void BPlacing()
    {
        Placing();
    }
    public void OPlacing()
    {
        Placing();
    }
}
