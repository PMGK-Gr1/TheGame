using UnityEngine;
using System.Collections;

public class UpgradeButtons : MonoBehaviour {
    private RigidDonut donut;

	public Pursuit pursuit;
	public RigidDonut dount;
	public float speed;
	
    void Start()
    {
        donut = RigidDonut.instance;
		speed = 1000.0f;
    }
    void OnGUI()
    {
        Rect button1 = new Rect();
       // Rect button2 = new Rect();
       // Rect button3 = new Rect();

        button1.x = Screen.width * 0.25f;
        button1.y = Screen.height * 0.8f;
       // button2.x = Screen.width * 0.45f;
      //  button2.y = Screen.height * 0.8f;
      //  button3.x = Screen.width * 0.65f;
      //  button3.y = Screen.height * 0.8f;
        button1.height =/* button2.height = button3.height =*/ Screen.height * 0.1f;
        button1.width =/* button2.width = button3.width = */Screen.width * 0.2f;

        if(GUI.Button(button1, "Uprgade"))  {
            //donut.SticykDonut(10);	//Coins, coins and more coins
			//StartCoroutine("ChocolateRain");		//Let it rain
			//StartCoroutine("Marmolade");	//Pursuit is slower for 2 sec
			SpeedBoost();			//speeeeeeeeed
        };
       // if (GUI.Button(button2, "Uprgade 2")) { };
       // if (GUI.Button(button3, "Uprgade 3")) { };

    }

	IEnumerator ChocolateRain() {
		GameController.instance.chocolateRain = true;
		yield return new WaitForSeconds(3.0f);
		GameController.instance.chocolateRain = false;
	}

	IEnumerator Marmolade() {
		while (true) {
					pursuit.pursuitSpeed /= 2;
					Debug.Log ("Slower pursuit");
					yield return new WaitForSeconds (3.0f);
					break;
				}
		pursuit.pursuitSpeed *= 2;
		Debug.Log ("Faster pursuit");
	}

	
	void SpeedBoost() {
		donut.rigidbody.AddForce (new Vector3 (speed, 0, 0), ForceMode.Acceleration);
	}
}
