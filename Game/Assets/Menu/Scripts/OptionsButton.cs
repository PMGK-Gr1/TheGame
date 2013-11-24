using UnityEngine;
using System.Collections;

public class OptionsButton : MonoBehaviour {


    public GameObject Camera;
    void OnMouseUp()
    {
        Camera.GetComponent<Options>().MoveAway();
    }
}
