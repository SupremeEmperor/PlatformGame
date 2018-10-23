using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
 //   private BoxCollider2D PlayerBox;
  /*  private Vector3 m_Velocity;//stores speed of char
 */ public Rigidbody2D m_RigidBody2D;
    public float RunSpeed = 15f;//changes speed 
    public float HorizontalMove = 0f;//this is the speed
 //   public float m_JumpForce = 200f;
   /* public Animator anim;
    private SpriteRenderer sr;
    public LayerMask GroundLayer; */
    //private bool inBounds;
    public float leftBound;
    public float rightBound;
    private int count;
    public int FrameMovement;
    public bool MoveRight;
    
    // Use this for initialization
    void Start ()
    {
      /*  anim = gameObject.GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        m_Velocity = Vector3.zero;*/
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        Debug.Log(transform.position.x > leftBound);
        if (count < FrameMovement)// || transform.position.x < rightBound)
        {
            m_RigidBody2D.velocity = new Vector2(HorizontalMove, m_RigidBody2D.velocity.y);
            count++;
        }
        else if (count > 0)
        {
            m_RigidBody2D.velocity = new Vector2(-HorizontalMove, m_RigidBody2D.velocity.y);
            count--;
        }


    }
}
