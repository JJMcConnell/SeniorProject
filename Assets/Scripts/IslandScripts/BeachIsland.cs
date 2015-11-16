using UnityEngine;
using System.Collections;

public class BeachIsland : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Data.fromIsland = true;

        Data.currentDifficulty = 1;
        Debug.Log("The current mission difficulty is " + Data.currentDifficulty);

        System.Collections.Generic.List<Mission> tempList1 = new System.Collections.Generic.List<Mission>();

        for (int i = 0; i < Data.militaryList.Count; i++)
        {
            if (Data.militaryList[i].difficulty == Data.currentDifficulty && !Data.militaryList[i].isDone)
            {
                tempList1.Add(Data.militaryList[i]);
            }
        }

        System.Collections.Generic.List<Mission> tempList2 = new System.Collections.Generic.List<Mission>();
        for (int i = 0; i < Data.scienceList.Count; i++)
        {
            if (Data.scienceList[i].difficulty == Data.currentDifficulty && !Data.scienceList[i].isDone)
            {
                tempList2.Add(Data.scienceList[i]);
            }
        }

        System.Collections.Generic.List<Mission> tempList3 = new System.Collections.Generic.List<Mission>();
        for (int i = 0; i < Data.espionageList.Count; i++)
        {
            if (Data.espionageList[i].difficulty == Data.currentDifficulty && !Data.espionageList[i].isDone)
            {
                tempList3.Add(Data.espionageList[i]);
            }
        }

        System.Collections.Generic.List<Mission> tempList4 = new System.Collections.Generic.List<Mission>();
        for (int i = 0; i < Data.diplomacyList.Count; i++)
        {
            if (Data.diplomacyList[i].difficulty == Data.currentDifficulty && !Data.diplomacyList[i].isDone)
            {
                tempList4.Add(Data.diplomacyList[i]);
            }
        }


        if (tempList1.Count == 0)
        {
            GameObject.Find("MilButton1").GetComponent<UnityEngine.UI.Button>().enabled = false;
            GameObject.Find("MilButton1").GetComponent<UnityEngine.UI.Button>().colors = new UnityEngine.UI.ColorBlock() { normalColor = Color.gray };

        }
        if (tempList2.Count == 0)
        {
            GameObject.Find("SciButton1").GetComponent<UnityEngine.UI.Button>().enabled = false;
            GameObject.Find("SciButton1").GetComponent<UnityEngine.UI.Button>().colors = new UnityEngine.UI.ColorBlock() { normalColor = Color.gray };
        }
		if (tempList3.Count == 0)
		{
			GameObject.Find("EspButton1").GetComponent<UnityEngine.UI.Button>().enabled = false;
			GameObject.Find("EspButton1").GetComponent<UnityEngine.UI.Button>().colors = new UnityEngine.UI.ColorBlock() { normalColor = Color.gray };
		}
		if (tempList4.Count == 0)
		{
			GameObject.Find("DipButton1").GetComponent<UnityEngine.UI.Button>().enabled = false;
			GameObject.Find("DipButton1").GetComponent<UnityEngine.UI.Button>().colors = new UnityEngine.UI.ColorBlock() { normalColor = Color.gray };
		}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
