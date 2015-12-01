using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class resourceTracker : MonoBehaviour {

    // Use this for initialization
    void Start () {

  


        string m = Data.militaryResCount.ToString();
		string s = Data.scienceResCount.ToString();
		string e = Data.espionageResCount.ToString();
		string d = Data.diplomacyResCount.ToString();
        string f = Data.foodResCount.ToString();
        string days = Data.dayCounter.ToString();

		Text guiText1 = GameObject.Find("mtext").GetComponent<Text>();
		guiText1.text = " " + m;

		guiText1 = GameObject.Find("stext").GetComponent<Text>();
		guiText1.text = " " + s;

		guiText1 = GameObject.Find("etext").GetComponent<Text>();
		guiText1.text = " " + e;

		guiText1 = GameObject.Find("dtext").GetComponent<Text>();
		guiText1.text = " " + d;

        guiText1 = GameObject.Find("ftext").GetComponent<Text>();
        guiText1.text = " " + f;

        guiText1 = GameObject.Find("DayCounter").GetComponent<Text>();
        guiText1.text = " " + days;
	}



        // Update is called once per frame
        void Update () {
	
	}






}
