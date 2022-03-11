using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    bool canDrag = false;
    public float speed;
    public float minClampX;
    public float maxClampX;
    public Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rig.velocity = new Vector2(-1 * speed * Time.deltaTime, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rig.velocity = new Vector2(1 * speed * Time.deltaTime, 0);
        }

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minClampX, maxClampX), transform.position.y);
    }

    Vector3 mouseOffset;
    float mouseCoord;
    private void OnMouseDown()
    {
        if (!canDrag)
            return;
        GameController.getInstance().ball.GetComponent<Ball>().startBall();
        mouseCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
        mouseOffset = gameObject.transform.position - getMouseWorldPos();
        GameController.getInstance().hideText();
    }

    private void OnMouseEnter()
    {
        canDrag = true;
    }

    private void OnMouseDrag()
    {
        if (!canDrag)
            return;
        transform.position = getMouseWorldPos() + mouseOffset;
    }

    private Vector3 getMouseWorldPos()
    {
        Vector2 mPoint = Input.mousePosition;
        mPoint.y = mouseCoord;
        return Camera.main.ScreenToWorldPoint(mPoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().SetDirection(transform.position);
        }
    }

    public void resetSquare()
    {
        transform.position = Vector3.zero;
        canDrag = false;
        GameController.getInstance().showText();
    }
}
