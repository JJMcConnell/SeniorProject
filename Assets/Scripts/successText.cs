using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class successText : MonoBehaviour {
	// Use this for initialization
	void Start () {
		System.Threading.Thread.Sleep(600);
		Character rewardChar = new Character();
		string success = Data.pickedMission.successDesc;
		Mission activeMission = Data.pickedMission;
		Text guiText1 = GameObject.Find("SuccessText").GetComponent<Text>();
        int type = 0;
        //guiText1.text = "Success \n" + success + "\n\nRewards: \n" + Data.pickedMission.rewardRsc.rscName;

        Data.noMissions = true;

        Resource reward = Data.pickedMission.rewardRsc;
		Data.resourceList.Add (reward);
       
		Text guiText3 = GameObject.Find ("MilReward").GetComponent<Text> ();
		Text guiText4 = GameObject.Find ("SciReward").GetComponent<Text> ();
		Text guiText5 = GameObject.Find ("EspReward").GetComponent<Text> ();
		Text guiText6 = GameObject.Find ("DipReward").GetComponent<Text> ();
        Text guiText7 = GameObject.Find("FoodReward").GetComponent<Text>();
        guiText3.text = "";
		guiText4.text = "";
		guiText5.text = "";
		guiText6.text = "";
        guiText7.text = "";


        //finds the total level of characters on the mission


        float totalLevel = 0;
        int level;
        for (int i=0; i<Data.activeMissionChars.Count; i++)
        {
            float x = (Data.activeMissionChars[i].experience / 500);
            level = (int)(1 + x);
            Debug.Log("Level is: " + level);
            totalLevel += level;
        }


        //resources are added
        //if totalLevel of squad exceeds the mission difficulty x squadsize value you gain less resources
        //this incentivizes sending level appropriate characters on level appropriate missions
        //sending underleveled characters does not generate addition resources or exp
        float adjustment = ((Data.adjustedDifficulty * Data.activeMissionChars.Count) / totalLevel);
        if (adjustment > 1)
            adjustment = 1;

		if (Data.pickedMission.rewardRsc.type == "Military"){
        type = 1;
			guiText3.text = "+" + ((Data.pickedMission.rewardRsc.quantity +(Data.adjustedDifficulty - 1) * 50)) * (adjustment) + " Military Resources";
			Data.militaryResCount += (Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50) * (adjustment);
		}
		if(Data.pickedMission.rewardRsc.type == "Science"){
        type = 2;
			guiText4.text = "+" + ((Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50)) * (adjustment) + " Science Resources";
			Data.scienceResCount += (Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50) * (adjustment);
        }
		if(Data.pickedMission.rewardRsc.type == "Espionage"){
        type = 3;
			guiText5.text = "+" + ((Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50)) * (adjustment) + " Espionage Resources";
			Data.espionageResCount += (Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50) * (adjustment);
        }
		if(Data.pickedMission.rewardRsc.type == "Diplomacy"){
        type = 4;
			guiText6.text = "+" + ((Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50)) * (adjustment) + " Diplomacy Resources";
			Data.diplomacyResCount += (Data.pickedMission.rewardRsc.quantity + (Data.adjustedDifficulty - 1) * 50) * (adjustment);
        }

        guiText7.text = "+" + Data.pickedMission.squadSize * 10 + " Food";
        Data.foodResCount += Data.pickedMission.squadSize * 10;

        bool addChar = false;

		//grant character if it's a third day and successful
		//do rewardChar method
		//if rewardChar isn't null fields alert the user about the new char
		if ((Data.dayCounter % 2 == 0 && Data.dayCounter != 0) || Data.needCharacter) {
			Data.needCharacter = false;
			if(Data.charList.Count > 0){
				addChar = true;
				rewardChar = Data.charList[0];
				Data.currentChars.Add (rewardChar);
                Data.charList.RemoveAt(0);
            }
		}
		if(addChar)
			guiText1.text = success + "\nRewards: " + Data.pickedMission.rewardRsc.rscName + "\nNew Character, " + rewardChar.charName +": "+ rewardChar.description;
		else
			guiText1.text = success + "\nRewards: " + Data.pickedMission.rewardRsc.rscName;

        //adjusts exp gain of entire squad on mission if sending over leveled characters
        int expGain;
        expGain = (int) (200 * (adjustment));
        for (int i = 0; i < Data.pickedMission.squadSize; i++)
        {
            Data.activeMissionChars[i].addExperience(expGain);
        }

        Text guiText2 = GameObject.Find ("SquadList").GetComponent<Text> ();
		string names = "";
		for (int i = 0; i<Data.activeMissionChars.Count; i++) {
			names += Data.activeMissionChars [i].charName + " +" + expGain +"XP\n";
			Data.activeMissionChars [i].setPicked ();
		}
		guiText2.text = names;


        //remove characters from CD
        for (int i = 0; i < Data.onCooldownChars.Count; i++)
        {
            Data.onCooldownChars[i].onCooldown = false;
        }
        Data.onCooldownChars.Clear();

        //add characters to CD
        for (int i=0; i<Data.activeMissionChars.Count; i++)
        {
            Data.activeMissionChars[i].onCooldown = true;
            Data.onCooldownChars.Add(Data.activeMissionChars[i]);
        }


        Data.pickedMission.isDone = true;
		//at end of displaying messages clear activeMissionChars
		Data.activeMissionChars.Clear ();
		Data.currentCrewSize = 0;

        //mark mission as done
        switch (type)
        {
            case 0:
                break;
            case 1:
                foreach (Mission m in Data.militaryList)
                {
                    if (m.title == Data.pickedMission.title)
                        m.isDone = true;
                }
                break;
            case 2:
                foreach (Mission m in Data.scienceList)
                {
                    if (m.title == Data.pickedMission.title)
                        m.isDone = true;
                }
                break;
            case 3:
                foreach (Mission m in Data.espionageList)
                {
                    if (m.title == Data.pickedMission.title)
                        m.isDone = true;
                }
                break;
            case 4:
                foreach (Mission m in Data.diplomacyList)
                {
                    if (m.title == Data.pickedMission.title)
                        m.isDone = true;
                }
                break;
        }

			//update day counter
			Data.dayCounter++;
	}
	// Update is called once per frame
	void Update () {
		
	}
}