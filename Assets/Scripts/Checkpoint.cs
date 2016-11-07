using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Checkpoint : MonoBehaviour {

    private Collider collide;
    Collision col;
    private int checkpoint;
    bool isActive = false;
    int index;

	// Use this for initialization
	void Start () {
        collide = this.GetComponent<Collider>();
        //checkpoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Car" && isActive)
        {
            Debug.Log("checkpoint hit " + index);
            isActive = false;
        }
    }
    public bool IsActive
    {
        get { return isActive; }
        set { isActive = value; }
    }

    public int Index
    {
        get { return index; }
        set { index = value; }
    }
}
