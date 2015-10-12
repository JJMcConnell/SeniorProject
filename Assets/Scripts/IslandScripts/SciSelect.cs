using UnityEngine;
using System.Collections;

public class SciSelect : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadScene(string level)
    {

        System.Collections.Generic.List<Mission> tempList = new System.Collections.Generic.List<Mission>();

        for (int i = 0; i < Data.scienceList.Count; i++)
        {
            if (Data.scienceList[i].difficulty == Data.currentDifficulty && !Data.scienceList[i].isDone)
            {
                tempList.Add(Data.scienceList[i]);
            }
        }

        System.Random r = new System.Random();
        int randomIndex = r.Next(0, tempList.Count);
        if (!Data.preserveSciMission || !Data.lastSciMission.isListed)
        {
            Debug.Log("Random mission: " + randomIndex + " out of: " + tempList.Count);
            Data.pickedMission = tempList[randomIndex];
            Data.lastSciMission = Data.pickedMission;
            Data.lastSciMission.isListed = true;
        }
        else
        {
            Data.pickedMission = Data.lastSciMission;
        }
        tempList.Clear();
        Data.hitBack = false;
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}