using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : MonoBehaviour {

    public float dashDistance;
    public float dashSpeed;
    public float dashCoolDown;
    private bool isDashing;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Dash()
    {
        yield return null;
    }
}
