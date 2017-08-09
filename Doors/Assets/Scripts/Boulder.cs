using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        rb.velocity = Vector3.back;
		rb.AddForce (new Vector3(0, -100F, 0));
	}

}
