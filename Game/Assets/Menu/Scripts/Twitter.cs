using UnityEngine;
using System.Collections;

public class Twitter : MonoBehaviour {
	
	public FlurryManager flurry;

    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Twitter");
        Application.OpenURL("http://www.twitter.com/donutmadness");
    }
}
