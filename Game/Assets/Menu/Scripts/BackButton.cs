using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public FlurryManager flurry;

    public GameObject Camera;
    void OnMouseUp()
    {      
		flurry.SendMessage ("Button", "Back");
        Camera.GetComponent<Options>().ComeBack();
    }
}
