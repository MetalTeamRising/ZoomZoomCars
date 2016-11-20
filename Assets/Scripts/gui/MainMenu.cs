using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


    private float[] timer = { 0, 0, 0, 0 };
    private float maxTimer = .5f;
    private bool[] rchUp = { false, false, false, false };
    private bool[] rchDn = { false, false, false, false };
    private bool[] tmHt = { false, false, false, false };
    private int actbttn = 1;
    private float evener;

    [SerializeField]private guiSpot play;

    [SerializeField]private guiSpot instruction;

    [SerializeField]private guiSpot instBox;

    [SerializeField]private guiSpot back;

    [SerializeField]private guiSpot crd;

    [SerializeField]private guiSpot crdBox;

    [SerializeField]private guiSpot lftarrw;

    [SerializeField]private guiSpot rgtarrw;


    //enum for controlling screen
    private enum mnType{main, inst, crd }
    private mnType currentScreen = mnType.main;
    
    private string[] verticals = new string[4];
    private string[] aButtons = new string[4];
    private string[] bButtons = new string[4];

    // Use this for initialization
    void Start ()
    {
        play.Start();
        instruction.Start();
        instBox.Start();
        back.Start();
        crd.Start();
        crdBox.Start();
        lftarrw.Start();
        rgtarrw.Start();

        for (int i = 0; i < 4; i++)
        {
            verticals[i] = "P" + (int)(i + 1) + "_Vertical";
            aButtons[i] = "P" + (int)(i + 1) + "_ButtonA";
            bButtons[i] = "P" + (int)(i + 1) + "_ButtonB";
        }
        evener = instruction.height / 2 - lftarrw.height / 2;
    }

    void Update()
    {

        for (int i = 0; i < 4; i++)
        {
            if (currentScreen == mnType.main)
            {
                if (Input.GetButtonDown(aButtons[i]))
                {
                    switch (actbttn)
                    {
                        case 1:
                            Application.LoadLevel(2);
                            break;
                        case 2:
                            currentScreen = mnType.inst;
                            break;
                        case 3:
                            currentScreen = mnType.crd;
                            break;
                        default:
                            break;
                    }
                }
            }

            if (Input.GetButtonDown(bButtons[i]))
            {
                currentScreen = mnType.main;
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


    void OnGUI ()
    {
        if (currentScreen == mnType.main)
        {
            //start button, when it is clicked it does whatever is in the if statement
            if (GUI.Button(new Rect(play.x, play.y, play.width, play.height), play.text, play.style))
            {
                //load level at index one, should be set to the first select screen
                Application.LoadLevel(2);
            }

            if (GUI.Button(new Rect(instruction.x, instruction.y, instruction.width, instruction.height), instruction.text, instruction.style))
            {
                //shows instruction screen screen
                currentScreen = mnType.inst;
            }

            if (GUI.Button(new Rect(crd.x, crd.y, crd.width, crd.height), crd.text, crd.style))
            {
                //shows crd screen screen
                currentScreen = mnType.crd;
            }

            switch (actbttn)
            {
                case 1:
                    GUI.Box(new Rect(lftarrw.x, play.y+ evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, play.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                case 2:
                    GUI.Box(new Rect(lftarrw.x, instruction.y + evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, instruction.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                case 3:
                    GUI.Box(new Rect(lftarrw.x, crd.y + evener, lftarrw.width, lftarrw.height), lftarrw.text, lftarrw.style);
                    GUI.Box(new Rect(rgtarrw.x, crd.y + evener, rgtarrw.width, rgtarrw.height), rgtarrw.text, rgtarrw.style);
                    break;
                default:
                    break;
            }
        }

        if(currentScreen == mnType.inst)
        {

            GUI.Box(new Rect(instBox.x, instBox.y, instBox.width, instBox.height), instBox.text, instBox.style);

            if (GUI.Button(new Rect(back.x, back.y, back.width, back.height), back.text, back.style))
            {
                currentScreen = mnType.main;
            }
        }

        if (currentScreen == mnType.crd)
        {

            GUI.Box(new Rect(crdBox.x, crdBox.y, crdBox.width, crdBox.height), crdBox.text, crdBox.style);

            if (GUI.Button(new Rect(back.x, back.y, back.width, back.height), back.text, back.style))
            {
                currentScreen = mnType.main;
            }
        }
    }
}
