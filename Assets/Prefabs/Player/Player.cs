using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -15f;
    private float jumpFrames = 0.0f;
    private float MAX_JUMP_FRAMES = 60.0f;
    private bool canHitBall = false;

    public Court court;
    public Court leftCourt;
    public Ball ball;
    public HitBall hitbox;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetKey("j") && jumpFrames < MAX_JUMP_FRAMES)
        {
            playerVelocity.y = 0.0f;
            playerVelocity.y += jumpHeight * 5.0f;
            jumpFrames += 1.0f;

        } else if (Input.GetKeyUp("j"))
        {
            jumpFrames = MAX_JUMP_FRAMES;

        } else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        // print("canHitBall: " + canHitBall);
        if (Input.GetKeyDown("k") && hitbox.GetCanHitBall()) 
        {
            Vector3 randPoint = court.GetRandomPoint();
            ball.HitBall(randPoint, transform.position);
        }

        if (Input.GetKeyDown("space"))
        {
            leftCourt.GetRandomPoint();
        }

        Vector3 down = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, down, 1.1f) && jumpFrames != 0.0f)
            jumpFrames = 0.0f;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void SetCanHitBall(bool _canHitBall)
    {
        canHitBall = _canHitBall;
    }

    public bool GetCanHitBall()
    {
        return canHitBall;
    }
}
