using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deployButton : MonoBehaviour {
	
	//public GameObject loadingImage;
	
	public void DeployLoadScene(string level)
	{
        //loadingImage.SetActive(true);
        if ((Data.pickedMission.squadSize - Data.currentCrewSize) == 0)
        {
            Data.hitBack = false;                //so new characters can be added once again
            Application.LoadLevel(level);
        }
        else
        {
            Text guiText = GameObject.Find("Remaining").GetComponent<Text>();
            guiText.color = Color.red;
        }
	}
}