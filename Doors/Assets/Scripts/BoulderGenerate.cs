using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderGenerate : MonoBehaviour
{

	bool shouldStart = true;
	float number;
	public GameObject boulder;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (boulderSpawn ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameObject.FindGameObjectsWithTag ("boulder").Length <= 4 && shouldStart == true)
		{
			StartCoroutine(boulderSpawn ());
		}
	}

	IEnumerator boulderSpawn() 
	{
		shouldStart = false;
		yield return new WaitForSeconds (3);
		number = Random.Range(-75, 75)/100F;
		Vector3 spawnerPosition = transform.position;
		spawnerPosition.x += number;
		Instantiate (boulder, spawnerPosition, transform.rotation);
		shouldStart = true;

	}
}
