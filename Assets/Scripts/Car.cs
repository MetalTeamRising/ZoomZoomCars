using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Collider))]
public class Car : MonoBehaviour {

    private GameObject obj;
    private Rigidbody rBod;
    [SerializeField]private float speed = 10000000000.0f;
    [SerializeField]private Vector3 accel;
    private Vector3 direction;
    private float turnAngle;

	// Use this for initialization
	void Start () {
        obj = gameObject;
        rBod = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(Input.GetAxis("Horizontal"));
	}

    void Move(float move)
    {
        direction = Vector3.forward;
        direction.Normalize();
        direction *= 0.2f;
        accel = new Vector3(direction.x, direction.y, direction.z);
        rBod.velocity = new Vector3(move * speed, rBod.velocity.y, move * speed);
        
    }
}
