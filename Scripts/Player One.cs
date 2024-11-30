using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    LeftPaddle lp;
    Vector2 _direction;
    Rigidbody2D rb;
    public float speed;
    

    void Awake()
    {
        lp = new LeftPaddle();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _direction = lp.CheckForInput();
    }

    void FixedUpdate()
    {
        lp.Move(_direction, rb, speed);
    }
}
