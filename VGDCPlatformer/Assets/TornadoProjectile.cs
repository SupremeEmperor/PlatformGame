using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoProjectile : MonoBehaviour {
    private ThrowWeapon Throwscript;
    public GameObject Player;
    public string ObjectName;
    public int tornadoduration;

	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find(ObjectName);
        Throwscript = Player.gameObject.GetComponent<ThrowWeapon>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Destroy(gameObject, tornadoduration);
	}

    private void OnDestroy()
    {
        Throwscript.tornadocount -= 1;
    }
}
