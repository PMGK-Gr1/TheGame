using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

    public GameObject Camera;
    void OnMouseUp()
    {      

        Camera.GetComponent<Options>().ComeBack();
    }
}
