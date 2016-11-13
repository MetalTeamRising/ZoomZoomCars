using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    

    [SerializeField]
    private guiSpot play;

    [SerializeField]
    private guiSpot instruction;

    [SerializeField]
    private guiSpot instBox;

    [SerializeField]
    private guiSpot back;

    [SerializeField]
    private guiSpot crd;

    [SerializeField]
    private guiSpot crdBox;
    //enum for controlling screen
    private enum mnType{main, inst, crd }
    private mnType currentScreen = mnType.main;

    // Use this for initialization
    void Start ()
    {
        play.Start();
        instruction.Start();
        instBox.Start();
        back.Start();
        crd.Start();
        crdBox.Start();
    }

    void OnGUI ()
    {
        if (currentScreen == mnType.main)
        {
            //start button, when it is clicked it does whatever is in the if statement
            if (GUI.Button(new Rect(play.x, play.y, play.width, play.height), play.text, play.style))
            {
                //load level at index one, should be set to the first level
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
