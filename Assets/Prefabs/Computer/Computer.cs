using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private Vector3 velocity;
    private float speed = 5.0f;
    private bool canHitBall = false;
    private Vector3 targetPos = new Vector3(0, 0, 0);
    private Vector3 startPos = new Vector3(0, 0, 0);

    public Court opponentCourt;
    public GameObject marker;
    public Ball ball;
    public HitBall hitbox;

    private int test = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (targetPos != marker.transform.position)
        // {
        //     startPos = transform.position;
        //     targetPos = markerPos;
        // } 


        if (hitbox.GetCanHitBall()) 
        {
            Vector3 randPoint = opponentCourt.GetRandomPoint();
            print("comp target point: " + randPoint);
            ball.HitBall(randPoint, transform.position);
            hitbox.SetCanHitBall(false);
        }

        targetPos = new Vector3(marker.transform.position.x, transform.position.y, marker.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    public void SetStartPos(Vector3 _startPos)
    {
        startPos = _startPos;
    }

    public void SetTargetPos(Vector3 _targetPos)
    {
        targetPos = _targetPos;
    }
}
