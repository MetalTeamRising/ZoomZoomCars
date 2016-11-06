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
    private Vector3 vel;

	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Turn(Input.GetAxis("Horizontal"));
        Move(Input.GetAxis("Vertical"));
    }

    void Move(float move)
    {
        if (move > 0)
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
        }
        else if(move < 0)
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
        }
    }

    void Turn(float turn)
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
