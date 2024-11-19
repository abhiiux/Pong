using UnityEngine;

public class Paddle 
{
    protected float speed ;
    protected Vector2 direction;
    protected int score;

    public void Move(Vector2 direction,Rigidbody2D rb, float speed)
    {
        if(direction.sqrMagnitude != 0)
        {
          rb.AddForce(direction * speed);
        }
    }
}

public class LeftPaddle : Paddle
{
    public Vector2 CheckForInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
            return direction;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.down;
            return direction;
        }
        else 
        {
            direction = Vector2.zero;
            return direction;
        }
    }

}
public class RightPaddle : Paddle
{
    public Vector2 CheckForInputTwo()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            direction = Vector2.up;
            return direction;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            direction = Vector2.down;
            return direction;
        }
        else{
            direction = Vector2.zero;
            return direction;
        }
    }
}
