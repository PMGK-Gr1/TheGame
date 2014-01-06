using UnityEngine;
using System.Collections;

public class Buy : MonoBehaviour {

	public int price;
    public int id;

    void OnMouseUp()
    {
        if(PlayerPrefs.GetInt("Sugar") >= price)
        {
            PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") - price);
            PlayerPrefs.SetInt("Upgrade"+id.ToString(), PlayerPrefs.GetInt("Upgrade"+id.ToString()) + 1);
        }
    }
	
	}

