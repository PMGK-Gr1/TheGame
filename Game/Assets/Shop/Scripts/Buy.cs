using UnityEngine;
using System.Collections;

public class Buy : MonoBehaviour {
	
	public FlurryManager flurry;
	public int price;
    public int id;
	public string name;

    void OnMouseUp()
	{
		flurry.SendMessage ("Button", "Buy");
        if(PlayerPrefs.GetInt("Sugar") >= price)
        {
            PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") - price);
            PlayerPrefs.SetInt("Upgrade"+id.ToString(), PlayerPrefs.GetInt("Upgrade"+id.ToString()) + 1);
			flurry.SendMessage("ByeByeMoney", price);
			flurry.SendMessage("UpgradeBought", name);
        }
    }
	
	}

