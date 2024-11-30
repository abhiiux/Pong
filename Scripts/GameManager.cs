using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text Left;
    public Text Right;
    public GameObject over;
    public GameObject button;
    public Rigidbody2D ball;
    public Ball ballScript;
    Vector2 Direction;
    int scoreL;
    int scoreR;
        void Update()
    {
        if(Input.GetKeyUp(KeyCode.V))
        {
            Debug.Log(Direction);
        }
    }

    public void LeftScore()
    {
        scoreL++ ;
        Left.text = scoreL.ToString();
    }
    public void RightScore()
    {
        scoreR++ ;
        Right.text = scoreR.ToString();
    }
    public void PlayAgain()
    {
        ResetText();
       over.SetActive(false);
       button.SetActive(false);  
       ResetBall();
       ballScript.Push(Direction);     
    }
    public void GameOver()
    {
       over.SetActive(true);
       button.SetActive(true);

       Direction = ballScript.direction;
    }
    public void ResetText()
    {
        scoreL = 0 ;
        scoreR = 0 ;
        Left.text = "0";
        Right.text = "0";
    }
    public void ResetBall()
    {
        ball.position = Vector2.zero;
        ball.velocity = Vector2.zero;
        ballScript.IsballMoving = false;
    }
}
