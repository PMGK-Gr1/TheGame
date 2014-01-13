using UnityEngine;
using System.Collections;

public class Buy : MonoBehaviour {

	public int price;
    public int id;
	public string name;

    void OnMouseUp()
	{
		FlurryManager.instance.SendMessage ("Button", "Buy");
        if(PlayerPrefs.GetInt("Sugar") >= price)
        {
            PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") - price);
            PlayerPrefs.SetInt("Upgrade"+id.ToString(), PlayerPrefs.GetInt("Upgrade"+id.ToString()) + 1);
			//FlurryManager.instance.UpgradeBought(name, price);
        }
    }
	
	}

