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
    public string instruction_text = "Play";
    public GUIStyle instruction_style;

    [Header("Instructions Box")]
    public float instBox_x = 0;
    public float instBox_y = 0;
    public float instBox_width = 10;
    public float instBox_height = 10;
    public string instBox_text = "Back";
    public GUIStyle instBox_style;

    [Header("Instructions Off Button")]
    public float instOff_x = 0;
    public float instOff_y = 0;
    public float instOff_width = 10;
    public float instOff_height = 10;
    public string instOff_text = "Back";
    public GUIStyle instOff_style;

    //enum for controlling screen
    private enum mnType{main, pause }
    private mnType currentScreen = mnType.main;

    // Use this for initialization
    void Start ()
    {
        //Sets it up so the x and y start with origin at the center of the screen, and the button is centered
        play_x = (Screen.width / 2 + ((play_x) / 200) * Screen.width) - (play_width / 2);
        play_y = (Screen.height / 2 + ((play_y * -1) / 200) * Screen.height) - (play_height / 2);

        instruction_x = (Screen.width / 2 + ((instruction_x) /200)* Screen.width) - (instruction_width / 2);
        instruction_y = (Screen.height / 2 + ((instruction_y * -1) / 200) * Screen.height) - (instruction_height / 2);

        instBox_x = (Screen.width / 2 + ((instBox_x)/ 200) * Screen.width) - (instBox_width / 2);
        instBox_y = (Screen.height / 2 + ((instBox_y * -1)/ 200) * Screen.height) - (instBox_height / 2);

        instOff_x = (Screen.width / 2 + ((instOff_x)/ 200) * Screen.width) - (instOff_width / 2);
        instOff_y = (Screen.height / 2 + ((instOff_y * -1)/ 200) * Screen.height) - (instOff_height / 2);
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
                currentScreen = mnType.pause;
            }
        }

        if(currentScreen == mnType.pause)
        {

            GUI.Box(new Rect(instBox_x, instBox_y, instBox_width, instBox_height), instBox_text, instBox_style);

            if (GUI.Button(new Rect(instOff_x, instOff_y, instOff_width, instOff_height), instOff_text, instOff_style))
            {
                currentScreen = mnType.main;
            }
        }
    }
}
