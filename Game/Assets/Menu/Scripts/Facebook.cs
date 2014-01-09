using UnityEngine;
using System.Collections;

public class Facebook : MonoBehaviour {

	public FlurryManager flurry;

    void OnMouseUp()
    {
		flurry.SendMessage ("Button", "Facebook");
        Application.OpenURL("http://www.facebook.com/pages/Donut-Madness/343761999100579");
    }
}
