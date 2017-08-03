using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Text timer;
    private float runTime;


    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        runTime = 0;

    }

    // Update is called once per frame
    void Update () {

        runTime += Time.deltaTime;

        string minutes = (Mathf.Floor(runTime / 60) >= 10) ? (Convert.ToString(Mathf.Floor(runTime / 60))) : "0" + (Convert.ToString(Mathf.Floor(runTime / 60)));
        string seconds = (Mathf.Floor(runTime % 60) >= 10) ? (Convert.ToString(Mathf.Floor(runTime % 60))) : "0" + (Convert.ToString(Mathf.Floor(runTime % 60)));
        string mSeconds = (Math.Round(runTime - Mathf.Floor(runTime), 2) * 100 >= 0) ? Convert.ToString(Math.Round(runTime - Mathf.Floor(runTime), 2) * 100) : "0" + Convert.ToString(Math.Round(runTime - Mathf.Floor(runTime), 2) * 100);

        timer.text = minutes + ":" + seconds + ":" + mSeconds;
    }

    public void resetTime() { runTime = 0;  }
    public void addTime(float addTime) { runTime += addTime; }
}
