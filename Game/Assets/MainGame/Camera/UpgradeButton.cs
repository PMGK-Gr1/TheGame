using UnityEngine;
using System.Collections;

public class UpgradeButton : MonoBehaviour {


    public Texture[] sprite;
    public int[] cooldowns;
    public GameObject ChocolateRainParticle;
    public GameObject SpeedParticle;
    public GameObject MagnetParticle;

    private bool isCoolingdown = false;
    public Pursuit pursuit;
    public float speed;

    public GUIText CooldownCount;
    private Donut donut;

	// Use this for initialization

    void Awake()
    {
        donut = GameController.instance.donut;
        donut.upgrade = PlayerPrefs.GetInt("ChosenUpgrade");
        donut.upgradeCount = PlayerPrefs.GetInt("Upgrade" + donut.upgrade.ToString());
     




        CooldownCount.guiText.pixelOffset = new Vector2(Screen.width * 0.095f, Screen.height * 0.125f);
        CooldownCount.guiText.fontSize = (int)(Screen.height * 0.1f);
        CooldownCount.enabled = false;
    }

	void Start () {
        this.guiTexture.pixelInset = new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.height * 0.15f, Screen.height * 0.15f);
       
        speed = 3000.0f;

        

        SpeedParticle.particleSystem.Stop();
        ChocolateRainParticle.particleSystem.enableEmission = false;

        this.guiTexture.texture = sprite[donut.upgrade];
        //this.GetComponent<SpriteRenderer>().sprite = sprite[donut.upgrade];
	}
	

    void OnMouseDown() {
		FlurryManager.instance.Button("LaunchUpgrade");
        if (donut.upgrade > 0)
        {
            FindObjectOfType<Jumper>().canjump = false;
            if ((!(FindObjectOfType<PauseButton>().paused)) && (donut.upgradeCount > 0) && donut.isAlive && (!(isCoolingdown)))
            {

                switch (donut.upgrade)
                {
                    case 0:
                        break;
                    case 1:
                        StartCoroutine(ChocolateRain());		//Let it rain
                        donut.chocoRains++;
                        donut.upgradeCount--;
                        break;
                    case 2:
                        SpeedBoost();
                        donut.upgradeCount--;
                        break;
                    case 3:
                        donut.StickyDonut(10);
                        MagnetParticle.particleSystem.Play();
                        donut.upgradeCount--;
                        break;
                    case 5:
                        StartCoroutine(Marmolade());
                        donut.upgradeCount--;
                        if (donut.isFrosted) donut.achieve.VerySweet();
                        break;
                    case 4:
                        StartCoroutine(Ghost());
                        donut.upgradeCount--;

                        break;
				}
				FlurryManager.instance.UpgradeLaunch();
                StartCoroutine(Cooldown(cooldowns[donut.upgrade]));

            }

        }
       
    }

    IEnumerator Cooldown(int t)
    {
        isCoolingdown = true;
        this.guiTexture.color = new Color(0.05f, 0.05f, 0.05f, 0.2f);
        int c = t;
        CooldownCount.enabled = true;

        while (c >= 0)
        {
            CooldownCount.guiText.text = c.ToString();
           yield return new WaitForSeconds(1.0f);
            c--;
        }
        CooldownCount.guiText.text = "";
        CooldownCount.enabled = false;

        isCoolingdown = false;
        this.guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 0.35f);
        yield return null;
    }

    void OnMouseUp()
    {
        FindObjectOfType<Jumper>().canjump = true;
    }

    IEnumerator Ghost()
    {
        donut.Ghost();
        donut.renderer.material = donut.ghostMat;
        donut.gameObject.layer = 14;
        donut.pursuit.DonutCatchable = false;
        yield return new WaitForSeconds(5.0f);
        donut.renderer.material = donut.normalMat;
        donut.gameObject.layer = 8;
        donut.pursuit.DonutCatchable = true;

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
            //Debug.Log("Slower pursuit");
            yield return new WaitForSeconds(3.0f);
            break;
        }
        pursuit.pursuitSpeed *= 2;
        //Debug.Log("Faster pursuit");
    }


    void SpeedBoost()
    {
        SpeedParticle.particleSystem.Play();

        donut.rigidbody.AddForce(new Vector3(speed, 0, 0), ForceMode.Acceleration);
        if (donut.isBurnt) donut.achieve.BurntandSpeed();
    }
}
