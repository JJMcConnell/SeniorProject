using UnityEngine;
using System.Collections;

public class IslandCollision : MonoBehaviour {


    public void loadIsland(string level) {
        Debug.Log("Collider name" + level);
        if (level == "LavaIsland" || level == "GreenIsland" || level == "IceIsland" || level == "BeachIsland")
        {
            //transform.position = new Vector3(0, 6, 0);
          //  Data.lastPosition = gameObject.transform.position;
          //  Data.lastPosition.x -= 50;
          //  Data.lastPosition.y -= 50;
            Data.lastIsland = level;
            Application.LoadLevel(level);
        }
        if (level == "0 - Background")
        {
            triggerMe();
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log("Enter");

        if (coll.gameObject.name == "LavaIsland" || coll.gameObject.name == "GreenIsland" || coll.gameObject.name == "IceIsland" || coll.gameObject.name == "BeachIsland") {
            loadIsland(coll.gameObject.name);
            Data.lastPosition = coll.gameObject.transform.position;
            Data.lastPosition.x += 40;
                }
        else
        {
            loadIsland(coll.gameObject.name);
        }
    }


    void OnCollisionExit2D(Collision2D coll)
    {
        Debug.Log("Exit");
        if (coll.gameObject.name == "0 - Background")
        {
            triggerMe();
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        Debug.Log("Inside");
        if (coll.gameObject.name == "0 - Background")
        {
            triggerWall();
        }
    }

    void triggerWall()
    {
        var comp = Camera.main.GetComponent("cameraMovement");
        comp.SendMessage("setInside");
    }

    void triggerMe()
    {
        var comp = Camera.main.GetComponent("cameraMovement");
        comp.SendMessage("setTrigger");
    }
}
