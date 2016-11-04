using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Car : MonoBehaviour {

    private GameObject obj;
    private Rigidbody rBod;
    [SerializeField]private float speed = 10000000000.0f;
    private Vector3 direction;
    private float turnAngle = 0;
    private float xVel = 0;
    private float zVel = 0;

	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(Input.GetAxis("Vertical"));

        Turn(Input.GetAxis("Horizontal"));
	}

    void Move(float move)
    {
        if (move > 0)
        {
            direction = Vector3.forward;
            direction.Normalize();
            direction *= 0.2f;
            xVel += (direction.x * Time.deltaTime);
            zVel += (direction.z * Time.deltaTime);
            if (xVel > speed)
            {
                xVel = speed;
            }
            if (zVel > speed)
            {
                zVel = speed;
            }
            rBod.velocity = new Vector3(xVel, rBod.velocity.y, zVel);
        }
    }

    void Turn(float turn)
    {
        if (turn > 0)
        {
            turnAngle += (10 * Time.deltaTime);
        }
        else if (turn > 0)
        {
            turnAngle -= (10 * Time.deltaTime);
        }
        turnAngle += (rBod.rotation.z * Time.deltaTime);

        rBod.rotation = new Quaternion(rBod.rotation.x, rBod.rotation.y, turnAngle, rBod.rotation.w);
    }
}
