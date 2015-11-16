using UnityEngine;
using System.Collections;

public class tutorialHide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Data.dayCounter > 1) {
            gameObject.SetActive(false);
        }
	
	}
}
