using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    RightPaddle rp;
    Rigidbody2D rb;
    Vector2 __direction;
    public float Speed ;
 
    void Awake()
    {
        rp = new RightPaddle();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        __direction = rp.CheckForInputTwo();
    }

    void FixedUpdate()
    {
        rp.Move(__direction,rb,Speed);
    }
}
