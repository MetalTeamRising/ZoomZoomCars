using UnityEngine;
using System;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Car : MonoBehaviour {

    private GameObject obj;
    private Rigidbody rBod;
    [SerializeField]private float speed = 30.0f;
    private Vector3 accel;
    private Vector3 direction;
    private Vector3 moveTo;
    private Vector3 vel;
    private Vector2 force;
    private float turnAngle = 0;

	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Turn(Input.GetAxis("Horizontal"));
        direction = Vector3.forward;
        if (Input.GetButtonDown("Jump"))
        {
            Move();
        }
        /*else
        {
            xVel -= (direction.x * Time.deltaTime);
            zVel -= (direction.z * Time.deltaTime);
            if (Math.Abs(xVel) < 0)
            {
                xVel = 0;
            }
            if (Math.Abs(zVel) < 0)
            {
                zVel = 0;
            }
            rBod.velocity = new Vector3(xVel, rBod.velocity.y, zVel);
        }*/
	}

    void Move()
    {
        accel = direction;
        accel.y = 0;

        vel += accel;
        if(Math.Abs(vel.x) > speed)
        {
            vel.x = speed;
        }
        if (Math.Abs(vel.z) > speed)
        {
            vel.z = speed;
        }

        rBod.velocity = new Vector3(vel.x, rBod.velocity.y, vel.z);
    }

    void Turn(float turn)
    {
        if (turn > 0)
        {
            turnAngle -= (10 * Time.deltaTime);
        }
        else if (turn < 0)
        {
            turnAngle += (10 * Time.deltaTime);
        }
        rBod.rotation = new Quaternion(rBod.rotation.x, rBod.rotation.y, rBod.rotation.z + turnAngle, rBod.rotation.w);
    }
}
