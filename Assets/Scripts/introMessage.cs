using UnityEngine;
using System.Collections;

public class introMessage : MonoBehaviour {


    bool doWindowIntro = false;
    // Use this for initialization
    void Start()
    {

        if (Data.dayCounter == 1)
        {
            doWindowIntro = true;
        }

    }



    void DoWindowIntro(int windowID)
    {
        GUILayout.Label("Welcome to Harte Captain. You and your crew of four have been marooned to this foreign planet after having to flee your home world. You come to Harte as visitors, for Harte is already inhabited by all manner of creature. Your journey starts on the sandy beaches. Send your crew members on missions and try to gather as many resources as possible. You have about 20 days I’d say if you hope to establish a foothold here on Harte. What civilization do you hope to rebuild? Let’s find out!");
        if (GUI.Button(new Rect(20, 275, 200, 20), "Accept"))
        {
            doWindowIntro = false;
        }
    }

    void OnGUI()
    {
        //doWindow0 = GUI.Toggle(new Rect(10, 10, 100, 20), doWindow0, "Window 0");
        if (doWindowIntro && !(Data.hitBack))
        {
            GUI.Window(0, new Rect(75, 100, 250, 325), DoWindowIntro, "Let's Go!");
        }
    }




    // Update is called once per frame
    void Update () {
	
	}
}
