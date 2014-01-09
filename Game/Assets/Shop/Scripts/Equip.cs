using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour {
	
	public FlurryManager flurry;
    public int id;

    void OnMouseUp()
	{
		flurry.SendMessage ("Button", "Equip");
        PlayerPrefs.SetInt("ChosenUpgrade", id);
        PlayerPrefs.Save();
    }
}
