using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class characterDescription : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Data.onCrewScene = true;

        for (int i = 0; i < Data.charList.Count; i++) {
			GameObject.Find (Data.charList [i].charName).GetComponent<SpriteRenderer> ().color = Color.gray;
		}
	
	}
	
	// Update is called once per frame
	void Update () {

        bool charSelected = false;

        Text guiText = GameObject.Find("Description").GetComponent<Text>();

        for (int i = 0; i<Data.currentChars.Count; i++)
        {
            if (Data.currentChars[i].isPicked)
            {
                charSelected = true;
                break;
            }
        }

        if (charSelected)
        {
            string characterDesc = Data.currentCharDesc.description;
            guiText.text = Data.currentCharDesc.charName + "\n" + characterDesc + "\nExperience: " + Data.currentCharDesc.experience;

            for (int i = 0; i < Data.currentChars.Count; i++)
            {
                if (Data.currentChars[i].charName != Data.currentCharDesc.charName)
                {
                    Data.currentChars[i].isPicked = false;
                    GameObject.Find(Data.currentChars[i].charName).GetComponent<SpriteRenderer>().color = Color.white;
                }
            }

        }

        else
        {
            guiText.text = "Missions Run: " + (Data.dayCounter - 1) + "\nMilitary Resources: " + Data.militaryResCount 
                + "\nScience Resources: " + Data.scienceResCount + "\nEspionage Resources: " + Data.espionageResCount 
                + "\nDiplomacy Resources: " + Data.diplomacyResCount;
        }
        

    }
}
