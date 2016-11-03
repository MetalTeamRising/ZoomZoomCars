using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float timer = 0;


    //enum for controlling screen
    private enum gmState { play, pause, gameOver };
    private gmState currentState = gmState.play;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == gmState.play)
        {
            timer = timer + Time.deltaTime;
        }
        else if(currentState == gmState.pause)
        {

        }
        else if (currentState == gmState.gameOver)
        {

        }

    }
}
