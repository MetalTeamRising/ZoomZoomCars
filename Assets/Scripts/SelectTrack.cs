using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectTrack : MonoBehaviour {

    [SerializeField]
    Sprite[] tracksSelect;
    [SerializeField]
    Sprite[] tracksNah;
    [SerializeField]
    GameObject[] holder;

    [SerializeField]
    GameObject howto;

    bool[] isActive;
    int current = 0;
    float prevH = 0;
    float prevV = 0;
    float time = 0;
    Random rng = new Random();

    // Use this for initialization
    void Start () {
        isActive = new bool[4];
        isActive[0] = true;
        isActive[1] = false;
        isActive[2] = false;
        isActive[3] = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (howto.activeSelf)
        {
            if(time >= 3)
            {
                if (Input.GetButton("P1_ButtonA"))
                {
                    switch (current)
                    {
                        case 0:
                            Application.LoadLevel(1);
                            break;
                        case 1:
                            Application.LoadLevel(4);
                            break;
                        case 2:
                            Application.LoadLevel(5);
                            break;
                        case 3:
                            int temp = Random.Range(0, 4);
                            if(temp == 0) { Application.LoadLevel(1); }
                            else if(temp == 1) { Application.LoadLevel(4); }
                            else if(temp == 2) { Application.LoadLevel(5); }
                            break;
                    }
                }
               
            }
            else
                {
                    time += 1.0f;
                }
        }
        moveController();
        for(int i = 0; i < 4; i++)
        {
            if (isActive[i])
            {
                holder[i].GetComponent<Image>().sprite = tracksSelect[i];
            }
            else
            {
                holder[i].GetComponent<Image>().sprite = tracksNah[i];
            }
        }
	}

    void moveController()
    {
        //move the selector around
        if (Input.GetAxis("P1_Horizontal")  == 1 && prevH != 1)
        {
            isActive[current] = false;
            current++;
            if(current > 3)
            {
                current = 0;
            }
            isActive[current] = true;
            Debug.Log("greater");
        }
        else if(Input.GetAxis("P1_Horizontal") == -1 && prevH != -1)
        {
            isActive[current] = false;
            current--;
            if (current < 0)
            {
                current = 3;
            }
            isActive[current] = true;
            Debug.Log("lesser");
        }
        else if(Input.GetAxis("P1_Vertical") == 1 && prevV != 1)
        {
            switch (current)
            {
                case 0:
                    isActive[current] = false;
                    current = 2;
                    isActive[current] = true;
                    break;
                case 1:
                    isActive[current] = false;
                    current = 3;
                    isActive[current] = true;
                    break;
                case 2:
                    isActive[current] = false;
                    current = 0;
                    isActive[current] = true;
                    break;
                case 3:
                    isActive[current] = false;
                    current = 1;
                    isActive[current] = true;
                    break;
            }
        }
        else if(Input.GetAxis("P1_Vertical") == -1 && prevV != -1)
        {
            switch (current)
            {
                case 0:
                    isActive[current] = false;
                    current = 2;
                    isActive[current] = true;
                    break;
                case 1:
                    isActive[current] = false;
                    current = 3;
                    isActive[current] = true;
                    break;
                case 2:
                    isActive[current] = false;
                    current = 0;
                    isActive[current] = true;
                    break;
                case 3:
                    isActive[current] = false;
                    current = 1;
                    isActive[current] = true;
                    break;
            }
        }
        prevH = Input.GetAxis("P1_Horizontal");
        prevV = Input.GetAxis("P1_Vertical");
        if (Input.GetButton("P1_ButtonA"))
        {
            howto.SetActive(true);
        }
        if (Input.GetButton("P1_ButtonB"))
        {
            Application.LoadLevel(2);
        }

        Debug.Log(current);
    }
}
