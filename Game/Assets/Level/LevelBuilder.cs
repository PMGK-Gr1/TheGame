using UnityEngine;
using System.Collections;

public class LevelBuilder : MonoBehaviour {


    public GameObject LevelPrefab;
    GameObject current;
    GameObject next;

 

	// Use this for initialization
	void Start () {

        current = Instantiate(LevelPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
        current.layer = 9;
        Vector3 nextVector = new Vector3(current.transform.localScale.x,0,0);
        next = Instantiate(LevelPrefab, nextVector, Quaternion.identity) as GameObject;
        next.layer = 9;

	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (this.transform.position.x > (next.transform.position.x - ((next.transform.localScale.x)/3) ))
        {
            float nextPositionX = next.transform.position.x + next.transform.localScale.x - 0.2f;
            float nextPositionY = next.transform.position.y + Random.Range(-2.0f, 2.0f);
            Destroy(current);
            current = next;
            next = Instantiate(LevelPrefab, new Vector3(nextPositionX, nextPositionY, 0), Quaternion.identity) as GameObject;
            next.layer = 9;
        }
        
    }
}
