using UnityEngine;
using System.Collections;

/// <summary>
/// This script places random number of candies over a block. 
/// At the moment, candies are only placed in straight line.
/// </summary>

public class SugarPlacer : MonoBehaviour
{
    //public variables
    public GameObject Sugar;
    public int MaxCandiesPerBlock = 5;

    // Use this for initialization
    void Start()
    {

        int tmpSugarQuantity = Random.Range(0, MaxCandiesPerBlock+1);
        if (tmpSugarQuantity != 0)
        {
            for (int i = 0; i < tmpSugarQuantity; i++)
            {
                float sugarPositionX = (this.collider.bounds.size.x / tmpSugarQuantity) * i + this.transform.position.x - ((this.transform.localScale.x) / 2) + Sugar.transform.localScale.x;
                float sugarPositionY = this.collider.bounds.size.y + 0.5f + this.transform.position.y;
                var tmpNewSugar = Instantiate(Sugar, new Vector3(sugarPositionX, sugarPositionY, 0), Quaternion.identity) as GameObject;
                Destroy(tmpNewSugar, 77f);
            }
        }

    }
}
