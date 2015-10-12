using UnityEngine;
using System.Collections;

public class shipBackToMap : MonoBehaviour
{

    //public GameObject loadingImage;

    public void LoadMap(string level)
    {
        Data.hitBack = true;
        Data.preserveMilMission = false;
        Data.preserveSciMission = false;
        Data.preserveEspMission = false;
        Data.preserveDipMission = false;
        Data.lastMilMission.isListed = false;
        Data.lastSciMission.isListed = false;
        Data.lastDipMission.isListed = false;
        Data.lastEspMission.isListed = false;
        //loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
