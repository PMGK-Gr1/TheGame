using UnityEngine;

public class Jumper : MonoBehaviour {

	public float InstantJumpForce = 1000.0f;
	public float LongJumpForce = 500.0f;
	public float JumpLength = 1.0f;

	private Donut donut;
	private enum JumpPhase { JumpPossible = 0, JumpStarted, JumpOnGoing, JumpNotPossible}
	private JumpPhase prevJumpPhase = JumpPhase.JumpNotPossible;
	private float cooldown;
	private bool isTouchingGround = false;

    public bool canjump = true;
	void Start() {
		donut = GameController.instance.donut;
	}

	void Update() {
		prevJumpPhase = GetJumpPhase();

   if(canjump){
		if (prevJumpPhase == JumpPhase.JumpStarted) {
			gameObject.GetComponent<AudioSource>().Play();
			donut.rigidbody.AddForce(new Vector3(0, InstantJumpForce, 0), ForceMode.VelocityChange);
		}
		else if (prevJumpPhase == JumpPhase.JumpOnGoing) {
			donut.rigidbody.AddForce(new Vector3(0, LongJumpForce, 0), ForceMode.Acceleration);
		}
		
       }
	}

	void FixedUpdate() {
		isTouchingGround = false;
	}


	bool CanJump() {
		return ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || Input.GetKeyDown(KeyCode.Space));
	}

	bool CanJumpHigher() {
		return ((Input.touchCount > 0)// && Input.touches[0].phase == TouchPhase.Stationary)
				|| Input.GetKey(KeyCode.Space));
	}


	JumpPhase GetJumpPhase() {
		if (prevJumpPhase == JumpPhase.JumpPossible && CanJump()) {
			return JumpPhase.JumpStarted;
		}
		if ((prevJumpPhase == JumpPhase.JumpStarted || prevJumpPhase == JumpPhase.JumpOnGoing) && CanJumpHigher() && cooldown > 0) {
			cooldown -= Time.deltaTime;
			return JumpPhase.JumpOnGoing;
		}
		cooldown = JumpLength;
		if (isTouchingGround && (prevJumpPhase == JumpPhase.JumpNotPossible || prevJumpPhase == JumpPhase.JumpPossible)) {
			return JumpPhase.JumpPossible;
		}
		if (!isTouchingGround && prevJumpPhase == JumpPhase.JumpPossible) {
			return JumpPhase.JumpNotPossible;
		}


		return JumpPhase.JumpNotPossible;
	}

	void OnTriggerEnter(Collider other) {
		if (collider.tag == "Ground") isTouchingGround = true;
	}

	void OnTriggerStay(Collider collider) {
		if (collider.tag == "Ground") isTouchingGround = true;
	}
}
