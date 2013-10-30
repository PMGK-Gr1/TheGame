using UnityEngine;
using System.Collections;

public class LevelBuilder : MonoBehaviour {

    int x = 0;
    GameObject currentObject;
    GameObject nextObject;
    int blocks = 0;
	// Use this for initialization
	void Start () {
        currentObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        currentObject.name = blocks.ToString();
        blocks++;
        currentObject.layer = 9;
        currentObject.transform.localScale = new Vector3(5, 1, 1);
        currentObject.transform.position = new Vector3(x, Random.Range(-0.5f, 0.5f), 0);
        float nextPosition = currentObject.transform.position.x + currentObject.transform.localScale.x;
        nextObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        nextObject.name = blocks.ToString();
        blocks++;
        nextObject.transform.localScale = new Vector3(5, 1, 1);
        nextObject.layer = 9;

        nextObject.transform.position = new Vector3(nextPosition, Random.Range(-0.5f, 0.5f), 0);
        x++;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (this.transform.position.x > nextObject.transform.position.x)
        {
            float nextPosition = nextObject.transform.position.x + nextObject.transform.localScale.x;
            float nextHeight = nextObject.transform.position.y;
            Destroy(currentObject);
            currentObject = nextObject;

           nextObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
           nextObject.name = blocks.ToString();
           blocks++;
           nextObject.layer = 9;

           nextObject.transform.localScale = new Vector3(5, 1, 1);
           nextObject.transform.position = new Vector3(nextPosition, nextHeight + Random.Range(-0.5f, 0.5f), 0);
            x++;

        }

	}
}
