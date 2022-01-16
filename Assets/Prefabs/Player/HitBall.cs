using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBall : MonoBehaviour
{
    public Player player;
    public bool canHitBall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Ball")
            SetCanHitBall(true); 
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name == "Ball")
            SetCanHitBall(false);    
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
