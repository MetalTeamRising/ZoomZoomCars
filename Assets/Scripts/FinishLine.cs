using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class FinishLine : Checkpoint {
    Car[] finishedCars;
    int currentIndex = 0;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        finishedCars = new Car[Input.GetJoystickNames().Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateFinished(Car car)
    {
        finishedCars[currentIndex] = car;
        currentIndex++;
        Debug.Log(car.Player + " has finished");
    }
    
    public int CurrentIndex
    {
        get { return currentIndex; }
    }
}
