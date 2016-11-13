using UnityEngine;
using System;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Car : MonoBehaviour {

    private GameObject obj;
    private Rigidbody rBod;
    [SerializeField]private float speed = 99.0f;
    [SerializeField]private float turning = 45;
    private bool isMoving = false;
    public bool willMove = false;
    private Vector3 accel;
    private Vector3 direction;
    private Vector3 vel;
    private Checkpoint nextPoint;
    private Quaternion ogRot;
    private int pointIndex;
    private bool isFinished = false;
    [SerializeField]int player = 1;
    string horizontal;
    string aButton;
    string bButton;
    string select;
    string start;
	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
        ogRot = rBod.rotation;
        //setting the custom buttons for the car
        horizontal = "P" + player + "_Horizontal";
        aButton = "P" + player + "_ButtonA";
        bButton = "P" + player + "_ButtonB";
        select = "P" + player + "_Select";
        start = "P" + player + "_Start";

	}
	
	// Update is called once per frame
	void Update () {
        OverTurned();
        if (willMove)
        {
            Turn(Input.GetAxis(horizontal));
            Move();
        }
    }

    void Move()
    {
        if (Input.GetButton(bButton)) 
        {
            direction = rBod.transform.forward;
            direction.Normalize();

            accel = direction * 100;
            accel.y = 0;

            vel += (accel * Time.deltaTime);
            if(vel.magnitude > speed)
            {
                vel.Normalize();
                vel = vel * speed;
            }
            rBod.velocity = new Vector3(vel.x, rBod.velocity.y, vel.z);
            isMoving = true;
        }
        else if(Input.GetButton(aButton))
        {
            direction = rBod.transform.forward;
            direction.Normalize();

            accel = direction * 100;
            accel.y = 0;

            vel -= (accel * Time.deltaTime);
            if (vel.magnitude > speed)
            {
                vel.Normalize();
                vel = vel * speed;
            }
            rBod.velocity = new Vector3(vel.x, rBod.velocity.y, vel.z);
            isMoving = true;
        }
        else
        {
            //turns out it decellerates automatically and my effort has been for naught
            isMoving = false;
        }
    }

    void Turn(float turn)
    {
        if(isMoving)
        {
            Debug.Log("inside turing");
            if (turn > 0)
            {
                Debug.Log("turing > 0");
                rBod.transform.Rotate((rBod.transform.up * turning) * Time.deltaTime);

            }
            else if (turn < 0)
            {
                Debug.Log("turning < 0");
                rBod.transform.Rotate((rBod.transform.up * -turning) * Time.deltaTime);
            }
            direction = rBod.transform.forward;
        }
    }

    void OverTurned()
    {
        Debug.Log(rBod.transform.up.y);
        if(rBod.transform.up.y < 0)
        {
            StopMovment();
            rBod.rotation = new Quaternion(ogRot.x, ogRot.y, ogRot.z, ogRot.w);
        }
    }

    void StopMovment()
    {
        vel = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("this is a checkpoint");
            if(pointIndex == other.GetComponent<Checkpoint>().Index)
            {
                Debug.Log("passed it " + pointIndex);
                pointIndex++;
            }
        }
        if(other.gameObject.tag == "Finish Line")
        {
            Debug.Log("finish line");
            isFinished = true;
            willMove = false;
        }
    }

    public bool WillMove
    {
        get { return willMove; }
        set { willMove = value; }
    }

    public Checkpoint NextPoint
    {
        get { return nextPoint; }
        set { nextPoint = value; }
    }

    public bool IsFinished
    {
        get { return isFinished; }
        set { isFinished = value; }
    }
}
