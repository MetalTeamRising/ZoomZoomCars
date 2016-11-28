using UnityEngine;
using System.Collections;

public class carSelect : MonoBehaviour {

    private float[] timer = { 0,0,0,0 };
    private float maxTimer = .5f;
    private bool[] rchLft = {false, false, false, false};
    private bool[] rchRht = { false, false, false, false };
    private bool[] tmHt = { false, false, false, false };


    [SerializeField]
    private guiSpot choose;

    [SerializeField]
    private guiSpot play;

    [SerializeField]
    private guiSpot back;


    [Header("P1(Top Left)")]
    [SerializeField]private guiSpot TLback;
    [SerializeField]private guiSpot TLnext;
    [SerializeField]private guiSpot TLCont;

    [Header("P2(Top Right)")]
    [SerializeField]private guiSpot TRback;
    [SerializeField]private guiSpot TRnext;
    [SerializeField]private guiSpot TRCont;


    [Header("P3(Bottom Left)")]
    [SerializeField]private guiSpot BLback;
    [SerializeField]private guiSpot BLnext;
    [SerializeField]private guiSpot BLCont;


    [Header("P4(Top Right)")]
    [SerializeField]private guiSpot BRback;
    [SerializeField]private guiSpot BRnext;
    [SerializeField]private guiSpot BRCont;



    private string[] horizontals = new string[4];
    private string[] aButtons = new string[4];
    private string[] bButtons = new string[4];
    private string[] selects = new string[4];
    private string[] starts = new string[4];
    private selector[] selectors = new selector[4];


    // Use this for initialization
    void Start ()
    {

        for(int i = 0; i < Input.GetJoystickNames().Length;i++)
        {
            horizontals[i] = "P" + (int)(i + 1) + "_Horizontal";
            aButtons[i] = "P" + (int)(i + 1) + "_ButtonA";
            bButtons[i] = "P" + (int)(i + 1) + "_ButtonB";
            selects[i] = "P" + (int)(i + 1) + "_Select";
            starts[i] = "P" + (int)(i + 1) + "_Start";
            selectors[i] = GameObject.Find("p" + (int)(i + 1)).GetComponent<selector>();
            selectors[i].index = PlayerPrefs.GetInt("p" + (int)(i + 1) + "Color");
        }


        choose.Start();
        TLback.Start();
        TLnext.Start();
        TRback.Start();
        TRnext.Start();
        play.Start();
        back.Start();
        BLback.Start();
        BLnext.Start();
        BRback.Start();
        BRnext.Start();
        TLCont.Start();
        TRCont.Start();
        BLCont.Start();
        BRCont.Start();
    }


    void Update()
    {
        for (int i = 0; i < Input.GetJoystickNames().Length; i++)
        {
            if (Input.GetButtonDown(aButtons[i]))
            {
                Debug.Log("pressing a");
                //load level at index one, should be set to the first race
                Application.LoadLevel(1);
            }
            if (Input.GetButtonDown(bButtons[i]))
            {
                Debug.Log("pressing b");
                //load level at index zero, should be set to menu
                Application.LoadLevel(0);
            }

            if (Input.GetAxis(horizontals[i]) < -0.5)
            {
                Debug.Log("going left");
                rchLft[i] = true;
                if (rchLft[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        selectors[i].SwitchB();
                        PlayerPrefs.SetInt("p" + (int)(i + 1) + "Color", selectors[i].index);
                        tmHt[i] = true;
                        timer[i] = 0;
                    }
                    timer[i] = timer[i] + Time.deltaTime;
                }
            }
            else if (Input.GetAxis(horizontals[i]) > 0.5)
            {
                Debug.Log("going right");
                rchRht[i] = true;
                if(rchRht[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        selectors[i].Switch();
                        PlayerPrefs.SetInt("p" + (int)(i + 1) + "Color", selectors[i].index);
                        tmHt[i] = true;
                        timer[i] = 0;
                    }
                    timer[i] = timer[i] + Time.deltaTime;
                }
            }
            else
            {
                if(!tmHt[i]&& rchLft[i])
                {
                    selectors[i].Switch();
                    PlayerPrefs.SetInt("p" + (int)(i + 1) + "Color", selectors[i].index);
                }
                if(!tmHt[i] && rchRht[i])
                {
                    selectors[i].SwitchB();
                    PlayerPrefs.SetInt("p" + (int)(i + 1) + "Color", selectors[i].index);
                }
                rchLft[i] = false;
                rchRht[i] = false;
                tmHt[i] = false;
                timer[i] = 0;
            }
        }
    }



    void OnGUI()
    {
        GUI.Box(new Rect(choose.x, choose.y, choose.width, choose.height), choose.text, choose.style);
        
        if (GUI.Button(new Rect(back.x, back.y, back.width, back.height), back.text, back.style))
        {
            //load level at index one, should be set to the first level
            Application.LoadLevel(0);
        }
        if (GUI.Button(new Rect(play.x, play.y, play.width, play.height), play.text, play.style))
        {
            //load level at index one, should be set to the first level
            Application.LoadLevel(1);
        }
        /*
        if (GUI.Button(new Rect(TLback.x, TLback.y, TLback.width, TLback.height), TLback.text, TLback.style))
        {
            selectors[1].SwitchB();
            //player prefs saves data ouside of a scene so it can be retreived anywhere
            //the first value is a string that is a key, use the key to find the value
            PlayerPrefs.SetInt("p1Color", selectors[1].index);
        }

        if (GUI.Button(new Rect(TLnext.x, TLnext.y, TLnext.width, TLnext.height), TLnext.text, TLnext.style))
        {
            selectors[1].Switch();
            PlayerPrefs.SetInt("p1Color", selectors[1].index);
        }

        if (GUI.Button(new Rect(TRback.x, TRback.y, TRback.width, TRback.height), TRback.text, TRback.style))
        {
            selectors[2].SwitchB();
            PlayerPrefs.SetInt("p2Color", selectors[2].index);
        }

        if (GUI.Button(new Rect(TRnext.x, TRnext.y, TRnext.width, TRnext.height), TRnext.text, TRnext.style))
        {
            selectors[2].Switch();
            PlayerPrefs.SetInt("p2Color", selectors[2].index);
        }
        */
    }
}
