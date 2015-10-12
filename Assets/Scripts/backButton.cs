using UnityEngine;
using System.Collections;

public class backButton : MonoBehaviour {
	
	//public GameObject loadingImage;
	
	public void LoadLevel()
	{
        //loadingImage.SetActive(true);

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

        for (int i=0; i<Data.currentCrewSize; i++)
			Data.activeMissionChars [i].setPicked ();
		Data.activeMissionChars.Clear ();
		Data.currentCrewSize = 0;
		Application.LoadLevel(Data.lastIsland);
	}
}