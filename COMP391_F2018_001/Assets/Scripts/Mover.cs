using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    // Variable Declarations
    public float speed;

	// Use this for initialization
	void Start () {
        Rigidbody2D rBody = GetComponent<Rigidbody2D>();
        rBody.velocity = transform.right * speed;
	}
}
