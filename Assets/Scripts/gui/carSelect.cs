using UnityEngine;
using System.Collections;

public class carSelect : MonoBehaviour {
    

    [SerializeField]
    private guiSpot choose;

    [SerializeField]
    private guiSpot play;

    [SerializeField]
    private guiSpot back;


    [Header("P1(Top Left)")]
    [SerializeField]
    private guiSpot TLback;
    [SerializeField]
    private guiSpot TLnext;
    private selector p1;

    [Header("P2(Top Right)")]
    [SerializeField]
    private guiSpot TRback;
    [SerializeField]
    private guiSpot TRnext;
    private selector p2;




// Use this for initialization
    void Start ()
    {

        choose.Start();
        TLback.Start();
        TLnext.Start();
        TRback.Start();
        TRnext.Start();
        play.Start();
        back.Start();
        p1 = GameObject.Find("p1").GetComponent<selector>();
        p2 = GameObject.Find("p2").GetComponent<selector>();
        p1.index = PlayerPrefs.GetInt("p1Color");
        p2.index = PlayerPrefs.GetInt("p2Color");
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

        if (GUI.Button(new Rect(TLback.x, TLback.y, TLback.width, TLback.height), TLback.text, TLback.style))
        {
            p1.SwitchB();
            //player prefs saves data ouside of a scene so it can be retreived anywhere
            //the first value is a string that is a key, use the key to find the value
            PlayerPrefs.SetInt("p1Color", p1.index);
        }

        if (GUI.Button(new Rect(TLnext.x, TLnext.y, TLnext.width, TLnext.height), TLnext.text, TLnext.style))
        {
            p1.Switch();
            PlayerPrefs.SetInt("p1Color", p1.index);
        }

        if (GUI.Button(new Rect(TRback.x, TRback.y, TRback.width, TRback.height), TRback.text, TRback.style))
        {
            p2.SwitchB();
            PlayerPrefs.SetInt("p2Color", p2.index);
        }

        if (GUI.Button(new Rect(TRnext.x, TRnext.y, TRnext.width, TRnext.height), TRnext.text, TRnext.style))
        {
            p2.Switch();
            PlayerPrefs.SetInt("p2Color", p2.index);
        }

    }
}
