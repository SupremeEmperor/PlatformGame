using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public TheEnemy Direction;
    public LayerMask P_Layer;
    private PolygonCollider2D Enemy;
    private Vector2 Face;
    private Vector3 StartLocation;
    public GameObject ThrowingWeapon1;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start ()
    {
        Enemy = GetComponent<PolygonCollider2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Direction.moveRight)
        {
            Face = Vector2.right;
            if (PlayerSpotted())
            {
                StartLocation = new Vector3(transform.position.x + 1f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(15, 0);
            }
        }
        else
        {
            Face = Vector2.left;
            if (PlayerSpotted())
            {
                StartLocation = new Vector3(transform.position.x - .7f, transform.position.y, 0);
                GameObject projectile = Instantiate(ThrowingWeapon1, StartLocation, Quaternion.identity);
                sr = projectile.GetComponent<SpriteRenderer>();
                sr.flipX = true;
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-15, 0);
            }
        }
	}

    bool PlayerSpotted()
    {
        Vector2 StartPosition = Enemy.bounds.center;
        float Distance = 2f;        
        Debug.DrawRay(StartPosition, Distance * Face, Color.red);
        RaycastHit2D SeePlayer = Physics2D.Raycast(StartPosition, Face, Distance, P_Layer);
        if (SeePlayer.collider != null)
        {
            //   Debug.Log(hitground1.collider.name);
            return true;
        }
        return false;
    }
}
