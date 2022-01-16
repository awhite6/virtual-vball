using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 ballVelocity = new Vector3(0, 0, 0);
    private float gravityValue = -3f;
    private float maxGravity = -3f;
    private float ballSpeed = 3f;
    private Rigidbody rb;
    private bool isHit = false;
    private Vector3 servePosition = new Vector3(0, 0, 0);
    private Vector3 targetPos = new Vector3(4.320799f, 13f, -25f);
    private Vector3 startPos = new Vector3(0, 0, 0);
    private bool isServing = true;
    private float startTime;

    private float hitForce = 0f;
    private float gravityForce = 0.01f;
    private float maxHitForce = 0.33f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isServing)
        {
            int hitBoxLayer = 1 << 3;
            Vector3 down = transform.TransformDirection(Vector3.down);
            if (!Physics.Raycast(transform.position, down, 0.7f, ~hitBoxLayer))
                rb.MovePosition(transform.position + (new Vector3(0, -4, 0) * Time.deltaTime));

        } else {
          
            // this is doing weird bit shift stuff i don't really get it its nerd shit
            int hitBoxLayer = 1 << 3;
            Vector3 down = transform.TransformDirection(Vector3.down);
            if (!Physics.Raycast(transform.position, down, 0.7f, ~hitBoxLayer)) 
            {
                
                Vector3 horizontalMovement = Vector3.Lerp(transform.position, targetPos, 1.5f*Time.deltaTime);

                float height = transform.position.y;
                height += hitForce;
                if (hitForce > maxGravity)
                {
                    hitForce -= gravityForce;
                }                   

                transform.position = new Vector3(horizontalMovement.x, height, horizontalMovement.z);
            } else 
            {
                transform.position = new Vector3(0, 5, 0);
                ballVelocity = new Vector3(0, 0, 0);
                isServing = true;
            }

        }
        


    }

    private float GetDistanceCovered()
    {
        return (Time.time - startTime) * ballSpeed;
    }

    public void HitBall(Vector3 newLandingSpot, Vector3 _startPos)
    {
        print("start pos: " + transform.position);
        print("end pos: " + newLandingSpot);
        hitForce = maxHitForce;
        targetPos = newLandingSpot;
        startPos = transform.position;
        ballVelocity.y = 0f;
        if (isServing) 
        {
            isServing = false;
        }
    }

}
