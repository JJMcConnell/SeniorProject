using UnityEngine;
using System.Collections;

public class shipBackToMap : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadMap(string level)
    {
        Data.hitBack = true;
        Data.fromIsland = false;
        if (Data.preserveMilMission)
            Data.lastMilMission.isListed = false;
        if(Data.preserveSciMission)
            Data.lastSciMission.isListed = false;
        if(Data.preserveEspMission)
            Data.lastEspMission.isListed = false;
        if(Data.preserveDipMission)
            Data.lastDipMission.isListed = false;
        Data.preserveMilMission = false;
        Data.preserveSciMission = false;
        Data.preserveEspMission = false;
        Data.preserveDipMission = false;

        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
