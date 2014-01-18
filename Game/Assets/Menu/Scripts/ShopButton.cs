using UnityEngine;
using System.Collections;

public class ShopButton : MonoBehaviour {

    void OnMouseUp()
    {
		FlurryManager.instance.Button ("Shop");
        LoadingScreen.LoadLevel(3);
    }
}
