using UnityEngine;
using System.Collections;

public class ReturnButtonScript : MonoBehaviour {
    
    
    public Controller control;

    public bool active = true;

	// Use this for initialization
	void Start () {
	this.guiTexture.pixelInset = new Rect(
            Screen.width * 0.65f,
            Screen.height * 0.3f,
            Screen.width * 0.3f,
            Screen.width * 0.1f);
	
	}

    void OnMouseUp() {
        if (active)
        {
            FlurryManager.instance.Button("ShopReturn");
            FlurryManager.instance.CandiesSpent();
            control.BackToMenu();
            control.inshop = false;
        }
    }
}
