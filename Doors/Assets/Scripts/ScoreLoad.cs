using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreLoad : MonoBehaviour
{
	string[] textSplit = new string[6];
	string seconds;
	string mSeconds;
	string minutes;
	string prevSeconds;
	string prevMinutes;
	string prevmSeconds;
	int nSeconds;
	int nMinutes;
	int nmSeconds;
	// Use this for initialization
	void Start ()
	{
		GameObject.Find ("Timer").GetComponent<Text> ().text = " Score: " + GlobalControl.Instance.timer;
		GameObject.Find ("GameMaster").GetComponent<WriteScore> ().readScore ();
		minutes = GameObject.Find ("GameMaster").GetComponent<WriteScore> ().Array [0];
		seconds = GameObject.Find ("GameMaster").GetComponent<WriteScore> ().Array [1];
		mSeconds = GameObject.Find ("GameMaster").GetComponent<WriteScore> ().Array [2];
		int.TryParse (minutes, out nMinutes);
		int.TryParse (seconds, out nSeconds);
		int.TryParse (mSeconds, out nmSeconds);
		if (nMinutes < 10)
		{
			minutes = "0" + minutes;
		}
		if (nSeconds < 10) 
		{
			seconds = "0" + seconds;
		}
		if (nmSeconds < 10)
		{
			mSeconds = "0" + mSeconds;
		}
		if ((GlobalControl.Instance.Minutes <= nMinutes) && (GlobalControl.Instance.Seconds <= nSeconds)) 
		{
			if (GlobalControl.Instance.Seconds < nSeconds)
			{
				GameObject.Find ("HighScore").GetComponent<Text> ().text = GameObject.Find ("HighScore").GetComponent<Text> ().text + minutes + ":" + seconds + ":" + mSeconds;
				GameObject.Find ("GameMaster").GetComponent<WriteScore> ().writeScore ();
			} else if (nSeconds == GlobalControl.Instance.Seconds)
			{
				if ( GlobalControl.Instance.MSeconds < nmSeconds)
				{
					GameObject.Find ("HighScore").GetComponent<Text> ().text = GameObject.Find ("HighScore").GetComponent<Text> ().text + minutes + ":" + seconds + ":" + mSeconds;
					GameObject.Find ("GameMaster").GetComponent<WriteScore> ().writeScore ();
				}
			}

		}else
		{
			GameObject.Find ("HighScore").GetComponent<Text> ().text = GameObject.Find ("HighScore").GetComponent<Text> ().text + minutes + ":" + seconds + ":" + mSeconds;
		for(int i = 0;i< GameObject.Find("GameMaster").GetComponent<WriteScore>().Array.Length; i++)
		{

			//GameObject.Find ("HighScore").GetComponent<Text> ().text += GameObject.Find("GameMaster").GetComponent<WriteScore>().Array [i] + ":";
			}
		}
	}
}
