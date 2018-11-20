﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnContact: MonoBehaviour
{
    public GameObject IceSpike;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            try
            {
                other.GetComponent<Freeze>().StartCoroutine("Frozen");
                Destroy(IceSpike, 2f);
            }
            catch
            {

            }
        }
    }
}
