﻿using UnityEngine;
using System.Collections;


/// <summary>
/// Moving donut.
/// </summary>
public class Donut : MonoBehaviour{

	//public variables
	public float TargetSpeed = 20.0f;
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

	public Material normalMat;
	public Material burntMat;
	public Material sugarMat;

    //private variables
	
	private bool isAlive = true;
	private Vector3 donutLastVelocity;
	private Vector3 donutLastLastVelocity;


	private int stingersResistLeft = 0;
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

		this.renderer.material = normalMat;
	}

    
	void FixedUpdate() {
		if (isAlive) {
			float force = 0.0f;
			Distance.guiText.text = ((int)GetDistanceTravelled()).ToString() + " m";

			force = 50.0f / (1.0f + Mathf.Pow(2, this.rigidbody.velocity.x - TargetSpeed));
			rigidbody.AddForce(new Vector3(force, 0, 0), ForceMode.Acceleration);
			donutLastLastVelocity = donutLastVelocity;
			donutLastVelocity = rigidbody.velocity;
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
					UnburntDonut();
			}
			else {
				Death("Stinger");
			}
		}
	}

    public void BillboardHit()
    {
        billboardHits++;
    }

	public void BurntDonut() {
        isBurnt = true;
		explosionParticle.particleSystem.Play();
		smokeParticle.particleSystem.Play();
		stingersResistLeft = 3;
		this.renderer.material = burntMat;
	}

	void UnburntDonut() {
        isBurnt = false;
		// TODO reverse the effects
		explosionParticle.particleSystem.Stop();
		smokeParticle.particleSystem.Stop();
		this.renderer.material = normalMat;
	}


    public void Fall()
    {
        Death("Fall");
    }

	public void FrostDonut() {
		Debug.Log("I am double frosted ?!?.");
        isFrosted = true;
		// TODO nice pickup particle effect or some other spectacular thingy
		freshAsphaltResistLeft = 3;
		this.renderer.material = sugarMat;
	}

	void UnfrostDonut() {
		Debug.Log("I am no longer frosted.");
        isFrosted = false;
		// TODO reverse the effects
		this.renderer.material = normalMat;
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
		//Debug.Log("I've got a second life.");
		// TODO nice pickup particle effect or some other spectacular thingy
		secondLife = true;
	}

	void Rebirth() {
		secondLife = false;
        achieve.DonutRebirth();
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
		Death ("Viaduct");
	}

	IEnumerator Soften() {
		InteractiveCloth cloth = gameObject.AddComponent<InteractiveCloth>();
		cloth.pressure = 1.0f;
		cloth.stretchingStiffness = 0.5f;
		cloth.bendingStiffness = 0.5f;
		cloth.density = 1.0f;

		gameObject.AddComponent<ClothRenderer>();
		GetComponent<ClothRenderer>().material = GetComponent<MeshRenderer>().material;
		Destroy(GetComponent<MeshRenderer>());

		cloth.mesh = (GetComponent<MeshFilter>() as MeshFilter).mesh;
		Destroy(GetComponent<MeshFilter>());

		SphereCollider sphere = GetComponent<SphereCollider>();
		sphere.radius = 6.5f;
		cloth.AttachToCollider(sphere, false, true);
		cloth.attachmentResponse = 1;
		rigidbody.mass = 10;
		rigidbody.constraints = new RigidbodyConstraints();
		Vector3 vel = donutLastLastVelocity;

		for (int i = 0; i < 2; i++) {
			GameObject eye = transform.FindChild("Eye").gameObject; 
			eye.transform.parent = null;
			eye.AddComponent<SphereCollider>();
			eye.AddComponent<Rigidbody>();
			eye.rigidbody.velocity = vel + Vector3.Cross(transform.position - eye.transform.position, Vector3.forward) * rigidbody.angularVelocity.z;
			eye.layer = 8;
		}



		yield return new WaitForEndOfFrame();

		cloth.AddForceAtPosition(rigidbody.velocity, transform.position, 1000, ForceMode.VelocityChange);
		
		
	}

	public void Death(string Cause) {
		if (!isAlive) return; // prevent killing multiple times
		if (secondLife && Cause != "Cops") {
			Rebirth();
			return;
		}
		isAlive = false;
        achieve.death = true;
		if (Cause == "Viaduct" || Cause == "Stinger")
			StartCoroutine(this.Soften());

		Save();

		StartCoroutine(DelayDeath(4));
	}

	public void Save() {

		int distance = (int) GetDistanceTravelled();

		PlayerPrefs.SetInt("Sugar", PlayerPrefs.GetInt("Sugar") + sugarCubes);
		PlayerPrefs.SetInt("TotalSugarEver", PlayerPrefs.GetInt("TotalSugarEver") + sugarCubes);
		PlayerPrefs.SetInt("TotalDistance", PlayerPrefs.GetInt("TotalDistance") + distance);
		PlayerPrefs.SetInt("TotalBillboardHits", PlayerPrefs.GetInt("TotalBillboardHits") + billboardHits);
		PlayerPrefs.SetInt("ChocalateRains", PlayerPrefs.GetInt("ChocalateRains") + chocoRains);
		PlayerPrefs.SetInt("Upgrade" + upgrade.ToString(), upgradeCount);
		PlayerPrefs.SetInt("LastDistance", distance);
		PlayerPrefs.SetInt("LastSugar", sugarCubes);

		if (distance > PlayerPrefs.GetInt("HighestScore")) PlayerPrefs.SetInt("HighestScore", distance);
		PlayerPrefs.Save();
	}

	public float GetDistanceTravelled() {
		return transform.position.x / 10;
	}

	IEnumerator DelayDeath(float delay) {
		yield return new WaitForSeconds(delay);
		if (!GodMode) Application.LoadLevel(2);
	}



   
}