using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {

    // Use this for initialization

    public void MainMenuLoad(string level)
    {


        Data.currentChars.Clear();
   

       // Destroy(transform.gameObject);
        Application.LoadLevel(level);
    
    }

}
