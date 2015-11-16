using UnityEngine;
using System.Collections;

public class EspSelect : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadScene(string level)
    {
        Data.noMissions = false;
        System.Collections.Generic.List<Mission> tempList = new System.Collections.Generic.List<Mission>();

        for (int i = 0; i < Data.espionageList.Count; i++)
        {
            if (Data.espionageList[i].difficulty == Data.currentDifficulty && !Data.espionageList[i].isDone)
            {
                tempList.Add(Data.espionageList[i]);
            }
        }

        System.Random r = new System.Random();
        int randomIndex = r.Next(0, tempList.Count);
        if (tempList.Count == 0)
        {
            //hotdogs
        }
        else if (!Data.preserveEspMission || !Data.lastEspMission.isListed)
        {
            Debug.Log("Random mission: " + randomIndex + " out of: " + tempList.Count);
            Data.pickedMission = tempList[randomIndex];
            Data.lastEspMission = Data.pickedMission;
            Data.lastEspMission.isListed = true;
        }
        else
        {
            Data.pickedMission = Data.lastEspMission;
        }
        tempList.Clear();
        Data.hitBack = false;
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}