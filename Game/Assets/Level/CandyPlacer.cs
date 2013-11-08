using UnityEngine;
using System.Collections;

/// <summary>
/// This script places random number of candies over a block. 
/// At the moment, candies are only placed in straight line.
/// </summary>

public class CandyPlacer : MonoBehaviour
{
    //public variables
    public GameObject Candy;
    public int MaxCandiesPerBlock = 5;

    // Use this for initialization
    void Start()
    {

        int tmpCandyQuantity = Random.Range(0, MaxCandiesPerBlock+1);
        if (tmpCandyQuantity != 0)
        {
            for (int i = 0; i < tmpCandyQuantity; i++)
            {
                float candyPositionX = (this.collider.bounds.size.x / tmpCandyQuantity) * i + this.transform.position.x - ((this.transform.localScale.x) / 2) + Candy.transform.localScale.x;
                float candyPositionY = this.collider.bounds.size.y + 0.5f + this.transform.position.y;
                var tmpNewCandy = Instantiate(Candy, new Vector3(candyPositionX, candyPositionY, 0), Quaternion.identity) as GameObject;
                Destroy(tmpNewCandy, 7f);
            }
        }

    }
}
