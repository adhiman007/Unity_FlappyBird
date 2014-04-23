using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;

	static Score instanse;

	static public void AddPoint(){

		if(instanse.bird.dead){
			return;
		}

		score++;

		if(score > highScore){
			highScore = score;
		}
	}

	static public int getPoint(){
		return score;
	}

	BirdMovement bird;

	void Start(){
		instanse = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");

		if(player_go == null){
			Debug.LogError("Could not find an object with tag 'Player'");
		}
		bird = player_go.GetComponent<BirdMovement> ();

		score = 0;
		highScore = PlayerPrefs.GetInt ("highScore",0);
	}

	void OnDestroy(){
		instanse = null;
		PlayerPrefs.SetInt("highScore",highScore);
	}

	void Update () {
	
		guiText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
