using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class failText : MonoBehaviour {
	// Use this for initialization
	void Start () {
		System.Threading.Thread.Sleep(600);
		string fail = Data.pickedMission.failDesc;
		Mission activeMission = Data.pickedMission;

        Text guiText1 = GameObject.Find("FailText").GetComponent<Text>();
		
		//guiText1.text = "Success \n" + success + "\n\nRewards: \n" + Data.pickedMission.rewardRsc.rscName;

		guiText1.text = fail;
		
		
		Text guiText2 = GameObject.Find("SquadList").GetComponent<Text> ();
		string names = "";


        float totalLevel = 0;
        int level;
        for (int i = 0; i < Data.activeMissionChars.Count; i++)
        {
            float x = (Data.activeMissionChars[i].experience / 500);
            level = (int)(1 + x);
            Debug.Log("Level is: " + level);
            totalLevel += level;
        }


        float adjustment = ((Data.adjustedDifficulty * Data.activeMissionChars.Count) / totalLevel);
        if (adjustment > 1)
            adjustment = 1;

        int expGain;
        expGain = (int)(50 * (adjustment));
        for (int i = 0; i<Data.activeMissionChars.Count; i++) {
			Data.activeMissionChars [i].addExperience (expGain);
            names += Data.activeMissionChars[i].charName + " +" + expGain + "XP\n";
            Data.activeMissionChars[i].setPicked();
		}

        //remove characters from CD
     
        for (int i = 0; i < Data.onCooldownChars.Count; i++)
        {
            Data.onCooldownChars[i].onCooldown = false;
        }
        Data.onCooldownChars.Clear();
        

        //add characters to CD
        for (int i = 0; i < Data.activeMissionChars.Count; i++)
        {
            Data.activeMissionChars[i].onCooldown = true;
            Data.onCooldownChars.Add(Data.activeMissionChars[i]);
        }


        guiText2.text = names;

        Text guiText3 = GameObject.Find("FoodReward").GetComponent<Text>();

        guiText3.text = "-" + Data.pickedMission.squadSize * 10 + " Food";
        Data.foodResCount -= Data.pickedMission.squadSize * 10;

        if(Data.foodResCount <= 0)
        {
            Application.LoadLevel("NoWin");
        }

        if (Data.dayCounter % 2 == 0 && Data.dayCounter != 0)
			Data.needCharacter = true;
		
		//at end of displaying messages clear activeMissionChars
		Data.activeMissionChars.Clear ();
		Data.currentCrewSize = 0;
		
		//update day counter
		Data.dayCounter++;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
