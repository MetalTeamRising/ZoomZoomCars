using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Checkpoint : MonoBehaviour {

    private Collider collide;
    private int checkpoint;

	// Use this for initialization
	void Start () {
        collide = this.GetComponent<Collider>();
        checkpoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEvent(Collider other)
    {
        if(other.tag == "Car")
        {
            checkpoint++;
        }
    }
}
