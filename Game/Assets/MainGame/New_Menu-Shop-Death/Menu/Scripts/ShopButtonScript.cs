using UnityEngine;
using System.Collections;

public class ShopButtonScript : MonoBehaviour {
    public Controller control;

    public bool active = true;
	// Use this for initialization
	void Start () {
        this.guiTexture.pixelInset = new Rect(0.8f * (float)Screen.width,
               0.45f * (float)Screen.height,
               (240.0f / 1676.0f) * (float)Screen.width,
               (240.0f / 1013.0f) * (float)Screen.height);
	}


    void OnMouseUp() {
        if (active)
        {
            FlurryManager.instance.Button("Shop");
            if (!control.optionsOn) control.ToShop();
            control.inshop = true;
        }
    }
}
