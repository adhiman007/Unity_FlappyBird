using LitJson;
using UnityEngine;
using System.Collections;

public class WWWWiki : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public WWW GET(string url) 
	{ 
		WWW www = new WWW (url);
		StartCoroutine(WaitForRequest(www)); 
		return www; 
	}

	private IEnumerator WaitForRequest(WWW www) 
	{ 
		yield return www; 

		// check for errors 
		if (www.error == null) 
		{ 
			Debug.Log("WWW Ok!: " + www.text); 
			ProcessPlayer(www.text);
		} 
		else 
		{ 
			Debug.Log("WWW Error: " + www.error); 
		}
	}

	private void ProcessPlayer(string jsonString){
		
		JsonData jsonPlayer = JsonMapper.ToObject(jsonString);
		string isOk = jsonPlayer ["ok"].ToString();
		
		if(isOk.Equals("True")){
			if(!jsonPlayer["data"]["method"].ToString().Equals("") && !jsonPlayer["data"]["class"].ToString().Equals("")){
				GameObject.Find(jsonPlayer["data"]["class"].ToString()).SendMessage(jsonPlayer["data"]["method"].ToString(),jsonPlayer);
			}

		}
	}

}
