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

	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //OverTurned();
        if (willMove)
        {
            Turn(Input.GetAxis("Horizontal"));
            Move();
        }
       
    }

    void Move()
    {
        if (Input.GetButton("ButtonB")) 
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
        else if(Input.GetButton("ButtonA"))
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
            direction = -rBod.transform.forward;
            direction.Normalize();

            accel = direction * 100;
            accel.y = 0;

            vel -= (accel * Time.deltaTime);
            float mags = vel.magnitude;
            if (mags > 0)
            {
                vel.Normalize();
                vel = vel * 0;
            }
            rBod.velocity = new Vector3(vel.x, rBod.velocity.y, vel.z);
            isMoving = false;
        }
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
        Debug.Log(rBod.transform.up.y);
        if(rBod.transform.up.y < 0)
        {
            StopMovment();
        }
    }

    void StopMovment()
    {
        vel = new Vector3(0, 0, 0);
    }

    public bool WillMove
    {
        get { return willMove; }
        set { willMove = value; }
    }
}
