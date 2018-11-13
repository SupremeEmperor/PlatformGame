using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public float OoB;
    public GameObject RespawnPointx;
    public Health HealthScript;
    //Health health = Player.GetComponent<Health>();
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (transform.position.y < OoB)
        {
            transform.position = RespawnPointx.transform.position;
            restartCurrentScene();
        }
    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
