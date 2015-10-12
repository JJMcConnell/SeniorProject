using UnityEngine;
using System.Collections;

public class DipSelect : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadScene(string level)
    {

        System.Collections.Generic.List<Mission> tempList = new System.Collections.Generic.List<Mission>();

        for (int i = 0; i < Data.diplomacyList.Count; i++)
        {
            if (Data.diplomacyList[i].difficulty == Data.currentDifficulty && !Data.diplomacyList[i].isDone)
            {
                tempList.Add(Data.diplomacyList[i]);
            }
        }

        System.Random r = new System.Random();
        int randomIndex = r.Next(0, tempList.Count);
        if (tempList.Count == 0)
        {
            //hotdogs
        }
        else if (!Data.preserveDipMission || !Data.lastDipMission.isListed)
        {
            Debug.Log("Random mission: " + randomIndex + " out of: " + tempList.Count);
            Data.pickedMission = tempList[randomIndex];
            Data.lastDipMission = Data.pickedMission;
            Data.lastDipMission.isListed = true;
        }
        else
        {
            Data.pickedMission = Data.lastDipMission;
        }
        tempList.Clear();
        Data.hitBack = false;
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}