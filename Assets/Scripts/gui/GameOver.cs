using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    
    public bool lost = false;

    [SerializeField]private guiSpot tryAgain;
    [SerializeField]private guiSpot select;
    [SerializeField]private guiSpot main;

    void Start()
    {
        tryAgain.Start();
        select.Start();
        main.Start();
    }

    void OnGUI()
    {
        if (lost)
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
        }

    }
}


