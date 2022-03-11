using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    public Rigidbody2D rig;
    public bool isLeft;
    //public bool isRight;
    public bool isDown;
    // Start is called before the first frame update
  
    void Start()
    {
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
        //    if (!GameController.getInstance().canPlay())
        //        return;

        rig.velocity = dir * speed * Time.deltaTime;

        if(transform.position.x > 5 && !isLeft)
        {
            dir = new Vector2(-dir.x, dir.y);
            isLeft = true;
        }
        if(transform.position.x < -5 && isLeft)
        {
            dir = new Vector2(-dir.x, dir.y);
            isLeft = false;
        }

        if(transform.position.y > 8 && !isDown)
        {
            dir = new Vector2(dir.x, -dir.y);
            isDown = true;
        }
        if (transform.position.y < -1)
        {
            Debug.Log("fail");
            resetBall();                     
        }
    }

    public void SetDirection(Vector3 target)
    {
        Vector2 dirTarget = new Vector2();           

        dirTarget = transform.position - target;      
        dirTarget.Normalize();                        

        dir = dirTarget;                        

        if (dir.x > 0)                          
            isLeft = false;
        if (dir.x < 0)                          
            isLeft = true;
        if (dir.y > 0)                          
            isDown = false;
        if (dir.y < 0)                          
            isDown = true;
    }

    public void resetBall()
    {
        speed = 0;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        GameController.getInstance().setPlayGame(false);
        this.transform.position = new Vector2(0, 0.3f);
        GameController.getInstance().Square.GetComponent<Square>().resetSquare();
    }

    public void startBall()
    {
        Debug.Log("start");
        speed = 1000;
        GameController.getInstance().setPlayGame(true);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}
