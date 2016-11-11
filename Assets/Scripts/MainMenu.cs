using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
    
    [Header("Play Button")]
    public float play_x = 0;
    public float play_y = 0;
    public float play_width = 10;
    public float play_height = 10;
    public string play_text = "Play";
    public GUIStyle play_style;

    [Header("Instructions Button")]
    public float instruction_x = 0;
    public float instruction_y = 0;
    public float instruction_width = 10;
    public float instruction_height = 10;
    public string instruction_text = "Instructions";
    public GUIStyle instruction_style;

    [Header("Instructions Box")]
    public float instBox_x = 0;
    public float instBox_y = 0;
    public float instBox_width = 10;
    public float instBox_height = 10;
    public string instBox_text = "";
    public GUIStyle instBox_style;

    [Header("Back Button")]
    public float back_x = 0;
    public float back_y = 0;
    public float back_width = 10;
    public float back_height = 10;
    public string back_text = "Back";
    public GUIStyle back_style;

    [Header("Credits Button")]
    public float crd_x = 0;
    public float crd_y = 0;
    public float crd_width = 10;
    public float crd_height = 10;
    public string crd_text = "Credits";
    public GUIStyle crd_style;

    [Header("Instructions Box")]
    public float crdBox_x = 0;
    public float crdBox_y = 0;
    public float crdBox_width = 10;
    public float crdBox_height = 10;
    public string crdBox_text = "";
    public GUIStyle crdBox_style;

    //enum for controlling screen
    private enum mnType{main, inst, crd }
    private mnType currentScreen = mnType.main;

    // Use this for initialization
    void Start ()
    {
        //Sets it up so the x and y start with origin at the center of the screen, and the button is centered
        play_width = play_width / 100 * Screen.height;
        play_height = play_height / 100 * Screen.height;
        play_x = (Screen.width / 2 + ((play_x) / 200) * Screen.width) - (play_width / 2);
        play_y = (Screen.height / 2 + ((play_y * -1) / 200) * Screen.height) - (play_height / 2);


        instruction_width = instruction_width / 100 * Screen.height;
        instruction_height = instruction_height / 100 * Screen.height;
        instruction_x = (Screen.width / 2 + ((instruction_x) /200)* Screen.width) - (instruction_width / 2);
        instruction_y = (Screen.height / 2 + ((instruction_y * -1) / 200) * Screen.height) - (instruction_height / 2);


        instBox_width = instBox_width / 100 * Screen.height;
        instBox_height = instBox_height / 100 * Screen.height;
        instBox_x = (Screen.width / 2 + ((instBox_x)/ 200) * Screen.width) - (instBox_width / 2);
        instBox_y = (Screen.height / 2 + ((instBox_y * -1)/ 200) * Screen.height) - (instBox_height / 2);


        back_width = back_width / 100 * Screen.height;
        back_height = back_height / 100 * Screen.height;
        back_x = (Screen.width / 2 + ((back_x)/ 200) * Screen.width) - (back_width / 2);
        back_y = (Screen.height / 2 + ((back_y * -1)/ 200) * Screen.height) - (back_height / 2);

        crd_width = crd_width / 100 * Screen.height;
        crd_height = crd_height / 100 * Screen.height;
        crd_x = (Screen.width / 2 + ((crd_x) / 200) * Screen.width) - (crd_width / 2);
        crd_y = (Screen.height / 2 + ((crd_y * -1) / 200) * Screen.height) - (crd_height / 2);

        crdBox_width = crdBox_width / 100 * Screen.height;
        crdBox_height = crdBox_height / 100 * Screen.height;
        crdBox_x = (Screen.width / 2 + ((crdBox_x) / 200) * Screen.width) - (crdBox_width / 2);
        crdBox_y = (Screen.height / 2 + ((crdBox_y * -1) / 200) * Screen.height) - (crdBox_height / 2);
    }

    void OnGUI ()
    {
        if (currentScreen == mnType.main)
        {
            //start button, when it is clicked it does whatever is in the if statement
            if (GUI.Button(new Rect(play_x, play_y, play_width, play_height), play_text, play_style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(instruction_x, instruction_y, instruction_width, instruction_height), instruction_text, instruction_style))
            {
                //shows instruction screen screen
                currentScreen = mnType.inst;
            }

            if (GUI.Button(new Rect(crd_x, crd_y, crd_width, crd_height), crd_text, crd_style))
            {
                //shows crd screen screen
                currentScreen = mnType.inst;
            }
        }

        if(currentScreen == mnType.inst)
        {

            GUI.Box(new Rect(instBox_x, instBox_y, instBox_width, instBox_height), instBox_text, instBox_style);

            if (GUI.Button(new Rect(back_x, back_y, back_width, back_height), back_text, back_style))
            {
                currentScreen = mnType.main;
            }
        }

        if (currentScreen == mnType.crd)
        {

            GUI.Box(new Rect(crdBox_x, crdBox_y, crdBox_width, crdBox_height), crdBox_text, crdBox_style);

            if (GUI.Button(new Rect(back_x, back_y, back_width, back_height), back_text, back_style))
            {
                currentScreen = mnType.main;
            }
        }
    }
}
