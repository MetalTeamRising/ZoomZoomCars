using System;
using UnityEngine;

    [Serializable]
    public class guiSpot
    {
        public float x = 0;
        public float y = 0;
        public float width = 10;
        public float height = 10;
        public string text = "";
        public GUIStyle style;
        

        public void Start()
        {
            //Sets it up so the x and y start with origin at the center of the screen, and the button is centered
            width = width / 100 * Screen.height;
            height = height / 100 * Screen.height;
            x = (Screen.width / 2 + ((x) / 200) * Screen.width) - (width / 2);
            y = (Screen.height / 2 + ((y * -1) / 200) * Screen.height) - (height / 2);
        }
    }


