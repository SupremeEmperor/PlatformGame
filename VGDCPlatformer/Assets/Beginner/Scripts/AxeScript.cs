using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {
	public GameObject ThrownAxe;

	public Rigidbody2D rb;
	private float Velocity;
	public string test;

	void Start () {
		//rb = GetComponent<Rigidbody2D>();
		Debug.Log("Testing this " + test);
		Velocity = 1f;
		rb.AddForce(new Vector2(Velocity,Velocity));
	}
	
	// Update is called once per frame
	void Update () {

	}
}
