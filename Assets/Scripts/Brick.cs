using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    // Start is called before the first frame update
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            collision.gameObject.GetComponent<Ball>().SetDirection(transform.position);
            GameController.getInstance().listBricks.Remove(gameObject);
            GameController.getInstance().checkResetGame();
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }


}
