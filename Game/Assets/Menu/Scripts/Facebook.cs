using UnityEngine;
using System.Collections;

public class Facebook : MonoBehaviour {

    void OnMouseUp()
    {
		FlurryManager.instance.Button ("Facebook");
        Application.OpenURL("http://www.facebook.com/pages/Donut-Madness/343761999100579");
    }
}
