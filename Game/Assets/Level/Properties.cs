using UnityEngine;
using System.Collections;


/// <summary>
/// This script provides information about coordinate Y of the next prefab. 
/// Possibly, it may provide some other information in the future.
/// </summary>
public class Properties : MonoBehaviour {

    //public variables
    public float NextY;
    public int Type;


	// Use this for initialization
	void Start () {

        switch (Type)
        {
            case 1:
                NextY = 0;
                break;
            case 2:
                NextY = 0;
                break;
            case 3:
                NextY = (-1) * (this.collider.bounds.size.y) / 2;
                break;
            default:
                NextY = 0;
                break;
        }
	}
}
