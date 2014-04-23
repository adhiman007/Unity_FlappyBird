
using UnityEngine;
using System.Collections;

public class EndScreenScript : MonoBehaviour {
	
	WWWWiki wwwwiki;
	
	BirdMovement bird;
	static bool isGame = true;
	static int score;
	
	private WWWWiki WWWWiki;
	
	private static string name = "dlsdnd23";
	
	string saveUri = "http://192.168.11.55:8080/savePlayer";
	string selectRankUri = "http://192.168.11.55:8080/selectRank";
	
	void Start () {
		
		wwwwiki = gameObject.AddComponent<WWWWiki>();
		
		if(isGame){
			GetComponent<SpriteRenderer>().enabled = false;
		}
		
	}
	
	void GameOver(){
		
		savePlayer ();
		selectRank ();
		
		bird = GameObject.Find("PlayerBird").GetComponent<BirdMovement>();
		
		if(bird.dead){
			GetComponent<SpriteRenderer>().enabled = true;
		}
		
	}
	
	void savePlayer(){
		
		
		score = Score.getPoint();
		saveUri = saveUri + "?name="+name+"&score="+score;
		wwwwiki.GET (saveUri);
		
	}
	
	void selectRank(){
		selectRankUri = selectRankUri + "?name=" + name;
		wwwwiki.GET (selectRankUri);
	}

}
