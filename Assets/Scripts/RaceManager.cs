using UnityEngine;
using System.Collections;

public class RaceManager : MonoBehaviour {
    GameObject[] tempCheckArray;
    Checkpoint[] CheckpointArray;
    GameObject[] SpawnArray;
    GameObject[] myCars;
    Checkpoint nextPoint;
    [SerializeField]
    GameObject[] carsColor;

    GameObject[] cars;

    GameObject[] finishedRacers;
    [SerializeField]
    Camera[] allCamera;
    
	// Use this for initialization
	void Start () {
        //gotta get the checkpoints, the place where the car start
        //this gets the check points
        cars = new GameObject[4];
        tempCheckArray = GameObject.FindGameObjectsWithTag("Checkpoint");
        CheckpointArray = new Checkpoint[tempCheckArray.Length + 1];
        SpawnArray = new GameObject[cars.Length];
        myCars = new GameObject[cars.Length];
        finishedRacers = new GameObject[cars.Length];

        GameObject temp;
        for(int i = 0; i < tempCheckArray.Length; i++)
        {
            temp = GameObject.Find("checkpoint" + (i + 1));
            CheckpointArray[i] = temp.GetComponent<Checkpoint>();
            if(i == 0)
            {
                nextPoint = CheckpointArray[i];
            }
            CheckpointArray[i].Index = i;
        }
        temp = GameObject.FindGameObjectWithTag("Finish Line");
        CheckpointArray[CheckpointArray.Length - 1] = temp.GetComponent<Checkpoint>();
        CheckpointArray[CheckpointArray.Length - 1].IsActive = false;
        CheckpointArray[CheckpointArray.Length - 1].Index = CheckpointArray.Length - 1;

        //get where the car will spawn
        SpawnArray = GameObject.FindGameObjectsWithTag("Spawn");

        cars[0] = carsColor[PlayerPrefs.GetInt("p1Color")];
        cars[0].GetComponent<Car>().Player = 1;
        //p1Camera.transform.SetParent(cars[0].transform);
        
        cars[1] = carsColor[PlayerPrefs.GetInt("p2Color")];
        cars[1].GetComponent<Car>().Player = 2;
        //p2Camera.transform.SetParent(cars[1].transform);

        cars[2] = carsColor[PlayerPrefs.GetInt("p3Color")];
        cars[2].GetComponent<Car>().Player = 3;
        //p1Camera.transform.SetParent(cars[0].transform);

        cars[3] = carsColor[PlayerPrefs.GetInt("p4Color")];
        cars[3].GetComponent<Car>().Player = 4;
        //place the car
        for (int i = 0; i < cars.Length; i++)
        {
            myCars[i] = Instantiate(cars[i]);
            myCars[i].transform.position = SpawnArray[i].transform.position;
            myCars[i].transform.forward = SpawnArray[i].transform.forward;  
        }

        //Camera stuff
        for(int i = 0; i < cars.Length; i++)
        {
            allCamera[i].transform.SetParent(myCars[i].transform);
        }
       
        RaceStart();
    }
	
	// Update is called once per frame
	void Update () {

        //looping through all the cars and seeing if it has finished
        for(int i = 0; i < myCars.Length; i++)
        {
            for(int x = 0; x < myCars.Length; x++)
            {
                if (myCars[i].GetComponent<Car>().IsFinished)
                {
                    finishedRacers[x] = myCars[i];
                }
            }
        }
        bool gameOver = false;
        //check to see if all the racers are done racing
        for(int i = 0; i < finishedRacers.Length; i++)
        {
            if(finishedRacers[i] == null)
            {
                gameOver = false;
                break;
            }
            gameOver = true;
        }

        if (gameOver)
        {
            Debug.Log("player " + finishedRacers[0].GetComponent<Car>().Player + " finished first");
            GameOver();
        }
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
        GameObject.Find("Main Camera").GetComponent<GameOver>().IsActive = true;
        GameObject.Find("Main Camera").GetComponent<GameOver>().over = true;
    }
}
