using UnityEngine;
using System.Collections;

public class backButton : MonoBehaviour {
	
	//public GameObject loadingImage;
	
	public void LoadLevel()
	{
        //loadingImage.SetActive(true);

        Data.hitBack = true;

        if (Data.fromIsland && !Data.noMissions)
        {
            switch (Data.pickedMission.type)
            {
                case "Science":
                    Data.preserveSciMission = true;
                    break;
                case "Military":
                    Data.preserveMilMission = true;
                    break;
                case "Espionage":
                    Data.preserveEspMission = true;
                    break;
                case "Diplomacy":
                    Data.preserveDipMission = true;
                    break;
            }

            for (int i = 0; i < Data.currentCrewSize; i++)
            {
                //Data.activeMissionChars [i].setPicked ();
                //this was previously not setting the isPicked to false correctly, causing issues with increasing max crew size
                Data.activeMissionChars[i].isPicked = false;
            }
            Data.activeMissionChars.Clear();
            Data.currentCrewSize = 0;

       }
        if (Data.fromIsland)
            Application.LoadLevel(Data.lastIsland);
        else
            Application.LoadLevel("MapScene");
	}
}