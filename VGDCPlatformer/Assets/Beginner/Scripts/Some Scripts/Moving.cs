using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private BoxCollider2D PlayerBox;
    private Vector3 m_Velocity;//stores speed of char
    public Rigidbody2D m_RigidBody2D;
    public float RunSpeed = 15f;//changes speed
    public float HorizontalMove = 0f;//this is the speed
    public float m_JumpForce = 200f;
    public Animator anim;
    private SpriteRenderer sr;
    public LayerMask GroundLayer;
    public bool FaceRight;
    public int numJumps;

	// Use this for initialization
	void Start ()
    {
        FaceRight = true;
        PlayerBox = GetComponent<BoxCollider2D>();
        anim = gameObject.GetComponent<Animator>(); 
        sr = GetComponent<SpriteRenderer>();
        m_Velocity = Vector3.zero;
	}

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        if (HorizontalInput != 0)
        {
            //This flips the player model depending on the direction they are going
            if (HorizontalInput == 1)
            {
                sr.flipX = false;
                FaceRight = true;
            }
            else
            {
                sr.flipX = true;
                FaceRight = false;
            }
            HorizontalMove = HorizontalInput * RunSpeed;
            //This causes the running animation to play
            anim.SetBool("running", true);
        }
        else
        {
            //This causes the running animation to stop
            anim.SetBool("running", false);
            //This removes all momentum
            HorizontalMove = 0;
        }

        if (m_RigidBody2D.velocity.y != 0)
        {
            //This causes the jumping animation to play
            anim.SetBool("jumping", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            //Double jump works by having a variable that counts down everytime the player jumps. 
            //If you have a better method, go ahead and implement it.
            //Ground check via raycast
            if (IsGrounded())
            {
                //anim.SetBool("jumping", true);
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
                m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));               
            }
            else if (/*IsGrounded()*/numJumps > 0)
            {
                //anim.SetBool("jumping", true);
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
                m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce * 3 / 4));
                numJumps -= 1;
            }
        }
        else if (IsGrounded())
        {
            //This causes the jumping animation to stop
            anim.SetBool("jumping", false);
            numJumps = 1;
        }
    }
    void FixedUpdate()
    {
        //sets the movement of character
        Vector3 targetVelocity = new Vector2(HorizontalMove * RunSpeed * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
       // Debug.Log(m_RigidBody2D.velocity);
    }

    bool IsGrounded()
    {
        //Uses the boundaries of the player box collider to spawn the ray start locations'''
        Vector2 StartPosition1 = PlayerBox.bounds.center - PlayerBox.bounds.extents;
        Vector2 StartPosition2 = PlayerBox.bounds.center + new Vector3(PlayerBox.bounds.extents.x, -PlayerBox.bounds.extents.y, 0);
            //Vector2 StartPosition1 = new Vector2 (LeftBound.x, LeftBound.y);
            //Vector2 StartPosition2 = new Vector2 (RightBound.x, RightBound.y);
        Vector2 Direction = Vector2.down;
        //Distance of ray
        float Distance = .15f;
        Debug.DrawRay(StartPosition1, Distance * Direction, Color.red);
        Debug.DrawRay(StartPosition2, Distance * Direction, Color.red);
        //Checks to see if it collided with an object in the ground layer
        RaycastHit2D hitground1 = Physics2D.Raycast(StartPosition1, Direction, Distance, GroundLayer);
        RaycastHit2D hitground2 = Physics2D.Raycast(StartPosition2, Direction, Distance, GroundLayer);
            //Debug.Log(hitground1.collider.name);
        //if it is colliding with something, returns true
        if (hitground1.collider || hitground2.collider != null)
        {
         //   Debug.Log(hitground1.collider.name);
            return true;
        }
        return false;
    }
}
