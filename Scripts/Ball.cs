using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector]public Vector2 direction; 
    [HideInInspector]public bool IsballMoving = false;    
    public GameManager gameManager;
    public AudioManager audioManager;
    public float speed = 0f;
    public float impactSpeed = 0f;
        Rigidbody2D ball;

    void Awake()
    {
        ball = GetComponent<Rigidbody2D>();
        SetDirection();
    }

    void Start()
    {
     Push(direction);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Leftie")
        {
            gameManager.LeftScore();
            audioManager.HitPaddle();
            direction = new Vector2(1,0);
            Push(direction);
        }
        else if (collision.collider.tag == "Right")
        {
            gameManager.RightScore();
            audioManager.HitPaddle();
            direction = new Vector2(-1,0);
            Push(direction);
        }
        else
        {
            audioManager.HitBoundary(); 
        }
    }
    void OnTriggerEnter2D()
    {     
                 SetDirection();   
         gameManager.GameOver();
         audioManager.Over();
    }
    public void SetDirection()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f,-0.5f) : Random.Range(0.5f , 1.0f);
        direction = new Vector2(x, y);        
    }

    public void Push(Vector2 direction)
    {
      if (!IsballMoving)
     {
      ball.AddForce(direction * speed);
      IsballMoving = true;
     }
     else 
     {
        ball.AddForce(direction * impactSpeed);
     }
    }
}
