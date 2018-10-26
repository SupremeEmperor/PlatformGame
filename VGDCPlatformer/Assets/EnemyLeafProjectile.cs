using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeafProjectile : MonoBehaviour
{
    //private Rigidbody2D WeaponRigidBody;
    private GameObject Enemyleaf;
    private BoxCollider2D Enemyhitbox;
    //public float speed;
    //public Moving PlayerMovingScript;
    //public Vector2 Direction;
    private Health HealthScript;
    // Use this for initialization
    void Start()
    {

        //WeaponRigidBody = GetComponent<Rigidbody2D>();
        Enemyleaf = GetComponent<GameObject>();
        Enemyhitbox = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            try
            {
                Health hp = other.gameObject.GetComponent<Health>();
                hp.HP -= 20;
            }
            catch
            {

            }
        }
        Debug.Log("k"); //Just for debugging
        if (other.gameObject.tag != "checkPoint" || other.gameObject.tag != "Gizmos" || other.gameObject.tag != "hitbox")
        {
            Destroy(gameObject);
        }
    }
}
