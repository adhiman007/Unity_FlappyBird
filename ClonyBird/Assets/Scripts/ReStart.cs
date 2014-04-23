using UnityEngine;
using System.Collections;

public class ReStart : MonoBehaviour {

	BirdMovement bird;
	static bool isGame = true;
	
	void Start () {
		
		if(isGame){
			GetComponent<SpriteRenderer>().enabled = false;
		}
		bird = GameObject.Find("PlayerBird").GetComponent<BirdMovement>();
	}
	
	void reStart(){	
		if(bird.dead){
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	void Update () {
		if(bird.dead && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))){

			Application.LoadLevel("scene");
		}
	}
}
