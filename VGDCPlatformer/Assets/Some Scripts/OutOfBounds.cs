﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float OoB;
    public float RespawnPointx;
    public float RespawnPointy;
    public Health HealthScript;
    //Health health = Player.GetComponent<Health>();
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        if (transform.position.y < OoB)
        {
            transform.position = new Vector2(RespawnPointx, RespawnPointy);
            HealthScript.HP -= 20;
        }
    }
}