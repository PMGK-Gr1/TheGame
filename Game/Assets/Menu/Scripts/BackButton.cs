using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

    public GameObject Camera;
    void OnMouseUp()
    {      
		FlurryManager.instance.Button ("Back");
        Camera.GetComponent<Options>().ComeBack();
    }
}
