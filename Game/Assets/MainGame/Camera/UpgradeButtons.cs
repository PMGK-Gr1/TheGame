using UnityEngine;
using System.Collections;


/// <summary>
/// In fact, all buttons in main scene
/// </summary>
public class UpgradeButtons : MonoBehaviour {
    private Donut donut;

	public Pursuit pursuit;
	public Donut dount;
	public float speed;
	public GameObject ChocolateRainParticle;
	public GameObject SpeedParticle;
    public Texture PauseButton;
    
    public bool jump = true;
    private int upgrade;
    private string upgradebutton;
    bool pausebuttons = false;
    void Start()
    {

        donut = GameController.instance.donut;
		speed = 1000.0f;
        donut.upgrade = PlayerPrefs.GetInt("ChosenUpgrade");
        donut.upgradeCount = PlayerPrefs.GetInt("Upgrade" + donut.upgrade.ToString());

		SpeedParticle.particleSystem.Stop();
        switch(donut.upgrade)
        {
            case 1:
                upgradebutton = "Chocolate rain ";
                break;
            case 2:
                upgradebutton = "Speed boost ";
                break;
            default:
                upgradebutton = "Upgrade";
                    break;
        }

		ChocolateRainParticle.particleSystem.enableEmission = false;
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
        button1.width =/* button2.width = button3.width = */Screen.width * 0.35f;

            if ((!pausebuttons) && (GUI.Button(button1, upgradebutton + donut.upgradeCount.ToString())))
            {
                


                /*if (donut.upgradeCount > 0)
                {
                    switch (donut.upgrade)
                    {
                        case 0:
                            break;
                        case 1:
                            StartCoroutine("ChocolateRain");		//Let it rain
                            donut.chocoRains++;
                            donut.upgradeCount--;
                            break;
                        case 2:
                            SpeedBoost();
                            donut.upgradeCount--;
                            break;
                    }
                }*/
                donut.StickyDonut(10);	//Coins, coins and more coins               		
                //StartCoroutine("Marmolade");	//Pursuit is slower for 2 sec
                //if (donut.isFrosted) donut.achieve.VerySweet();		
            };
            // if (GUI.Button(button2, "Uprgade 2")) { };
            // if (GUI.Button(button3, "Uprgade 3")) { };

            // Rect button = new Rect(Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.1f, Screen.height * 0.1f);

            if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f), "menu")))
            {
               

                Time.timeScale = 1.0f;
                donut.Save();
                Application.LoadLevel(0);
            }

            if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f), "sound"))) { }
            if (pausebuttons && (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.1f), "music"))) { }



     

            else
            {



            }
        
    }

	IEnumerator ChocolateRain() {
		GameController.instance.chocolateRain = true;
		ChocolateRainParticle.particleSystem.enableEmission = true;

		yield return new WaitForSeconds(3.0f);
		ChocolateRainParticle.particleSystem.enableEmission = false;
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
		SpeedParticle.particleSystem.Play();

		donut.rigidbody.AddForce (new Vector3 (speed, 0, 0), ForceMode.Acceleration);
        if (donut.isBurnt) donut.achieve.BurntandSpeed();
	}

}
