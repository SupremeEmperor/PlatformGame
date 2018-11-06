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
    public Transform leftBound;
    public Transform rightBound;
    private int count;
    public int FrameMovement;
    private Vector2 MoveRight;
    private Vector2 MoveLeft;
    private bool MovingRight = true;
    private bool MovingLeft = false;
    

    // Use this for initialization
    void Start ()
    {
        /*  anim = gameObject.GetComponent<Animator>();
          sr = GetComponent<SpriteRenderer>();
          m_Velocity = Vector3.zero;*/
        MoveLeft = new Vector2(-HorizontalMove, m_RigidBody2D.velocity.y);
        MoveRight = new Vector2(HorizontalMove, m_RigidBody2D.velocity.y);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        //Debug.Log(transform.position.x > leftBound.position.x);
        if (transform.position.x < leftBound.position.x)
        {
            //m_RigidBody2D.velocity = new Vector2(0, m_RigidBody2D.velocity.y);
            flipRight();
            print("moving left = " + MovingLeft);
            print("moving right = " + MovingRight);
        }
        else if (transform.position.x > rightBound.position.x)
        {
            //m_RigidBody2D.velocity = new Vector2(0, m_RigidBody2D.velocity.y);
            flipLeft();
            print("this happened");
            print("moving left = " + MovingLeft);
            print("moving right = " + MovingRight);
        }
        if (MovingRight && MovingLeft == false)
        {
            m_RigidBody2D.velocity = MoveRight;
        }
        if (MovingLeft && MovingRight == false)
        {
            m_RigidBody2D.velocity = MoveLeft;
        }


    }
    private void flipRight()
    {
        MovingRight = true;
        MovingLeft = false;
    }

    private void flipLeft()
    {
        MovingLeft = true;
        MovingRight = false
            ;
    }

}
