﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour {
    public Moving PlayerDirection;
    public GameObject ThrowingWeapon1;
    public GameObject ThrowingWeapon2;
    private Vector3 StartLocation;
    private SpriteRenderer sr;
    public string Weapon;

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (PlayerDirection.FaceRight)
            {
                StartLocation = new Vector3(transform.position.x + .7f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
            }
            else
            {
                StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                sr = projectile.GetComponent<SpriteRenderer>();
                sr.flipX = true;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            }
        }
        if(Input.GetButtonDown("Fire2")){
             if (PlayerDirection.FaceRight){
                StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon2,transform.position,Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10,20); 
            } else{
                StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon2,transform.position,Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-10,20);
            } 
        }
	}
}
