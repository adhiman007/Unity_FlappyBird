using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public AudioClip playDamageSuond;

	public float flapSpeed = 100f;
	public float forwardSpeed =1f;

	bool didFlap = false;
	bool crash = true;
	public bool dead = false;

	Animator animator;

	float deathCooldown ;

	public bool godMode = false;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		if(animator == null){
			Debug.LogError("Didnt find animator");
		}

	}

	// Do Graphic & Input updates here
	void Update(){

		if (dead) {
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0){
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
					didFlap = true;
				}
			}
		}

		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			didFlap = true;

		}

	}

	// Update is called once per frame
	void FixedUpdate () {

		if (dead) {
			return;
		}


		rigidbody2D.AddForce(Vector2.right * forwardSpeed);

		if(didFlap){
			rigidbody2D.AddForce(Vector2.up * flapSpeed);
			animator.SetTrigger("DoFlap");

			didFlap = false;
		}

		if (rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler(0,0,0);
		}else{

			float angle = Mathf.Lerp(0,-90, -(rigidbody2D.velocity.y) / 3f);
			transform.rotation = Quaternion.Euler(0,0,angle);
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		if(godMode){
			return;
		}

		animator.SetTrigger("Death");
		dead = true;
		deathCooldown = 0.5f;

		if(crash){
			GameObject.Find("EndScreen").SendMessage("GameOver", SendMessageOptions.DontRequireReceiver);
			GameObject.Find("ReStartScreen").SendMessage("reStart", SendMessageOptions.DontRequireReceiver);
			crash = false;
		}

	}
}
