using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{

    public Player playerRed;
    public Ball ball;
    public Court leftCourt;
    public Court rightCourt;

    public enum State
    {
        Serve = 0,
        Play = 1
    }

    public int currentState = (int) State.Serve;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentState()
    {
        return currentState;
    }
}
