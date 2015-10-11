using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    public float interpVelocity;
    public float minDistance;
    public float followDistance;
    public GameObject target;
    public Vector3 offset;
    Vector3 targetPos;
    float lastVelocity = 40f;
    bool decel = false;
    public float accelScale = 5f;
    public bool triggered = false;
    public bool insideWall = false;

    // Use this for initialization
    void Start() {

        //targetPos = transform.position;

    }

    public void setTrigger()
    {
        this.triggered = triggered ^ true;
    }
    public void setInside()
    {
        this.insideWall = true;
    }

    // Update is called once per frame
    void Update() {
        Debug.Log("Hot Dogs. 2" + triggered);
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        lastVelocity = 40.0f;
        var deltaX = (target.transform.position.x - transform.position.x) / lastVelocity;
        var deltaY = (target.transform.position.y - transform.position.y) / lastVelocity;
        move = new Vector3(deltaX, deltaY, 0);
        transform.position += move;
    }
}
