using UnityEngine;
using System.Collections;

public class OptionsButton : MonoBehaviour {
	
	public FlurryManager flurry;

    public GameObject Camera;
    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Options");
        Camera.GetComponent<Options>().MoveAway();
    }
}
