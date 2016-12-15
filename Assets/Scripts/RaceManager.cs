using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RaceManager : MonoBehaviour {
    GameObject[] tempCheckArray;
    Checkpoint[] CheckpointArray;
    GameObject[] SpawnArray;
    GameObject[] myCars;
    Checkpoint nextPoint;
    [SerializeField]
    GameObject[] carsColor;

    private int players;
    GameObject[] cars;

    GameObject[] finishedRacers;
    [SerializeField]
    Camera[] allCamera;
    [SerializeField]
    Sprite[] getReady;

    [SerializeField]
    Sprite[] background;

    //setting the camera for 1 player
    int rectPos = 0;
    int rectSize = 1;

    //setting the cameras for 2 players
    Vector4[] numPlayersTwo;
    int view2 = 82;
    //setting the cameras for 3 players
    Vector4[] numPlayerThree;
    //setting the cameras for 4 players
    Vector4[] numPlayerFour;

    float currentTime;
    float gameOverTimer = 0;

    //get all the canvases in the screen to put the countdown on and what player they are
    [SerializeField]
    GameObject[] playerCount;
    bool started = false;

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
        players = PlayerPrefs.GetInt("players");

        numPlayersTwo = new Vector4[2];
        numPlayersTwo[0] = new Vector4(0, 0, 0.5f, 1f);
        numPlayersTwo[1] = new Vector4(0.5f, 0, 0.5f, 1f);

        numPlayerThree = new Vector4[3];
        numPlayerThree[0] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        numPlayerThree[1] = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
        numPlayerThree[2] = new Vector4(0, 0, 1, 0.5f);

        numPlayerFour = new Vector4[4];
        numPlayerFour[0] = new Vector4(0, 0.5f, 0.5f, 0.5f);
        numPlayerFour[1] = new Vector4(0.5f, 0.5f, 0.5f, 0.5f);
        numPlayerFour[2] = new Vector4(0, 0, 0.5f, 0.5f);
        numPlayerFour[3] = new Vector4(0.5f, 0, 0.5f, 0.5f);

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

        for(int i = 1; i <= players; i++)
        {
            cars[i - 1] = carsColor[PlayerPrefs.GetInt("p" + i + "Color")];
            cars[i-1].GetComponent<Car>().Player = i;
        }
        //place the car
        for (int i = 0; i < players; i++)
        {
            myCars[i] = Instantiate(cars[i]);
            myCars[i].transform.position = SpawnArray[i].transform.position;
            myCars[i].transform.forward = SpawnArray[i].transform.forward;  
        }
        
        //Camera stuff
        for(int i = 0; i < players; i++)
        {
            allCamera[i].transform.SetParent(myCars[i].transform);
            if (players == 1)
            {
                allCamera[i].rect = new Rect(rectPos, rectPos, rectSize, rectSize);
                allCamera[1].gameObject.SetActive(false);
                allCamera[2].gameObject.SetActive(false);
                allCamera[3].gameObject.SetActive(false);
            }
            else if (players == 2)
            {
                allCamera[i].rect = new Rect(numPlayersTwo[i].x, numPlayersTwo[i].y, numPlayersTwo[i].z, numPlayersTwo[i].w);
                allCamera[i].fieldOfView = view2;

                allCamera[2].gameObject.SetActive(false);
                allCamera[3].gameObject.SetActive(false);
            }
            else if (players == 3)
            {
                allCamera[i].rect = new Rect(numPlayerThree[i].x, numPlayerThree[i].y, numPlayerThree[i].z, numPlayerThree[i].w);
                allCamera[3].gameObject.SetActive(false);
            }
            else if(players == 4)
            {
                allCamera[i].rect = new Rect(numPlayerFour[i].x, numPlayerFour[i].y, numPlayerFour[i].z, numPlayerFour[i].w);
            }
        }
        currentTime = 3.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (!started)
        {
            RaceStartCountDown();
        }
        else
        {
            for(int i = 0; i < players; i++)
            {
                if (currentTime <= 2.0f)
                {
                    playerCount[i].GetComponent<Image>().sprite = getReady[0];
                    currentTime += Time.deltaTime;
                }
                else if(currentTime > 2.0f && !myCars[i].GetComponent<Car>().IsFinished)
                {
                    playerCount[i].gameObject.SetActive(false);
                }
                else if (currentTime > 2.0f && myCars[i].GetComponent<Car>().IsFinished)
                {
                    playerCount[i].gameObject.SetActive(true);
                    playerCount[i].GetComponent<Image>().sprite = getReady[4];
                }
            }
        }
        //looping through all the cars and seeing if it has finished
        for(int i = 0; i < players; i++)
        {
            for(int x = 0; x < players; x++)
            {
                if (myCars[i].GetComponent<Car>().IsFinished)
                {
                    finishedRacers[x] = myCars[i];
                }
            }
        }
        bool gameOver = false;
        //check to see if all the racers are done racing
        int index = GameObject.Find("Finish line").GetComponent<FinishLine>().CurrentIndex;
        if (index == players)
        {
            gameOver = true;
        }

        if (gameOver && gameOverTimer >= 2.0)
        {
            //Debug.Log("player " + finishedRacers[0].GetComponent<Car>().Player + " finished first");
            GameOver();
        }
        else if(gameOver && gameOverTimer < 2.0)
        {
            gameOverTimer += Time.deltaTime;
            Debug.Log(gameOverTimer);
        }
	}
    void RaceStart()
    {
        //countdown, lets the car go
        for(int i = 0; i < players; i++)
        {
            myCars[i].GetComponent<Car>().willMove = true;
        }
        started = true;
    }
    void GameOver()
    {
        //go to game over screen or for now the main menu
        GameObject.Find("Main Camera").GetComponent<GameOver>().over = true;
    }

    void RaceStartCountDown()
    {
        if(currentTime >= 0)
        {
            currentTime -= Time.deltaTime;
            int temp = (int)currentTime + 1;
            if (currentTime < 0)
            {
                for(int i = 0; i < players; i++)
                {
                    playerCount[i].GetComponent<Image>().sprite = getReady[0];
                    currentTime = 0;
                }
                RaceStart();
            }
            else
            {
                for (int i = 0; i < players; i++)
                {
                    playerCount[i].GetComponent<Image>().sprite = getReady[temp];
                }
            }
        }
    }
}
