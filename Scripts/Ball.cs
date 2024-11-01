using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    bool IsballMoving = false;
    public float speed = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // int x = 0;
        // int y = 0;
        direction = new Vector2(1,1);
    }

    void Start()
    {
     Push();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            Push();
        }
    }

    public void Push()
    {
      if (!IsballMoving)
     {
      rb.AddForce(direction * speed);
     }
     else 
     {
        speed = 600f;
        rb.AddForce(speed);
     }
    }

}
