using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

    [System.NonSerialized]
    public bool lost = false;

    [Header("Try Button")]
    public float try_x = 0;
    public float try_y = 0;
    public float try_width = 10;
    public float try_height = 10;
    public string try_text = "Try";
    public GUIStyle try_style;

    [Header("Main Button")]
    public float main_x = 0;
    public float main_y = 0;
    public float main_width = 10;
    public float main_height = 10;
    public string main_text = "main";
    public GUIStyle main_style;


    // Use this for initialization
    void Start()
    {
        //Sets it up so the x and y start with origin at the center of the screen, 
        //and the button is centered

        try_width = try_width / 100 * Screen.height;
        try_height = try_height / 100 * Screen.height;
        try_x = (Screen.width / 2 + ((try_x) / 200) * Screen.width) - (try_width / 2);
        try_y = (Screen.height / 2 + ((try_y * -1) / 200) * Screen.height) - (try_height / 2);

        main_width = main_width / 100 * Screen.height;
        main_height = main_height / 100 * Screen.height;
        main_x = (Screen.width / 2 + ((main_x) / 200) * Screen.width) - (main_width / 2);
        main_y = (Screen.height / 2 + ((main_y * -1) / 200) * Screen.height) - (main_height / 2);
    }

    void OnGUI()
    {
        if (lost)
        {
            if (GUI.Button(new Rect(try_x, try_y, try_width, try_height), try_text, try_style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(Application.loadedLevel);
            }

            if (GUI.Button(new Rect(main_x, main_y, main_width, main_height), main_text, main_style))
            {
                //load level at index one, should be set to the first level
                Application.LoadLevel(0);
            }
        }

    }
}


