using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour {

    private BoxCollider2D PlayerBox;
    private Vector3 m_Velocity;//stores speed of char
    public Rigidbody2D m_RigidBody2D;
    public float RunSpeed = 15f;//changes speed
    public float HorizontalMove = 0f;//this is the speed
    public float m_JumpForce = 200f;
    public Animator anim;
    private SpriteRenderer sr;
    public LayerMask GroundLayer;

	// Use this for initialization
	void Start ()
    {
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
            if (HorizontalInput == 1)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
            HorizontalMove = HorizontalInput * RunSpeed;
            anim.SetBool("running", true);
        }
        else
        {
            anim.SetBool("running", false);
            HorizontalMove = 0;
        }

        if (m_RigidBody2D.velocity.y != 0)
        {
            anim.SetBool("jumping", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            //Ground check via raycast
            if (IsGrounded())
            {
                //anim.SetBool("jumping", true);
                m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, 0);
                m_RigidBody2D.AddForce(new Vector2(m_RigidBody2D.velocity.x, m_JumpForce));
            }
        }
        else if (IsGrounded())
        {
            anim.SetBool("jumping", false);
        }
    }
    void FixedUpdate()
    {
        Vector3 targetVelocity = new Vector2(HorizontalMove * RunSpeed * Time.fixedDeltaTime, m_RigidBody2D.velocity.y);
        m_RigidBody2D.velocity = targetVelocity;
       // Debug.Log(m_RigidBody2D.velocity);
    }

    bool IsGrounded()
    {
        Vector2 StartPosition1 = PlayerBox.bounds.center - PlayerBox.bounds.extents;
        Vector2 StartPosition2 = PlayerBox.bounds.center + new Vector3(PlayerBox.bounds.extents.x, -PlayerBox.bounds.extents.y, 0);
        //Vector2 StartPosition1 = new Vector2 (LeftBound.x, LeftBound.y);
        //Vector2 StartPosition2 = new Vector2 (RightBound.x, RightBound.y);
        Vector2 Direction = Vector2.down;
        float Distance = .15f;
        Debug.DrawRay(StartPosition1, Distance * Direction, Color.red);
        Debug.DrawRay(StartPosition2, Distance * Direction, Color.red);
        RaycastHit2D hitground1 = Physics2D.Raycast(StartPosition1, Direction, Distance, GroundLayer);
        RaycastHit2D hitground2 = Physics2D.Raycast(StartPosition2, Direction, Distance, GroundLayer);
        //Debug.Log(hitground1.collider.name);
        if (hitground1.collider || hitground2.collider != null)
        {
         //   Debug.Log(hitground1.collider.name);
            return true;
        }
        return false;
    }
}
