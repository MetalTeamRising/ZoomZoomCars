using UnityEngine;
using System.Collections;

public class RaceManager : MonoBehaviour {
    GameObject[] tempCheckArray;
    Checkpoint[] CheckpointArray;
    GameObject[] SpawnArray;
    GameObject[] myCars;
    Checkpoint nextPoint;
    [SerializeField]
    GameObject[] cars;
    ArrayList finishedCars;
        
	// Use this for initialization
	void Start () {
        //gotta get the checkpoints, the place where the car start
        //this gets the check points
        tempCheckArray = GameObject.FindGameObjectsWithTag("Checkpoint");
        CheckpointArray = new Checkpoint[tempCheckArray.Length + 1];
        SpawnArray = new GameObject[cars.Length];
        myCars = new GameObject[cars.Length];
        finishedCars = new ArrayList();
      
        GameObject temp;
        for(int i = 0; i < tempCheckArray.Length; i++)
        {
            temp = GameObject.Find("checkpoint" + (i + 1));
            CheckpointArray[i] = temp.GetComponent<Checkpoint>();
            if (i == 0)
            {
                nextPoint = CheckpointArray[i];
            }
            CheckpointArray[i].Index = i;
        }
        temp = GameObject.FindGameObjectWithTag("Starting Line");
        CheckpointArray[CheckpointArray.Length - 1] = temp.GetComponent<Checkpoint>();
        CheckpointArray[CheckpointArray.Length - 1].IsActive = false;

        //get where the car will spawn
        SpawnArray = GameObject.FindGameObjectsWithTag("Spawn");

        //place the car
       for(int i = 0; i < cars.Length; i++)
        {
            myCars[i] = Instantiate(cars[i]);
            myCars[i].transform.position = SpawnArray[i].transform.position;
            myCars[i].transform.forward = SpawnArray[i].transform.forward;
        }

        RaceStart();
    }
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < myCars.Length; i++)
        {
            if (myCars[i].GetComponent<Car>().IsFinished)
            {
                finishedCars.Add(myCars[i]);
            }
        }
        //if()
	}
    void RaceStart()
    {
        //countdown, lets the car go
        for(int i = 0; i < cars.Length; i++)
        {
            myCars[i].GetComponent<Car>().willMove = true;
        }
    }
    void GameOver()
    {
        //go to game over screen or for now the main menu
        Application.LoadLevel(0);
    }
}
