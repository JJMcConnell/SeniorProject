using UnityEngine;
using System.Collections;

public class MilSelect : MonoBehaviour {

    //public GameObject loadingImage;

    public void LoadScene(string level)
    {

        System.Collections.Generic.List<Mission> tempList = new System.Collections.Generic.List<Mission>();

        for(int i=0; i<Data.militaryList.Count; i++)
        {
            if (Data.militaryList[i].difficulty == Data.currentDifficulty)
            {
                tempList.Add(Data.militaryList[i]);
            }
        }

        System.Random r = new System.Random();
        int randomIndex = r.Next(0, tempList.Count);
        Debug.Log("Random mission: " + randomIndex + " out of: " +tempList.Count);
        Data.pickedMission = tempList[randomIndex];
        tempList.Clear();

        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
