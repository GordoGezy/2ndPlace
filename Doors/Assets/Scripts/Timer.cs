using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
	public bool isFinished;
    private float runTime;
	String scoreStore;


    // Use this for initialization
    void Start () {
        timer = GameObject.Find("Timer").GetComponent<Text>();
        runTime = 0;
		isFinished = false;

    }

    // Update is called once per frame
    void Update () {
		runTime += Time.deltaTime;

		string minutes = (Mathf.Floor (runTime / 60) >= 10) ? (Convert.ToString (Mathf.Floor (runTime / 60))) : "0" + (Convert.ToString (Mathf.Floor (runTime / 60)));
		string seconds = (Mathf.Floor (runTime % 60) >= 10) ? (Convert.ToString (Mathf.Floor (runTime % 60))) : "0" + (Convert.ToString (Mathf.Floor (runTime % 60)));
		string mSeconds = (Math.Round (runTime - Mathf.Floor (runTime), 2) * 100 >= 0) ? Convert.ToString (Math.Round (runTime - Mathf.Floor (runTime), 2) * 100) : "0" + Convert.ToString (Math.Round (runTime - Mathf.Floor (runTime), 2) * 100);
		if (isFinished == false)
		{
			timer.text = minutes + ":" + seconds + ":" + mSeconds;
		} else
		{
			scoreStore = minutes + ":" + seconds + ":" + mSeconds;
			GlobalControl.Instance.timer = scoreStore;
			GlobalControl.Instance.Seconds = Convert.ToInt32(Mathf.Floor(runTime%60));
			GlobalControl.Instance.Minutes = Convert.ToInt32(Mathf.Floor(runTime/60));
			GlobalControl.Instance.MSeconds = Convert.ToInt32(Math.Round(runTime-Mathf.Floor(runTime), 2) * 100);
		}
    }

    public void resetTime() { runTime = 0;  }
    public void addTime(float addTime) { runTime += addTime; }
}
