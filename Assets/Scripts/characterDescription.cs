using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class characterDescription : MonoBehaviour {

	// Use this for initialization
	void Start () {

		for (int i = 0; i < Data.charList.Count; i++) {
			GameObject.Find (Data.charList [i].charName).GetComponent<SpriteRenderer> ().color = Color.gray;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

		string characterDesc = Data.currentCharDesc.description;
		Text guiText = GameObject.Find("Description").GetComponent<Text>();
		guiText.text = Data.currentCharDesc.charName + "\n" + characterDesc;
	
	}
}
