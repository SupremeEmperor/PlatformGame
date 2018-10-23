using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafProjectile : MonoBehaviour
{
    //private Rigidbody2D WeaponRigidBody;
    private GameObject leaf;
    private BoxCollider2D hitbox;
    //public float speed;
    //public Moving PlayerMovingScript;
    //public Vector2 Direction;

    // Use this for initialization
    void Start()
    {
        //NEEDS FIX ASAP
        //WeaponRigidBody = GetComponent<Rigidbody2D>();
        leaf = GetComponent<GameObject>();
        hitbox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void FixedUpdate()
    {
        WeaponRigidBody.velocity = (Direction * speed);
    }
    */

        //I HAVE NO IDEA HOW THIS WORKS ILL FIX IT LATER
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("k");
        Destroy(leaf);
    }
}
