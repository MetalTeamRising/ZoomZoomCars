using UnityEngine;
using System.Collections;

public class RaceManager : MonoBehaviour {
    GameObject[] tempCheckArray;
    Checkpoint[] CheckpointArray;
    GameObject carSpawn;
    public GameObject car; //this is temp
    GameObject myCar;
    Checkpoint nextPoint;

	// Use this for initialization
	void Start () {
        //gotta get the checkpoints, the place where the car start
        //this gets the check points
        tempCheckArray = GameObject.FindGameObjectsWithTag("Checkpoint");
        CheckpointArray = new Checkpoint[tempCheckArray.Length + 1];
        GameObject temp;
        for(int i = 0; i < tempCheckArray.Length; i++)
        {
            temp = GameObject.Find("checkpoint" + (i + 1));
            CheckpointArray[i] = temp.GetComponent<Checkpoint>();
            if(i > 0)
            {
                CheckpointArray[i].IsActive = false;
            }
            else
            {
                CheckpointArray[i].IsActive = true;
                nextPoint = CheckpointArray[i];
            }
            CheckpointArray[i].Index = i;
        }
        temp = GameObject.FindGameObjectWithTag("Starting Line");
        CheckpointArray[CheckpointArray.Length - 1] = temp.GetComponent<Checkpoint>();
        CheckpointArray[CheckpointArray.Length - 1].IsActive = false;

        //get where the car will spawn
        carSpawn = GameObject.Find("Spawn");

        //place the car
        myCar = Instantiate(car);
        myCar.transform.position = carSpawn.transform.position;
        myCar.transform.forward = carSpawn.transform.forward;

    }
	
	// Update is called once per frame
	void Update () {
        HitCheckPoint();
	}

    void HitCheckPoint()
    {
        if(nextPoint.IsActive == false)
        {
            if(nextPoint.tag == "Starting Line")
            {
                GameOver();
            }
            else
            {
                nextPoint = CheckpointArray[nextPoint.Index + 1];
                nextPoint.IsActive = true;
            }
        }
   }
    void RaceStart()
    {
        //countdown, lets the car go
        myCar.GetComponent<Car>().willMove = true;
    }
    void GameOver()
    {
        //go to game over screen or for now the main menu
        Application.LoadLevel(0);
    }
}
