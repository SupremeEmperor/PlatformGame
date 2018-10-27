using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        //This should work, but it really doesnt.
        if (other.gameObject.tag == "floor")
        {
            Destroy(gameObject);
        }
        //if this object touches an enemy's hurtbox
        if (other.gameObject.tag == "Player")
        {
            try
            {
                Health hp = other.gameObject.GetComponent<Health>();
                hp.HP -= 40;
            }
            catch
            {

            }
        }
    }
}
