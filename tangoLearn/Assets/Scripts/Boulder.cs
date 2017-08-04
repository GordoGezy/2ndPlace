using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (boulderDespawn ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator boulderDespawn() {
		yield return new WaitForSeconds (20);
		Destroy (gameObject);
	}
}
