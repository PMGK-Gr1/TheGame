using UnityEngine;
using System.Collections;

public class Facebook : MonoBehaviour {

    void OnMouseUp()
    {
        Application.OpenURL("http://www.facebook.com");
    }
}
