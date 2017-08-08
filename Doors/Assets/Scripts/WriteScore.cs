using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteScore : MonoBehaviour
{
	public string fileName;
	private TextAsset scores;
	private StreamWriter writer;
	private StreamReader reader;
	public string[] Array;
	int arrayNumber = 0;
	string path = "Assets/Resources/test.txt";

	public void writeScore()
	{
		string[] Array = File.ReadAllLines(path);
		Array[0] = Convert.ToString(GlobalControl.Instance.Minutes);
		Array[1] = Convert.ToString(GlobalControl.Instance.Seconds);
		Array[2] = Convert.ToString(GlobalControl.Instance.MSeconds);
		File.WriteAllLines(path, Array);
	}
	public void readScore()
	{
		reader = new StreamReader ("Assets/Resources/test.txt");
		while(!reader.EndOfStream)
		{

			Array[arrayNumber] = reader.ReadLine( );
			arrayNumber++;
		}

		reader.Close( );  
	}
}
