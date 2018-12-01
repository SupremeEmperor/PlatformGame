using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanEnemy : MonoBehaviour
{

    public float speed;

    public float stoppingDistance;

    public bool faceRight;
    private Transform target;
    private float horiz;

    public Moving thePlayer;
    private bool isTargeting;
    public float spawnHeight;
    public float lead;
    private float holdLead;
    public GameObject icicles;
    // Use this for initialization
    void Start()
    {
        holdLead = lead;
        faceRight = false;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void FixedUpdate()
    {
         if (Input.GetKeyDown(KeyCode.R))//isTargeting)
         {
            if (thePlayer.HorizontalMove != 0)
            {
                if (thePlayer.FaceRight)
                {
                    lead = target.position.x + lead;
                }
                else if (!thePlayer.FaceRight)
                {
                    lead = target.position.x - lead;
                }
                Instantiate(icicles, new Vector2(lead, target.position.y + spawnHeight), Quaternion.identity);
                lead = holdLead;
            }
            else
            {
                Instantiate(icicles, new Vector2(target.position.x, target.position.y + spawnHeight), Quaternion.identity);
            }
        }


        if (transform.position.x > target.position.x && faceRight)
        {
            Flip();
            faceRight = false;
        }
        else if (transform.position.x < target.position.x && !faceRight)
        {
            Flip();
            faceRight = true;
        }
    }
}