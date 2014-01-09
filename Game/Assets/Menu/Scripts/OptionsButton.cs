using UnityEngine;
using System.Collections;

public class OptionsButton : MonoBehaviour {

    public GameObject Camera;
    void OnMouseUp()
    {
		FlurryManager.instance.Button ("Options");
        Camera.GetComponent<Options>().MoveAway();
    }
}
