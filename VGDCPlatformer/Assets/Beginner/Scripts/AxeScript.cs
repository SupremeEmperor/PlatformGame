using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour {
	public GameObject ThrownAxe;
    private SpriteRenderer sr;
	private BoxCollider2D hitbox;
	public Rigidbody2D rb;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "hitbox")
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
        if (other.gameObject.tag != "checkPoint" || other.gameObject.tag != "Gizmos")
        {
            Destroy(gameObject);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
