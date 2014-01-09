using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {
	
	public FlurryManager flurry;

    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Shop");
        Application.LoadLevel(3);
    }
}
