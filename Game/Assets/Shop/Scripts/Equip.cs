using UnityEngine;
using System.Collections;

public class Equip : MonoBehaviour {

    public int id;

    void OnMouseUp()
	{
		FlurryManager.instance.Button ("Equip");
        PlayerPrefs.SetInt("ChosenUpgrade", id);
        PlayerPrefs.Save();
    }
}
