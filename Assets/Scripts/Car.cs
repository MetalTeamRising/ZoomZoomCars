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
    [SerializeField]
    int player = 1;
    string horizontal;
    string aButton;
    string bButton;
    string yButton;
    string select;
    string start;
	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
        ogRot = new Quaternion(rBod.rotation.x, rBod.rotation.y, rBod.rotation.z, rBod.rotation.w);

        //setting the custom buttons for the car
        horizontal = "P" + player + "_Horizontal";
        aButton = "P" + player + "_ButtonA";
        bButton = "P" + player + "_ButtonB";
        yButton = "P" + player + "_ButtonY";
        select = "P" + player + "_Select";
        start = "P" + player + "_Start";

        Physics.gravity = new Vector3(0.0f, -200.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        OverTurned();
        //if (willMove)
        //{
        //    Turn(Input.GetAxis(horizontal));
        //    Move();
        //}
        Turn(Input.GetAxis(horizontal));
        Move();
        if (Input.GetButtonDown(select))
        {
            //rBod.position = new Vector3(nextPoint.transform.position.x, nextPoint.transform.position.y + 30, nextPoint.transform.position.z);
            rBod.position = new Vector3(nextPoint.RespawnPoint.transform.position.x, nextPoint.RespawnPoint.transform.position.y, nextPoint.RespawnPoint.transform.position.z);
            rBod.transform.forward = nextPoint.RespawnPoint.transform.forward;
            direction = rBod.transform.forward;
            rBod.velocity = new Vector3(0.0f, 0.0f, 0.0f);
            vel = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }

    void Move()
    {
        if (Input.GetButton(bButton)) 
        {
            Debug.Log("Going backwards");
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
        if(Input.GetButton(aButton))
        {
            Debug.Log("Going forwards");
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
        //else
        //{
        //    isMoving = false;
        //}
    }

    void Turn(float turn)
    {
        if(isMoving)
        {
            if (turn > 0)
            {
                rBod.transform.Rotate((rBod.transform.up * turning) * Time.deltaTime);

            }
            else if (turn < 0)
            {
                rBod.transform.Rotate((rBod.transform.up * -turning) * Time.deltaTime);
            }
            direction = rBod.transform.forward;
        }
    }

    void OverTurned()
    {
        //Debug.Log(rBod.transform.up.y);
        if(rBod.transform.up.y < 0)
        {
            StopMovment();
            if (Input.GetButtonDown(yButton))
            {
                rBod.rotation = new Quaternion(ogRot.x, ogRot.y, ogRot.z, ogRot.w);
                rBod.rotation = Quaternion.LookRotation(direction);
                vel = new Vector3(0.0f, 0.0f, 0.0f);
            }
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
            if(pointIndex == other.GetComponent<Checkpoint>().Index)
            {
                nextPoint = other.GetComponent<Checkpoint>();
                pointIndex++;
                Debug.Log("checkpoint reached");
            }
        }
        else if(other.gameObject.tag == "Finish Line")
        {
            int test = other.GetComponent<Checkpoint>().Index;
            if(pointIndex == other.GetComponent<Checkpoint>().Index)
            {
                isFinished = true;
                willMove = false;
            }
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
    public int Player
    {
        get { return player; }
        set { player = value; }
    }
}
