using LitJson;
using UnityEngine;
using System.Collections;

public class EndMessage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void endMessage(JsonData jsonData){
		guiText.text = jsonData["data"]["message"].ToString();
	}
}
