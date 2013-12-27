using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {


    public Sprite[] sprite;
    public GameObject ChocolateRainParticle;
    public GameObject SpeedParticle;


    public Pursuit pursuit;
    public float speed;



    private Donut donut;

	// Use this for initialization
	void Start () {
        donut = GameController.instance.donut;
        speed = 3000.0f;

        donut.upgrade = PlayerPrefs.GetInt("ChosenUpgrade");
        donut.upgradeCount = PlayerPrefs.GetInt("Upgrade" + donut.upgrade.ToString());

        SpeedParticle.particleSystem.Stop();
        ChocolateRainParticle.particleSystem.enableEmission = false;


        this.GetComponent<SpriteRenderer>().sprite = sprite[donut.upgrade];
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        FindObjectOfType<Jumper>().canjump = false;
        if((!(FindObjectOfType<PauseButton>().paused))&&(donut.upgradeCount>0))
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
                case 3:
                    donut.SticykDonut(10);
                    donut.upgradeCount--;
                    break;
                case 4:
                    StartCoroutine("Marmolade");
                    donut.upgradeCount--;
                    if (donut.isFrosted) donut.achieve.VerySweet();
                    break;
            }


        }


    }

    void OnMouseUp()
    {
        FindObjectOfType<Jumper>().canjump = true;
    }


    IEnumerator ChocolateRain()
    {
        GameController.instance.chocolateRain = true;
        ChocolateRainParticle.particleSystem.enableEmission = true;
		ChocolateRainParticle.particleSystem.Play();

        yield return new WaitForSeconds(3.0f);

		ChocolateRainParticle.particleSystem.Stop();
        ChocolateRainParticle.particleSystem.enableEmission = false;
        GameController.instance.chocolateRain = false;
    }

    IEnumerator Marmolade()
    {
        while (true)
        {
            pursuit.pursuitSpeed /= 2;
            Debug.Log("Slower pursuit");
            yield return new WaitForSeconds(3.0f);
            break;
        }
        pursuit.pursuitSpeed *= 2;
        Debug.Log("Faster pursuit");
    }


    void SpeedBoost()
    {
        SpeedParticle.particleSystem.Play();

        donut.rigidbody.AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        if (donut.isBurnt) donut.achieve.BurntandSpeed();
    }
}
