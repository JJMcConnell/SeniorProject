using UnityEngine;
using System.Collections;

public class TriggeredEvent : MonoBehaviour {
	bool doWindowBadTrigger = false;
	bool doWindowGoodTrigger = false;
	int badTriggerType;
	bool newCharacter = false;
    Character rewardChar = new Character();
	// Use this for initialization
	void Start () {
		if(Data.dayCounter == 6){
			doWindowBadTrigger = true;
			//we take away gold 
			switch (badTriggerType) {
			case 1:
				Data.militaryResCount -= 100;
				break;
			case 2:
				Data.scienceResCount -= 100;
				break;
			case 3:
				Data.espionageResCount -= 100;
				break;
			case 4:
				Data.diplomacyResCount -= 100;
				break;
			}
		}

		if (Data.dayCounter == 12) {
			doWindowGoodTrigger = true;
			//we add a fish 
			Data.foodResCount +=50;
		}

		if ((Data.dayCounter % 2 == 0 && Data.dayCounter != 0) && Data.charList.Count > 0 && Data.hitBack == false) {
			newCharacter = true;
			if (Data.charList.Count > 0) {
				rewardChar = Data.charList [0];
				Data.currentChars.Add(Data.charList[0]);
                Data.charList.RemoveAt(0);
            }
		}

        
	}



	void DoWindowGood(int windowID) {
		GUILayout.Label("The day breaks with particularly rough seas. The large waves batter the ship, and your beleaguered crew is soaked with the spray. But it seems every cloud has a silver lining, as a rogue wave washes a large fish onto the deck. Your crew will have food for days to come!");
		if (GUI.Button (new Rect (20, 160, 200, 20), "Accept")) {
			doWindowGoodTrigger = false;
		}	
	}

	void DoWindowBad(int windowID) {

		float maxSum = -1;
		int type = 1; //1 =  military, 2 = science, 3 = espionage, 4 = diplomacy

			//you win
			if (maxSum < Data.militaryResCount) {
				maxSum = Data.militaryResCount;
			}
			if (maxSum < Data.scienceResCount) {
				maxSum = Data.scienceResCount;
				type = 2;
			}
			if (maxSum < Data.espionageResCount) {
				maxSum = Data.espionageResCount;
				type = 3;
			}
			if (maxSum < Data.diplomacyResCount) {
				maxSum = Data.diplomacyResCount;
				type = 4;
			}
			
			switch (type) {
			case 1:
			GUILayout.Label("As you wake on the sixth day, you see that a large chest of weapons has disappeared from the holds below deck. Perhaps you should post guards to watch for pesky theives in the night...");
			badTriggerType = 1;
				break;
			case 2:
			GUILayout.Label("As you wake on the sixth day, you see that a chest of chemisty supplies has disappeared from the holds below deck. Perhaps you should post guards to watch for pesky theives in the night...");
			badTriggerType = 2;
				break;
			case 3:
			GUILayout.Label("As you wake on the sixth day, you see that you are missing lock picking kits and daggers from the holds below deck. Perhaps you should post guards to watch for pesky theives in the night...");
			badTriggerType = 3;
				break;
			case 4:
			GUILayout.Label("As you wake on the sixth day, you see that a large coffer of gold has disappeared from the holds below deck. Perhaps you should post guards to watch for pesky theives in the night...");
			badTriggerType = 4;
				break;
			}

			if (GUI.Button (new Rect (20, 160, 200, 20), "Accept")) {
				doWindowBadTrigger = false;
			} 
	}

	void CharacterWindow(int windowID) {
		GUILayout.Label("New Squad Member:\n" + rewardChar.charName + ": " + rewardChar.description);
		if (GUI.Button (new Rect (20, 160, 200, 20), "Accept")) {
			newCharacter = false;
		} 
	}

	void OnGUI() {
		//doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
		if (doWindowBadTrigger && !(Data.hitBack)) {
			GUI.Window (0, new Rect (300, 100, 250, 200), DoWindowBad, "OH NO!");
		}
		if (doWindowGoodTrigger && !(Data.hitBack)) {
			GUI.Window (0, new Rect (300, 100, 250, 200), DoWindowGood, "Awesome!");
		}
		if (newCharacter && !(Data.hitBack)) {
			GUI.Window (0, new Rect (300, 100, 250, 200), CharacterWindow, "Welcome!");
		}
	}


	// Update is called once per frame
	//void Update () {

	//}
}
