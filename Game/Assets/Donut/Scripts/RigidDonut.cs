using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class RigidDonut : MonoSingleton<RigidDonut> {

	//public variables
	public float TargetSpeed = 20.0f;
	public float InstantJumpForce = 1000.0f;
	public float LongJumpForce = 500.0f;
	public bool IsTouchingGround = false;
	public float JumpLength = 1.0f;
	public bool GodMode = false;
    public GameObject Score;
    public GameObject Distance;
    public GameObject Sticky;
    public Achievements achieve;
    public int sugarCubes = 0;
    public int billboardHits = 0;
	public GameObject explosionParticle;
	public GameObject smokeParticle;
	public bool stingerDisabled;
    //private variables
	
	private bool isAlive = true;
	private enum state {JumpPossible = 0, JumpStarted = 1, JumpOnGoing =2, JumpNotPossible = 3}
	private state prevState = state.JumpNotPossible;
	private float cooldown;
	private float radius = 7;
	private Vector3 donutLastVelocity;
	private Vector3 donutLastLastVelocity;


	private int stingersResistLeft = 0;
	private int milkCannonResistLeft = 0;
	private bool secondLife = false;
	private int freshAsphaltResistLeft = 0;

    private bool isSticky = false;
    public bool isBurnt = false;
    public bool isFrosted = false;

    public int chocoRains = 0;

    public int slippyCount = 0;

    public int upgrade, upgradeCount;

	void Start()
	{
		explosionParticle.particleSystem.enableEmission = true;
		explosionParticle.particleSystem.Stop();

		smokeParticle.particleSystem.enableEmission = true;
		smokeParticle.particleSystem.Stop();
	}

    
	void FixedUpdate() {
		float force = 0.0f;
        Distance.guiText.text = ((int)transform.position.x/10).ToString() + " m";
		if(rigidbody != null)
		force = 50.0f / (1.0f + Mathf.Pow(2, this.rigidbody.velocity.x - TargetSpeed));
		//rigidbody.AddForceAtPosition(new Vector3(force, 0, 0), transform.position + new Vector3(0, 5f, 0), ForceMode.Acceleration);
		rigidbody.AddForce(new Vector3(force, 0, 0), ForceMode.Acceleration);
		donutLastLastVelocity = donutLastVelocity;
		donutLastVelocity = rigidbody.velocity;
		//rigidbody.angularVelocity = new Vector3(0, 0, -rigidbody.velocity.magnitude / radius);

	}


	void Update() {
		// Input moved to pdate to prevent ignoring some keystrokes
		prevState = GetJumpState ();
		if (prevState == state.JumpStarted) {
			rigidbody.AddForce(new Vector3(0, InstantJumpForce, 0), ForceMode.VelocityChange);
		}
		else if(prevState == state.JumpOnGoing){
			rigidbody.AddForce(new Vector3(0, LongJumpForce, 0), ForceMode.Acceleration);
		}

	}

	public void SugarPickup(int value) {
		sugarCubes += value;
        if (isSticky) achieve.stickyScore += value;
        Score.guiText.text = sugarCubes.ToString();
	}



	public void StingerHit() {
        if (!stingerDisabled) {
			achieve.DonutStinger ();
			if (stingersResistLeft > 0) {
				stingersResistLeft--;
				if (stingersResistLeft == 0)
					UnburntDonut ();
			} else
				Death ("Stinger");
		}
	}

    public void BillboardHit()
    {
        billboardHits++;
    }

	public void BurntDonut() {
		Debug.Log("I am hot tonight.");
        isBurnt = true;
		explosionParticle.particleSystem.Play();
		smokeParticle.particleSystem.Play();

		stingersResistLeft = 3;
	}

	void UnburntDonut() {
		Debug.Log("I am no longer burnt.");
        isBurnt = false;
		// TODO reverse the effects
		explosionParticle.particleSystem.Stop();
		smokeParticle.particleSystem.Stop();

	}


    public void Fall()
    {
        Death("Fall");
    }

	public void MilkCannonHit(Vector3 forceImpact) {

		if (milkCannonResistLeft > 0) {
			milkCannonResistLeft--;
			if (milkCannonResistLeft == 0) UnfrostDonut();
		}
		else {
			float force = 200;
			rigidbody.AddForce(forceImpact*force, ForceMode.Impulse);
		}
	}

	public void FrostDonut() {
		Debug.Log("I am double frosted ?!?.");
        isFrosted = true;
		// TODO nice pickup particle effect or some other spectacular thingy
		freshAsphaltResistLeft = 3;
	}

	void UnfrostDonut() {
		Debug.Log("I am no longer frosted.");
        isFrosted = false;
		// TODO reverse the effects
	}


    public void SticykDonut(float t)
    {
        achieve.stickyScore = 0;
        isSticky = true;
        Debug.Log("Come to me, my dear sugar");
        StartCoroutine("StickyTime", t);
    }

    IEnumerator StickyTime(float t)
    {
        Sticky.GetComponent<SphereCollider>().enabled = true;
        yield return new WaitForSeconds(t);
        UnstickyDonut();
    }
           
    void UnstickyDonut() 
    {
        isSticky = false;
       Debug.Log("well... ");
       Sticky.GetComponent<SphereCollider>().enabled = false;
            
    }



	public void GiveSecondLife() {
		Debug.Log("I've got a second life.");
		// TODO nice pickup particle effect or some other spectacular thingy
		milkCannonResistLeft = 3;
	}

	void Rebirth() {
		secondLife = false;
        achieve.DonutRebirth();
		Debug.Log("I died, but only temporally.");
        achieve.fiveseconds = true;
        StartCoroutine("fiveseconds");
		// TODO some epic rebirth effect
	}

    IEnumerator fiveseconds()
    {
        yield return new WaitForSeconds(5.0f);
        achieve.fiveseconds = false;
    }

	public bool FreshAsphalt() {
		Debug.Log ("Oops, fresh asphalt");
		if (freshAsphaltResistLeft > 0) {
						freshAsphaltResistLeft--;
			if(freshAsphaltResistLeft == 0) {
				UnfrostDonut();
			}
			return false;
		}
		return true;
	}

	public void Viaduct() {
		Debug.Log ("Oops, viaduct");
		Destroy (GetComponent("SphereCollider"));
		InteractiveCloth cloth = gameObject.AddComponent<InteractiveCloth> () as InteractiveCloth;
		cloth.pressure = 1.0f;
		cloth.stretchingStiffness = 0.5f;
		cloth.bendingStiffness = 0.5f;
		gameObject.AddComponent ("ClothRenderer");
		GetComponent<ClothRenderer> ().material = GetComponent<MeshRenderer>().material;
		Destroy (GetComponent("MeshRenderer"));
		cloth.mesh = (GetComponent<MeshFilter> () as MeshFilter).mesh;
		Destroy (GetComponent<MeshFilter> ());
		cloth.density = 1.0f;
		cloth.externalAcceleration = donutLastLastVelocity;
		rigidbody.drag = 0.0f;
		Death ("Viaduct");
	}

	void DisableStinger() {
		stingerDisabled = true;
	}

	void EnableStinger() {
		stingerDisabled = false;
	}

	public void Death(string Cause) {
		if (!isAlive) return; // prevent killing multiple times
		if (secondLife && Cause != "Cops") {
			Rebirth();
			return;
		}
		isAlive = false;
        achieve.death = true;
		Debug.Log(Localization.getText("DEAD"));
		if(!GodMode) Application.LoadLevel(2);
		PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") + sugarCubes);
        PlayerPrefs.SetInt("TotalSugarEver", PlayerPrefs.GetInt("TotalSugarEver") + sugarCubes);
        PlayerPrefs.SetInt("TotalDistance", PlayerPrefs.GetInt("TotalDistance") + (int)(transform.position.x / 10));
        PlayerPrefs.SetInt("TotalBillboardHits", PlayerPrefs.GetInt("TotalBillboardHits") + billboardHits);
        PlayerPrefs.SetInt("ChocalateRains", PlayerPrefs.GetInt("ChocalateRains") + chocoRains);
        PlayerPrefs.SetInt("Upgrade"+upgrade.ToString(), upgradeCount);
        PlayerPrefs.SetInt("LastDistance", (int)(transform.position.x / 10));
        PlayerPrefs.SetInt("LastSugar", sugarCubes);
		PlayerPrefs.Save();
	}

	bool jump ()
    {
		return ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space));
	}

	bool jumpHigher()
	{
		return ((Input.touchCount > 0)// && Input.touches[0].phase == TouchPhase.Stationary)
		        || Input.GetKey(KeyCode.Space));
	}

	state GetJumpState()
	{
		if(prevState == state.JumpPossible && jump())
		{
			return state.JumpStarted;
		}
		if((prevState == state.JumpStarted || prevState == state.JumpOnGoing) && jumpHigher() && cooldown > 0)
		{
			cooldown -= Time.deltaTime;
			return state.JumpOnGoing;
		}
		cooldown = JumpLength;
		if(IsTouchingGround && (prevState == state.JumpNotPossible || prevState == state.JumpPossible))
		{
			return state.JumpPossible;
		}
		if(!IsTouchingGround && prevState == state.JumpPossible)
		{
			return state.JumpNotPossible;
		}


		return state.JumpNotPossible;
	}

}
