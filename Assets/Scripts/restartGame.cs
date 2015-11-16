using UnityEngine;
using System.Collections;

public class restartGame : MonoBehaviour {

    // Use this for initialization

    public void MainMenuLoad(string level)
    {


        Data.currentChars.Clear();
        Data.lastPosition = new Vector3(-26.7f, -15.7f, -1f);


    // Destroy(transform.gameObject);
    Application.LoadLevel(level);
    
    }

}
