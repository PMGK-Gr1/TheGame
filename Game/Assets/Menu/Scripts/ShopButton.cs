using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {

    void OnMouseUp()
    {
		FlurryManager.instance.Button ("Shop");
        Application.LoadLevel(3);
    }
}
