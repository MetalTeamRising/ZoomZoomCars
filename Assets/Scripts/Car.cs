using UnityEngine;
using System;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Car : MonoBehaviour {

    private GameObject obj;
    private Rigidbody rBod;
    [SerializeField]private float speed = 100.0f;
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
            direction *= 0.2f;

            accel = direction;
            accel.y = 0;

            vel += accel;
            if (Math.Abs(vel.x) > speed)
            {
                vel.x = vel.x < 0 ? -speed : speed;
            }
            if (Math.Abs(vel.z) > speed)
            {
                vel.z = vel.z < 0 ? -speed : speed;
            }
           rBod.position = new Vector3(rBod.position.x + vel.x, rBod.position.y, rBod.position.z + vel.z);
            isMoving = true;
        }
        else if(Input.GetButton("ButtonA"))
        {
            direction = rBod.transform.forward;
            direction.Normalize();
            direction *= 0.2f;

            accel = direction;
            accel.y = 0;

            vel -= accel;
            if (Math.Abs(vel.x) > speed)
            {
                vel.x = vel.x < 0 ? -speed : speed;
            }
            if (Math.Abs(vel.z) > speed)
            {
                vel.z = vel.z < 0 ? -speed : speed;
            }
            rBod.position = new Vector3(rBod.position.x + vel.x, rBod.position.y, rBod.position.z + vel.z);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    void Turn(float turn)
    {
        if(isMoving)
        {
            if (turn > 0)
            {
                rBod.transform.Rotate((rBod.transform.up * 50) * Time.deltaTime);

            }
            else if (turn < 0)
            {
                rBod.transform.Rotate((rBod.transform.up * -50) * Time.deltaTime);
            }
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
