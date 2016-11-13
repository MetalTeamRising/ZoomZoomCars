using UnityEngine;
using System.Collections;

public class RaceManager : MonoBehaviour {
    GameObject[] tempCheckArray;
    Checkpoint[] CheckpointArray;
    GameObject[] SpawnArray;
    GameObject[] myCars;
    Checkpoint nextPoint;
    GameObject[] cars;
    [SerializeField]
    GameObject[] carsColors;

    GameObject[] finishedRacers;    
	// Use this for initialization
	void Start () {
        //gotta get the checkpoints, the place where the car start
        //this gets the check points
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
            if(i > 0)
            {
                //CheckpointArray[i].IsActive = false;
            }
            else
            {
                //CheckpointArray[i].IsActive = true;
                nextPoint = CheckpointArray[i];
            }
            CheckpointArray[i].Index = i;
        }
        temp = GameObject.FindGameObjectWithTag("Finish Line");
        CheckpointArray[CheckpointArray.Length - 1] = temp.GetComponent<Checkpoint>();
        CheckpointArray[CheckpointArray.Length - 1].IsActive = false;

        //get where the car will spawn
        SpawnArray = GameObject.FindGameObjectsWithTag("Spawn");

        //retreives the saved car information i saved in the carSelect script
        //the index of the car prefabs in car colors has to match up with the
        //index i put them in in the switcher prefab, which is in the prefab folder under guifabs
        cars[0] = carsColors[PlayerPrefs.GetInt("p1Color")];
        cars[1] = carsColors[PlayerPrefs.GetInt("p2Color")];

        //place the car
        for (int i = 0; i < cars.Length; i++)
        {
            myCars[i] = Instantiate(cars[i]);
            myCars[i].transform.position = SpawnArray[i].transform.position;
            myCars[i].transform.forward = SpawnArray[i].transform.forward;
        }

        RaceStart();
    }
	
	// Update is called once per frame
	void Update () {

        //looping through all the cars and seeing if it has finished
        for(int i = 0; i < myCars.Length; i++)
        {
            if (myCars[i].GetComponent<Car>().IsFinished)
            {
                finishedRacers[i] = myCars[i];
            }
        }
        bool gameOver = false;
        //check to see if all the racers are done racing
        for(int i = 0; i < finishedRacers.Length; i++)
        {
            if(finishedRacers[i] == null)
            {
                gameOver = false;
                return;
            }
            gameOver = true;
        }

        if (gameOver)
        {
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
        GameObject.Find("Main Camera").GetComponent<GameOver>().lost = true;
    }
}
