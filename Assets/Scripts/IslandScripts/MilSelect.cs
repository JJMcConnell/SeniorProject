using UnityEngine;
using System.Collections;

public class MilSelect : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadScene(string level)
    {
        Data.noMissions = false;
        System.Collections.Generic.List<Mission> tempList = new System.Collections.Generic.List<Mission>();

        for (int i = 0; i < Data.militaryList.Count; i++)
        {
            if (Data.militaryList[i].difficulty == Data.currentDifficulty && !Data.militaryList[i].isDone)
            {
                tempList.Add(Data.militaryList[i]);
            }
        }

        System.Random r = new System.Random();
        int randomIndex = r.Next(0, tempList.Count);
        if(tempList.Count == 0)
        {
            //hotdogs
        }
        else if (!Data.preserveMilMission || !Data.lastMilMission.isListed)
        {
            Debug.Log("Random mission: " + randomIndex + " out of: " + tempList.Count);
            Data.pickedMission = tempList[randomIndex];
            Data.lastMilMission = Data.pickedMission;
            Data.lastMilMission.isListed = true;
        }
        else
        {
            Data.pickedMission = Data.lastMilMission;
        }
        tempList.Clear();
        Data.hitBack = false;
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
