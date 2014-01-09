using UnityEngine;
using System.Collections;

public class Twitter : MonoBehaviour {

    void OnMouseUp()
    {
		FlurryManager.instance.Button ("Twitter");
        Application.OpenURL("http://www.twitter.com/donutmadness");
    }
}
