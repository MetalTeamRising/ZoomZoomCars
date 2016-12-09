using UnityEngine;
using System.Collections;

public class carSelect : MonoBehaviour {


    //enum for controlling screen
    private enum slctrTyp { bck, slct, frwrd };

    private slctrTyp[] slctrTyps = { slctrTyp.bck, slctrTyp.bck, slctrTyp.bck, slctrTyp.bck };
    private float[] timer = { 0,0,0,0 };
    private float maxTimer = .5f;
    private bool[] rchLft = {false, false, false, false};
    private bool[] rchRht = { false, false, false, false };
    private bool[] tmHt = { false, false, false, false };
    private Vector2[] readyvec = new Vector2[4];
    public int players = 0;
    private bool playerNumChange = false;



    [SerializeField]
    private guiSpot choose;

    [SerializeField]
    private guiSpot lone;

    [SerializeField]
    private guiSpot none;


    [SerializeField]
    private guiSpot ready;





    private string[] horizontals = new string[4];
    private string[] aButtons = new string[4];
    private string[] bButtons = new string[4];
    private string[] selects = new string[4];
    private string[] starts = new string[4];
    private selector[] selectors = new selector[4];


    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 4;i++)
        {
            horizontals[i] = "P" + (int)(i + 1) + "_Horizontal";
            aButtons[i] = "P" + (int)(i + 1) + "_ButtonA";
            bButtons[i] = "P" + (int)(i + 1) + "_ButtonB";
            selects[i] = "P" + (int)(i + 1) + "_Select";
            starts[i] = "P" + (int)(i + 1) + "_Start";
            selectors[i] = GameObject.Find("p" + (int)(i + 1)).GetComponent<selector>();
            selectors[i].index = PlayerPrefs.GetInt("p" + (int)(i + 1) + "Color");
            selectors[i].gameObject.SetActive(false);
        }


        choose.Start();
        lone.Start();
        none.Start();
        ready.Start();
    }

    void changePlaces()
    {
        switch (players)
        {
            case 0:
                break;
            case 1:
                readyvec[0] = new Vector2(0, 0);
                if (selectors[0].gameObject.activeSelf)
                {
                    selectors[0].gameObject.transform.position = new Vector3(0, 0, 0);
                    selectors[0].gameObject.transform.localScale = new Vector3(2, 2, 2);
                }

                break;
            case 2:

                readyvec[0] = new Vector2(0.25f * Screen.width, 0);
                readyvec[1] = new Vector2(-0.25f * Screen.width, 0);
                if (selectors[0].gameObject.activeSelf)
                {
                    selectors[0].gameObject.transform.position = new Vector3(-3, 0, 0);
                    selectors[0].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                if (selectors[1].gameObject.activeSelf)
                {
                    selectors[1].gameObject.transform.position = new Vector3(3, 0, 0);
                    selectors[1].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                    break;
                case 3:
                if (selectors[0].gameObject.activeSelf)
                {
                    selectors[0].gameObject.transform.position = new Vector3(-3, 2.5f, 0);
                    selectors[0].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (selectors[1].gameObject.activeSelf)
                {
                    selectors[1].gameObject.transform.position = new Vector3(3, 2.5f, 0);
                    selectors[1].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (selectors[2].gameObject.activeSelf)
                {
                    selectors[2].gameObject.transform.position = new Vector3(0, -0.6f, 0);
                    selectors[2].gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }
                    break;
                case 4:

                if (selectors[0].gameObject.activeSelf)
                {
                    selectors[0].gameObject.transform.position = new Vector3(-3, 2.5f, 0);
                    selectors[0].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                if (selectors[1].gameObject.activeSelf)
                {
                    selectors[1].gameObject.transform.position = new Vector3(3, 2.5f, 0);
                    selectors[1].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

                if (selectors[2].gameObject.activeSelf)
                {
                    selectors[2].gameObject.transform.position = new Vector3(-3, -0.6f, 0);
                    selectors[2].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }

                if (selectors[3].gameObject.activeSelf)
                {
                    selectors[3].gameObject.transform.position = new Vector3(3, -0.6f, 0);
                    selectors[3].gameObject.transform.localScale = new Vector3(1, 1, 1);
                }
                    break;
                default:

                    break;
        }

    }

    void Update()
    {
        switch (players)
        {
            case 0:
                break;
            case 1:
                readyvec[0] = new Vector2(0.5f*Screen.width - ready.width / 2, 0.5f * Screen.height - ready.height / 2);
                break;
            case 2:
                readyvec[0] = new Vector2(0.25f * Screen.width - ready.width / 2, Screen.height - ready.height / 2);
                readyvec[1] = new Vector2(-0.25f * Screen.width - ready.width / 2, Screen.height - ready.height / 2);
                break;
            case 3:
                readyvec[0] = new Vector2(0.25f * Screen.width - ready.width/2, 0.25f * Screen.height - ready.height / 2);
                readyvec[1] = new Vector2(-0.25f * Screen.width - ready.width / 2, 0.25f * Screen.height - ready.height / 2);
                readyvec[2] = new Vector2(0.25f * Screen.width - ready.width / 2, -0.25f * Screen.height - ready.height / 2);
                break;
            case 4:
                readyvec[0] = new Vector2(0.25f * Screen.width - ready.width / 2, 0.25f * Screen.height - ready.height / 2);
                readyvec[1] = new Vector2(-0.25f * Screen.width - ready.width / 2, 0.25f * Screen.height - ready.height / 2);
                readyvec[2] = new Vector2(0.25f * Screen.width - ready.width / 2, -0.25f * Screen.height - ready.height / 2);
                readyvec[3] = new Vector2(-0.25f * Screen.width - ready.width / 2, -0.25f * Screen.height - ready.height / 2);
                break;
            default:

                break;
        }

        for (int i = 0; i < 4; i++)
        {
            if (Input.GetButtonDown(aButtons[i]))
            {
                //load level at index one, should be set to the first race
                switch (slctrTyps[i])
                {
                    case slctrTyp.bck:
                        selectors[i].gameObject.SetActive(true);    
                        slctrTyps[i] = slctrTyp.slct;
                        players++;
                        changePlaces();
                        break;
                    case slctrTyp.slct:
                        selectors[i].gameObject.SetActive(false);
                        slctrTyps[i] = slctrTyp.frwrd;
                        changePlaces();
                        break;
                    case slctrTyp.frwrd:
                        for(int j = 0; j < 4; j++)
                        {
                            if(selectors[i].gameObject.activeSelf)
                            {
                                if(slctrTyps[i] == slctrTyp.frwrd)
                                {
                                    Application.LoadLevel(3);
                                }
                            }
                        }
                            Application.LoadLevel(3);
                        break;
                    default:
                        break;
                }
                PlayerPrefs.SetInt("players", players);
            }
            if (Input.GetButtonDown(bButtons[i]))
            {

                //load level at index one, should be set to the first race
                switch (slctrTyps[i])
                {
                    case slctrTyp.bck:
                        Application.LoadLevel(0);
                        break;
                    case slctrTyp.slct:
                        selectors[i].gameObject.SetActive(false);
                        slctrTyps[i] = slctrTyp.bck;
                        players--;
                        changePlaces();
                        break;
                    case slctrTyp.frwrd:
                        selectors[i].gameObject.SetActive(true);
                        slctrTyps[i] = slctrTyp.slct;
                        players++;
                        changePlaces();
                        break;
                    default:
                        break;
                }
                PlayerPrefs.SetInt("players", players);
            }

            if (Input.GetAxis(horizontals[i]) < -0.5)
            {
                rchLft[i] = true;
                if (rchLft[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        selectors[i].SwitchB();
                        PlayerPrefs.SetInt("p" + (int)(players-i + 1) + "Color", selectors[i].index);
                        tmHt[i] = true;
                        timer[i] = 0;
                    }
                    timer[i] = timer[i] + Time.deltaTime;
                }
            }
            else if (Input.GetAxis(horizontals[i]) > 0.5)
            {
                rchRht[i] = true;
                if(rchRht[i])
                {
                    if (timer[i] > maxTimer)
                    {
                        selectors[i].Switch();
                        PlayerPrefs.SetInt("p" + (int)(players-i + 1) + "Color", selectors[i].index);
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
                    PlayerPrefs.SetInt("p" + (int)(players-i + 1) + "Color", selectors[i].index);
                }
                if(!tmHt[i] && rchRht[i])
                {
                    selectors[i].SwitchB();
                    PlayerPrefs.SetInt("p" + (int)(players-i + 1) + "Color", selectors[i].index);
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
        for(int i = 0; i<4; i++)
        {
            if(slctrTyps[i]==slctrTyp.frwrd)
            {
                GUI.Box(new Rect(readyvec[i].x, readyvec[i].y, ready.width, ready.height), ready.text, ready.style);
            }
        }
        //shows text if based on amount of people plugged in
        switch (players)
        {
            case 0:
                if(slctrTyps[0]==slctrTyp.bck&& slctrTyps[1] == slctrTyp.bck&& slctrTyps[2] == slctrTyp.bck&& slctrTyps[3] == slctrTyp.bck)
                {
                    GUI.Box(new Rect(none.x, none.y, none.width, none.height), none.text, none.style);
                }
                break;
            case 1:
                GUI.Box(new Rect(lone.x, lone.y, lone.width, lone.height), lone.text, lone.style);
                break;
            default:

                break;
        }
    }
}
