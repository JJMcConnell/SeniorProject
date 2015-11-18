using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class characterDescription : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        if (Data.characterSelected)
            Data.currentCharDesc.isPicked = false;
        Data.onCrewScene = true;
        Data.hitBack = true;   //the only way to exit the scene is to hit back, so this works here.

        for (int i = 0; i < Data.charList.Count; i++) {
			GameObject.Find (Data.charList [i].charName).GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite>("Textures/" + Data.charList[i].charName + " Sil");
            GameObject.Find (Data.charList [i].charName).GetComponent<SpriteRenderer>().color = Color.gray;
        }

        for (int i = 0; i < Data.currentChars.Count; i++)
        {
            GameObject.Find(Data.currentChars[i].charName).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + Data.currentChars[i].charName);
        }




    }
	
	// Update is called once per frame
	void Update () {

        Data.characterSelected = false;

        Text guiText = GameObject.Find("Description").GetComponent<Text>();

        for (int i = 0; i<Data.currentChars.Count; i++)
        {
            if (Data.currentChars[i].isPicked)
            {
                Data.characterSelected = true;
                break;
            }
        }

        if (Data.characterSelected)
        {
            string characterDesc = Data.currentCharDesc.description;
			float x = ((Data.currentCharDesc.experience) / 500);
			int charLevel = (int)(1 + x);
            guiText.text = Data.currentCharDesc.charName + "\n" + characterDesc + "\nCharacter Level: " + charLevel + "\nExperience needed for next Level: " + ((float)charLevel*500 - Data.currentCharDesc.experience);
            GameObject.Find("Big Image").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/" + Data.currentCharDesc.charName);

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
                + "\nDiplomacy Resources: " + Data.diplomacyResCount + "\nFood Resources: " + Data.foodResCount;

            GameObject.Find("Big Image").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Captain_Portrait2");
        }
        

    }
}
