using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    private float[] timer = { 0, 0, 0, 0 };
    private float maxTimer = .5f;
    private bool[] rchUp = { false, false, false, false };
    private bool[] rchDn = { false, false, false, false };
    private bool[] tmHt = { false, false, false, false };

    private float evener;

    public bool over = false;

    [SerializeField]private guiSpot tryAgain;
    [SerializeField]private guiSpot select;
    [SerializeField]private guiSpot main;
    [SerializeField]private guiSpot lftarrw;
    [SerializeField]private guiSpot rgtarrw;
    private int actbttn = 1;



    private string[] verticals = new string[4];
    private string[] aButtons = new string[4];

    void Start()
    {
        tryAgain.Start();
        select.Start();
        main.Start();
        lftarrw.Start();
        rgtarrw.Start();

        for (int i = 0; i < 4; i++)
        {
            verticals[i] = "P" + (int)(i + 1) + "_Vertical";
            aButtons[i] = "P" + (int)(i + 1) + "_ButtonA";
        }

        evener = select.height / 2 - lftarrw.height / 2;
    }

    void Update()
    {

        for (int i = 0; i < 4; i++)
        {
            if (Input.GetButtonDown(aButtons[i]))
            {
                switch (actbttn)
                {
                    case 1:
                        Application.LoadLevel(1);
                        break;
                    case 2:
                        Application.LoadLevel(2);
                        break;
                    case 3:
                        Application.LoadLevel(0);
                        break;
                    default:
                        break;
                }
            }
            if (Input.GetAxis(verticals[i]) < -0.5)
            {
                rchDn[i] = true;
                if (rchDn[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        if (actbttn > 1)
                        {
                            actbttn--;
                        }
                        else
                        {
                            actbttn = 3;
                        }
                        tmHt[i] = true;
                        timer[i] = 0;
                    }
                    timer[i] = timer[i] + Time.deltaTime;
                }
            }
            else if (Input.GetAxis(verticals[i]) > 0.5)
            {
                rchUp[i] = true;
                if (rchUp[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        if (actbttn < 3)
                        {
                            actbttn++;
                        }
                        else
                        {
                            actbttn = 1;
                        }
                        tmHt[i] = true;
                        timer[i] = 0;
                    }
                    timer[i] = timer[i] + Time.deltaTime;
                }
            }
            else
            {
                if (!tmHt[i] && rchDn[i])
                {
                    if (actbttn > 1)
                    {
                        actbttn--;
                    }
                    else
                    {
                        actbttn = 3;
                    }
                }
                if (!tmHt[i] && rchUp[i])
                {
                    if (actbttn < 3)
                    {
                        actbttn++;
                    }
                    else
                    {
                        actbttn = 1;
                    }
                }
                rchDn[i] = false;
                rchUp[i] = false;
                tmHt[i] = false;
                timer[i] = 0;
            }
        }
    }

    void OnGUI()
    {
        if (over)
        {
            if (GUI.Button(new Rect(tryAgain.x, tryAgain.y, tryAgain.width, tryAgain.height), tryAgain.text, tryAgain.style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(Application.loadedLevel);
            }
            if (GUI.Button(new Rect(select.x, select.y, select.width, select.height), select.text, select.style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(2);
            }
            if (GUI.Button(new Rect(main.x, main.y, main.width, main.height), main.text, main.style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(0);
            }
            switch (actbttn)
            {
                case 1:
                    GUI.Box(new Rect(lftarrw.x, tryAgain.y + evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, tryAgain.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                case 2:
                    GUI.Box(new Rect(lftarrw.x, select.y + evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, select.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                case 3:
                    GUI.Box(new Rect(lftarrw.x, main.y + evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, main.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                default:
                    break;
            }
        }

    }
}


