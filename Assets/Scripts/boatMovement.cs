using UnityEngine;
using System.Collections;

public class boatMovement : MonoBehaviour {

    float speed = 50.0f;

	// Use this for initialization
	void Start () {
      //  transform.position = new Vector3(0, 6, 0);
    }
	
	// Update is called once per frame
	void Update () {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

    }
    /*
    void OnTriggerEnter2D(Collision2D coll)
    {
        if(coll.gameObject.name == "0 - Foreground")
        {
            speed = 0.0f;
        }
    }

    void OnTriggerExit2D(Collision2D coll)
    {
        if (coll.gameObject.name == "3 - Foreground")
        {
            speed = 50.0f;
        }
    }
    */
}
