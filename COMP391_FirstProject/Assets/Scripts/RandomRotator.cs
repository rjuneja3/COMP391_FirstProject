﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
    public float tumble;

    private Rigidbody2D rBody;
    // Use this for initialization
    void Start () {
        rBody = GetComponent<Rigidbody2D>();
        rBody.angularVelocity = Random.value;
        
	}
	
	
}