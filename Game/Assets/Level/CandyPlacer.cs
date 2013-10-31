using UnityEngine;
using System.Collections;

public class CandyPlacer : MonoBehaviour {

    public GameObject candy;
    public int maxCandiesPerBlock = 5;
 
	// Use this for initialization
	void Start () {

        int candyQuantity = Random.Range(0, maxCandiesPerBlock);
        if (candyQuantity!=0)
        {
            for (int i = 0; i < candyQuantity; i++)
            {
                float candyPositionX = (this.transform.localScale.x / candyQuantity) * i + this.transform.position.x - ((this.transform.localScale.x)/2) + candy.transform.localScale.x;
                float candyPositionY = this.transform.localScale.y / 2 + 0.5f + this.transform.position.y;
                var newCandy = Instantiate(candy, new Vector3(candyPositionX, candyPositionY , 0), Quaternion.identity) as GameObject;
                Destroy(newCandy, 7f);
            }
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
